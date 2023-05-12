using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class GemsCounter : MonoBehaviour
{
    public static GemsCounter Instance { get; private set; }

    private int _gemsPoppedCount;

    public int Gems
    {
        get => _gemsPoppedCount;

        set
        {
            if (_gemsPoppedCount == value) return;

            _gemsPoppedCount = value;

            gems_count.SetText($"{_gemsPoppedCount}");
        }
    }

    [SerializeField] private TextMeshProUGUI gems_count;

    private void Awake() => Instance = this;
}
