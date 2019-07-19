using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseArea : MonoBehaviour
{
    /// <summary>
    /// Wait (in sec) before destroy
    /// </summary>
    public float waitBeforeDestroy = 2.0f;

    /// <summary>
    /// Will check if a ball collided with this object
    /// </summary>
    /// <param name="collider"></param>
    void OnTriggerEnter(Collider collider)
    {
        var ball = collider.transform.gameObject;

        if (ball != null)
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
