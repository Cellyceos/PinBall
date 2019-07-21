using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : MonoBehaviour
{
    private Image _powerIndicator;
    private TextMeshProUGUI _scoreText;

    /// <summary>
    /// Score text format
    /// </summary>
    public string scoreTextFormat = "Score: {0}";

    // Use this for initialization
    void Start()
    {
        _powerIndicator = GetComponentInChildren<Image>();
        _scoreText = GetComponentInChildren<TextMeshProUGUI>();

        //Subscribe
        GameController.onScoreChanged += onScoreChanged;
        SpawnPoint.onPowerChanged += onPowerChanged;
    }

    void OnDestroy()
    {
        //Unsubscribe
        GameController.onScoreChanged -= onScoreChanged;
        SpawnPoint.onPowerChanged -= onPowerChanged;
    }

    void onPowerChanged(float power)
    {
        _powerIndicator.fillAmount = power;
    }

    void onScoreChanged(int score)
    {
        _scoreText.text = string.Format(scoreTextFormat, score);
    }
}
