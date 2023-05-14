using System.Linq;
using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography;
using System.Threading;
using UnityEditor.Profiling;
using UnityEngine.Audio;

public sealed class Board : MonoBehaviour
{
    public AudioClip poppingSoundEffect;

    public static Board Instance { get; private set; }

    public int level;

    public Row[] rows;
    
    public Tile[,] Tiles { get; private set; }
    // Points, Pops, Moves, TimeValue           1                   2                   3                   4                   5                   6                  7                   8                   9                 10
    public int[,] Goals = new int[,] { { 100, -1, -1, -1 }, { 200, -1, -1, 180 }, { 300, -1, -1, -1 }, { 100, -1, 10, -1 }, { 500, -1, -1, -1 }, { -1, 50, -1, 60 }, { 500, -1, -1, 300 }, { -1, 100, -1, 60 }, { 500, 150, -1, -1 }, { -1, 200, -1, 120 } };

    private int score = 0;
    private int gemsPoppedCount = 0;

    private int maxMoves = 0;

    public int Width => Tiles.GetLength(dimension:0);
    public int Height => Tiles.GetLength(dimension:1);

    private readonly List<Tile> _selection = new List<Tile>();

    private const float TweenDuration = 0.25f;
    public float timeValue = 0;

    public void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;

        maxMoves = Goals[level, 2];
        if (Goals[level, 2] > 0)
            MovesCounter.Instance.Moves = maxMoves;

        timeValue = Goals[level, 3];
        float minutes = Mathf.FloorToInt(timeValue / 60);
        float seconds = Mathf.FloorToInt(timeValue % 60);

        if (Goals[level, 3] > 0)
            TimeCounter.Instance.Timer = string.Format("{0:00}:{1:00}", minutes, seconds);

        Tiles = new Tile[rows.Max(row => row.tiles.Length), rows.Length];        

        for (var y = 0; y< Height; y++)
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
        //Points, Pops, Moves, TimeValue              1                   2                   3                   4                 5                6               7                8                  9                 10
        //public int[,] Goals = new int[,]{ { 100, -1, -1, -1}, { 200, -1, -1, 180}, { 300, -1, -1, -1}, { 100, -1, 10, -1}, { 500, -1, -1, -1}, { -1, 50, -1, 60}, { 500, -1, -1, 300}, { -1, 100, -1, 60}, { 500, 150, -1, -1}, { -1, 200, -1, 120} };

        //tikrinam, ar reikia laikmačio. Jei reikia - skaičiuojam ir atvaizduojam
        if (Goals[level, 3] > 0)
        {
            DisplayTime(timeValue);
            timeValue -= Time.deltaTime;
            if (timeValue < 0)
                SceneManager.LoadScene(14);
        }

        //tikrinam, ar goal turi nurodyta ejimu skaiciu
        if (Goals[level, 2] > 0)
        {
            if (maxMoves==0)
                SceneManager.LoadScene(14);
            else if (maxMoves>0 && score >= Goals[level,0] && level != 9)
                SceneManager.LoadScene(13);
            else if (maxMoves > 0 && score >= Goals[level, 0] && level == 9)
                SceneManager.LoadScene(15);
        }

        //tikrinam, ar surinktas reikiamas kiekis tasku
        if (Goals[level, 0] > 0)
        {
            if (score >= Goals[level, 0] && level != 9)
                SceneManager.LoadScene(13);
            if (score >= Goals[level, 0] && level == 9)
                SceneManager.LoadScene(15);
        }

        //tikrinam, ar reikia susprogdinti tam tikrą skaičių gems
        if (Goals[level, 1] > 0)
        {
            if (gemsPoppedCount >= Goals[level,1] && level != 9)
                SceneManager.LoadScene(13);
            if (gemsPoppedCount >= Goals[level, 1] && level == 9)
                SceneManager.LoadScene(15);
        }

    }

    public void DisplayTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        TimeCounter.Instance.Timer = string.Format("{0:00}:{1:00}", minutes, seconds);
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
        if (Goals[level, 2] > 0)
        {
            maxMoves--;
            MovesCounter.Instance.Moves = maxMoves;
        }

        if (CanPop())
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

        _isAnimating = false;
    }

    private bool CanPop()
    {
        for(var y = 0; y < Height; y++)
        {
            for(var x = 0; x < Width; x++)
            {
                if (Tiles[x, y].GetConnectedTiles().Skip(1).Count() >= 2)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private async void Pop()
    {
        for (var y = 0; y < Height; y++)
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

                if (Goals[level, 0] > 0)
                {
                    ScoreCounter.Instance.Score += connectedTiles.Count * 2;
                    score = ScoreCounter.Instance.Score;
                }

                if (Goals[level, 1] > 0)
                {
                    GemsCounter.Instance.Gems += connectedTiles.Count;
                    gemsPoppedCount = GemsCounter.Instance.Gems;
                }

                var inflateSequence = DOTween.Sequence();

                foreach(var connectedTile in connectedTiles)
                {
                    connectedTile.Item = ItemDatabase.Items[Random.Range(0, ItemDatabase.Items.Length)];
                    
                    inflateSequence.Join(connectedTile.icon.transform.DOScale(Vector3.one, TweenDuration));
                }

                Vector3 screenCenter = new Vector3(0.5f, 0.5f, Camera.main.nearClipPlane);
                Vector3 worldCenter = Camera.main.ViewportToWorldPoint(screenCenter);
                AudioSource.PlayClipAtPoint(poppingSoundEffect, worldCenter, 0.2f);
                await inflateSequence.Play().AsyncWaitForCompletion();
                
            }
        }

    }
}
