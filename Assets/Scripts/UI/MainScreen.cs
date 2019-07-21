using Assets.Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour, IUserInterface
{
    [SerializeField]
    private Button _startButton;
    [SerializeField]
    private Button _aiButton;

    public static Action onGameStart;
    public static Action onGameStartAI;

  
    public void Show()
    {
        _startButton.onClick.AddListener(() => onGameStart?.Invoke());
        _aiButton.onClick.AddListener(() => onGameStartAI?.Invoke());

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        _startButton.onClick.RemoveAllListeners();
        _aiButton.onClick.RemoveAllListeners();

        gameObject.SetActive(false);
    }
}
