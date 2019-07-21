using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// Raise when game score was changed
    /// </summary>
    public static Action<int> onScoreChanged;
    private int _score;

    [SerializeField]
    private SpawnPoint _spawnPoint;
    [SerializeField]
    private FlippersController _flippers;

    [Header("UI")]
    [SerializeField]
    private MainScreen _mainScreen;
    [SerializeField]
    private GameScreen _gameScreen;
    [SerializeField]
    private GameOverScreen _gameOverScreen;

    /// <summary>
    /// Initialization
    /// </summary>
   void Start()
    {
        //Subscribe
        SpawnPoint.onBallLaunched += onBallLaunched;
        GameOverScreen.onGameRestartAI += onGameStartAI;
        GameOverScreen.onGameRestart += onGameStart;
        GameOverScreen.onBackToMenu += onBackToMenu;
        MainScreen.onGameStartAI += onGameStartAI;
        MainScreen.onGameStart += onGameStart;
        Score.onScoreGain += onScoreGain;
        LoseArea.onBallOut += onGameOver;

        _spawnPoint.enabled = false;
        _flippers.enabled = false;

        onBackToMenu();
    }

    void OnDestroy()
    {
        //Unsubscribe
        SpawnPoint.onBallLaunched -= onBallLaunched;
        GameOverScreen.onGameRestartAI -= onGameStartAI;
        GameOverScreen.onGameRestart -= onGameStart;
        GameOverScreen.onBackToMenu -= onBackToMenu;
        MainScreen.onGameStartAI -= onGameStartAI;
        MainScreen.onGameStart -= onGameStart;
        Score.onScoreGain -= onScoreGain;
        LoseArea.onBallOut -= onGameOver;
    }

    void onBackToMenu()
    {
        _gameOverScreen.Hide();
        _mainScreen.Show();
        _gameScreen.Hide();
    }

    void onScoreGain(int score)
    {
        _score += score;

        //Inform subscribers
        onScoreChanged?.Invoke(_score);
    }

    void onBallLaunched()
    {
        _spawnPoint.enabled = false;
        _flippers.enabled = true;
    }

    void onGameStart()
    {
        _gameOverScreen.Hide();
        _mainScreen.Hide();
        _gameScreen.Show();

        _spawnPoint.enabled = true;
        _flippers.enabled = false;
        AIHelper.enabled = false;
    }

    void onGameStartAI()
    {
        onGameStart();

        _spawnPoint.LaunchBall(UnityEngine.Random.value);
        _flippers.enabled = false;
        AIHelper.enabled = true;
    }

    void onGameOver()
    {
        _gameOverScreen.Show();
        _gameScreen.Hide();

        _spawnPoint.enabled = false;
        _flippers.enabled = false;

        _gameOverScreen.SetFinalScore(_score);
        _score = 0;

        //Inform subscribers
        onScoreChanged?.Invoke(_score);
    }
}
