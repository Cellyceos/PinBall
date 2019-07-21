using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LoseArea : MonoBehaviour
{
    /// <summary>
    /// Wait (in sec) before destroy
    /// </summary>
    public float waitBeforeDestroy = 1.5f;

    /// <summary>
    /// Will check if a ball collided with this object
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        var ball = collider.transform.gameObject;

        if (ball.GetComponent<Ball>())
        {
            StartCoroutine(WaitAndDestroy(ball));
        }
    }

    /// <summary>
    /// Wait and Destroy
    /// </summary>
    /// <param name="ball">object to destroy</param>
    IEnumerator WaitAndDestroy(GameObject ball)
    {
        yield return new WaitForSeconds(waitBeforeDestroy);
        Destroy(ball);
    }
}
