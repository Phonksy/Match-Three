using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class MovesCounter : MonoBehaviour
{
    public static MovesCounter Instance { get; private set; }

    private int _moves;

    public int Moves
    {
        get => _moves;

        set
        {
            if (_moves == value) return;

            _moves = value;

            movesText.SetText($"{_moves}");
        }
    }

    [SerializeField] private TextMeshProUGUI movesText;

    private void Awake() => Instance = this;
}
