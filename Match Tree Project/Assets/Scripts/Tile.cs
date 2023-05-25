using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public sealed class Tile : MonoBehaviour
{
    public int x;
    public int y;

    private Item _item;

    public Item Item
    {
        get => _item;

        set
        {
            if(_item == value) return;

            _item = value;

            icon.sprite = _item.sprite;
        }
    }

    public Image icon;

    public Button button;

    public Tile Left => x > 0 ? Board.Instance.Tiles[x - 1, y] : null;
    public Tile Top => y > 0 ? Board.Instance.Tiles[x, y - 1] : null;
    public Tile Right => x < Board.Instance.Width - 1 ? Board.Instance.Tiles[x + 1, y] : null;
    public Tile Bottom => y < Board.Instance.Height - 1 ? Board.Instance.Tiles[x, y + 1] : null;

    public Tile[] Neighbours => new []
    {
        Left,
        Top,
        Right,
        Bottom,

    };

    private void Start() => button.onClick.AddListener(() => Board.Instance.Select(this));
    
    public List<Tile> GetConnectedTiles(List<Tile> exclude = null)
    {
        var result = new List<Tile> { this, };

        if (exclude == null)
        {
            exclude = new List<Tile> { this, };
        }
        else
        {
            exclude.Add(this);
        }

        foreach (var neighbour in Neighbours)
        {
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.Item != Item) continue;

            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;
    }

    public void SetSelectedColor()
    {
        // Modify the appearance or color of the tile when selected
        // For example, you can change the tile's color to indicate selection
        var image = GetComponent<Image>();
        if (image != null)
        {
            Color newColor = new Color(0.3f, 0.4f, 0.6f, 0.3f);
            image.color = newColor;
        }
    }

    public void ResetColor()
    {
        // Reset the appearance or color of the tile after the move
        // For example, you can change the tile's color back to its original color
        var image = GetComponent<Image>();
        if (image != null)
        {
            image.color = Color.white;
        }
    }
}