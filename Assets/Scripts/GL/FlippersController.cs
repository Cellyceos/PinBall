using UnityEngine;
using System.Collections;

public class FlippersController : MonoBehaviour
{
    [SerializeField]
    private Flipper _leftFlipper;

    [SerializeField]
    private Flipper _rightFlipper;

    /// <summary>
    /// Rotate flippers to up
    /// </summary>
    public void RotateUp()
    {
        _leftFlipper.RotateUp();
        _rightFlipper.RotateUp();
    }

    /// <summary>
    /// Rotate flippers to down
    /// </summary>
    public void RotateDown()
    {
        _leftFlipper.RotateDown();
        _rightFlipper.RotateDown();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RotateUp();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            RotateDown();
        }
    }
}
