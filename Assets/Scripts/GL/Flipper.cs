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
}
