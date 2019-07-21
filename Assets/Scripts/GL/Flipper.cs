using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class Flipper : MonoBehaviour
{
    private HingeJoint _hingeJoint;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        _hingeJoint = GetComponent<HingeJoint>();
    }

    /// <summary>
    /// Rotate up the flipper
    /// </summary>
    public void RotateUp()
    {
        _hingeJoint.useMotor = true;
    }

    /// <summary>
    /// Rotate down the flipper
    /// </summary>
    public void RotateDown()
    {
        _hingeJoint.useMotor = false;
    }

    /// <summary>
    ///     Uses to rotate the flipper in AI mode.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision)
    {
        if (AIHelper.enabled && collision.gameObject.GetComponent<Ball>())
        {
            StartCoroutine(Pull());
        }
    }

    public IEnumerator Pull()
    {
        RotateUp();
        yield return new WaitForSeconds(Random.Range(AIHelper.minDelayTime, AIHelper.maxDelayTime));
        RotateDown();
    }
}
