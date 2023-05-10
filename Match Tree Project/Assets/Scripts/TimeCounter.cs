using UnityEngine;
using UnityEngine.UI;
using TMPro;

public sealed class TimeCounter : MonoBehaviour
{
    public static TimeCounter Instance { get; private set; }

    private string _timer;

    public string Timer
    {
        get => _timer;

        set
        {
            if (_timer == value) return;

            _timer = value;

            timerText.SetText($"{_timer}");
        }
    }

    [SerializeField] private TextMeshProUGUI timerText;

    private void Awake() => Instance = this;
}
