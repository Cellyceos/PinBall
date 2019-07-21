using Assets.Scripts.UI;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour, IUserInterface
{
    [SerializeField]
    private Button _restartButton;
    [SerializeField]
    private Button _menuButton;
    [SerializeField]
    private TextMeshProUGUI _scoreText;

    /// <summary>
    /// Final Score text format
    /// </summary>
    public string scoreTextFormat = "Final Score: {0}";

    public static Action onBackToMenu;
    public static Action onGameRestart;
    public static Action onGameRestartAI;

    public void Show()
    {
        _restartButton.onClick.AddListener(() => {
            if (AIHelper.enabled)
                onGameRestartAI?.Invoke();
            else
                onGameRestart?.Invoke();
        });

        _menuButton.onClick.AddListener(() => onBackToMenu?.Invoke());

        gameObject.SetActive(true);
    }

    public void SetFinalScore(int score)
    {
        _scoreText.text = string.Format(scoreTextFormat, score);
    }

    public void Hide()
    {
        _restartButton.onClick.RemoveAllListeners();
        _menuButton.onClick.RemoveAllListeners();

        gameObject.SetActive(false);
    }
}
