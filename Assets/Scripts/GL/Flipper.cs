using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(HingeJoint))]
public class Flipper : MonoBehaviour
{
    private HingeJoint _hingeJoint;

    [SerializeField]
    private float _timeDelay = 0.1f;

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
        StartCoroutine(RotateDown());
    }

    /// <summary>
    /// Rotate down the flipper
    /// </summary>
    public IEnumerator RotateDown()
    {
        yield return new WaitForSeconds(_timeDelay);
        _hingeJoint.useMotor = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RotateUp();
        }
    }
}
