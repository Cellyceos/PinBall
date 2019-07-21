using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Score : MonoBehaviour
{
    /// <summary>
    /// Raise when the score was gain
    /// </summary>
    public static Action<int> onScoreGain;

    /// <summary>
    /// Score
    /// </summary>
    public int score;

    /// <summary>
    /// Check if a ball collided with this object
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Ball>())
        {
            onScoreGain?.Invoke(score);
        }
    }
}
