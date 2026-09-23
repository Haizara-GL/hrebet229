using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Slider timerProgressBar;
    [SerializeField] private TextMeshProUGUI resoursceText;
    private float _currTimer;
    public int ResourceAmount { get; private set; }
    private const int ResourceStep = 3;

    private void Awake()
    {
        StartTimer();
        DrowResource();
    }

    private void StartTimer() =>
        _currTimer = 0;

    private void Update()
    {
        RunTimer();
    }
    private void RunTimer()
    {
        if (_currTimer <= duration)
        {
            _currTimer += Time.deltaTime;
            timerProgressBar.value = _currTimer / duration;
        }
        else
        {
            AddResource();
            StartTimer();
        }
    }

    private void DrowResource() =>
        resoursceText.text = $"Resource: {ResourceAmount}";
    private void AddResource()
    {
        ResourceAmount += ResourceStep;
        DrowResource();
    }
}
