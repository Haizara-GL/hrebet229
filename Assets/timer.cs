using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Image timerProgressBar;
    [SerializeField] private Button startButton;
    private float _currTimer;

    private float CurrTimer
    {
        get => _currTimer;
        set
        {
            _currTimer = value;
            if (_currTimer <= 0)
            {
                startButton.interactable = true;
                _isTimerRunning = false;
                timerProgressBar.fillAmount = 1f;
            }
        }
    }
    private bool _isTimerRunning;

    private void Awake()
    {
        startButton.onClick.AddListener(StartTimer);
    }

    private void StartTimer()
    {
        if (!_isTimerRunning)
        {
            _isTimerRunning = true;
            startButton.interactable = false;
            _currTimer = duration;
        }
    }

    private void Update()
    {
        RunTimer();
    }

    private void RunTimer()
    {
        if (CurrTimer > 0 && _isTimerRunning)
        {
            CurrTimer -= Time.deltaTime;
            timerProgressBar.fillAmount = CurrTimer / duration;
        }
    }
}
