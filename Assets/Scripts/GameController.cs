using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static Action<int> onScoreChanged;
    private int _score;

    /// <summary>
    /// Initialization
    /// </summary>
   void Start()
    {
        //Subscribe
        Score.onScoreGain += onScoreGain;
        LoseArea.onBallOut += onGameOver;
    }

    void OnDestroy()
    {
        //Unsubscribe
        Score.onScoreGain -= onScoreGain;
        LoseArea.onBallOut -= onGameOver;
    }

    void onScoreGain(int score)
    {
        _score += score;

        //Inform subscribers
        onScoreChanged?.Invoke(_score);
    }

    void onGameOver()
    {
        _score = 0;

        //Inform subscribers
        onScoreChanged?.Invoke(_score);
    }
}
