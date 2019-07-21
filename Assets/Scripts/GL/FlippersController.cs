using UnityEngine;

public class FlippersController : MonoBehaviour
{
    private Flipper[] _flippers;

    /// <summary>
    /// Initializing
    /// </summary>
    void Start()
    {
        _flippers = GetComponentsInChildren<Flipper>();
    }

    /// <summary>
    /// Rotate flippers to up
    /// </summary>
    public void RotateUp()
    {
        foreach(Flipper flipper in _flippers)
        {
            flipper.RotateUp();
        }
    }

    /// <summary>
    /// Rotate flippers to down
    /// </summary>
    public void RotateDown()
    {
        foreach (Flipper flipper in _flippers)
        {
            flipper.RotateDown();
        }
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
