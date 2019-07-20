using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Score : MonoBehaviour
{
    public int score;

    /// <summary>
    /// Check if a ball collided with this object
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Ball>())
        {
            //do something
        }
    }
}
