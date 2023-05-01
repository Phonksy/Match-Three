using System.Linq;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography;
using System.Threading;
using System.Diagnostics;

public sealed class Board : MonoBehaviour
{
    public static Board Instance { get; private set; }

    public int level;

    public TextMeshProUGUI movesText;

    public Row[] rows;

    public Tile[,] Tiles { get; private set; }
    // Points, Pops, Moves
    public int[,] Goals = new int[,]{ { 100, 0, 0}, { 200, 0, 0 }, { 300, 0, 0 }, { 100, 20, 10 }, { 500, 0, 0 }, { 0, 50, 0 }, { 500, 0, 0 }, { 100, 0, 0 }, { 500, 150, 0 }, { 200, 100, 0 } };

    private int score = 0;
    private int gemsPoppedCount = 0;

    private int maxMoves = 0;

    public int Width => Tiles.GetLength(dimension:0);
    public int Height => Tiles.GetLength(dimension:1);

    private readonly List<Tile> _selection = new List<Tile>();

    private const float TweenDuration = 0.25f;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;

        maxMoves = Goals[level, 2];

        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length];

        for(var y = 0; y< Height; y++)
        {
            for(var x = 0; x< Width; x++)
            {
                var tile = rows[y].tiles[x];

                tile.x = x;
                tile.y = y;

                tile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];

                Tiles[x, y] = rows[y].tiles[x];
            }
        }
    }

    private void Update()
    {   
        

        if (score >= Goals[level,0]  && gemsPoppedCount >= Goals[level,1] && maxMoves == 0)
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene(13);          
        }
    }

    private bool _isAnimating = false;

    public async void Select(Tile tile)
    {
        if (_isAnimating) return;

        if(!_selection.Contains(tile)) _selection.Add(tile);    

        if(_selection.Count <2) return;

        var dx = Mathf.Abs(_selection[0].x - _selection[1].x);
        var dy = Mathf.Abs(_selection[0].y - _selection[1].y);

        if (dx + dy > 1)
        {
            _selection.Clear();
            return;
        }

        await Swap(_selection[0], _selection[1]);

        if(CanPop())
        {
            Pop();
        }
        else
        {
            await Swap(_selection[0], _selection[1]);
        }

        _selection.Clear();
    }

    

    public async Task Swap(Tile tile1, Tile tile2)
    {
        _isAnimating = true;
        var icon1 = tile1.icon;
        var icon2 = tile2.icon;

        var icon1Transform = icon1.transform;
        var icon2Transform = icon2.transform;

        var sequence = DOTween.Sequence();

        sequence.Join(icon1Transform.DOMove(icon2Transform.position, TweenDuration))
                .Join(icon2Transform.DOMove(icon1Transform.position, TweenDuration));

        await sequence.Play().AsyncWaitForCompletion();

        icon1Transform.SetParent(tile2.transform);
        icon2Transform.SetParent(tile1.transform);

        tile1.icon = icon2;
        tile2.icon = icon1;

        var tile1Item = tile1.Item;
        
        tile1.Item = tile2.Item;
        tile2.Item = tile1Item;
        maxMoves--;

        MovesCounter.Instance.Moves = maxMoves;

        _isAnimating = false;
    }

    private bool CanPop()
    {
        for(var y = 0; y < Height; y++)
        {
            for(var x = 0; x < Width; x++)
            {
                if(Tiles[x,y].GetConnectedTiles().Skip(1).Count() >= 2) return true;
            }
        }

        return false;
    }

    private async void Pop()
    {
        for(var y = 0; y < Height; y++)
        {
            for(var x = 0; x < Width; x++)
            {
                var tile = Tiles[x,y];

                var connectedTiles = tile.GetConnectedTiles();

                if(connectedTiles.Skip(1).Count() < 2) continue;

                var deflateSequance = DOTween.Sequence();

                foreach(var connectedTile in connectedTiles)
                {
                    deflateSequance.Join(connectedTile.icon.transform.DOScale(Vector3.zero, TweenDuration));
                }

                await deflateSequance.Play().AsyncWaitForCompletion();

                ScoreCounter.Instance.Score += connectedTiles.Count * 2;

                score = ScoreCounter.Instance.Score;

                gemsPoppedCount += connectedTiles.Count;

                var inflateSequence = DOTween.Sequence();

                foreach(var connectedTile in connectedTiles)
                {
                    connectedTile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];
                    
                    inflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.one, TweenDuration));
                }

                await inflateSequence.Play().AsyncWaitForCompletion();
            }
        }      
    }
}
