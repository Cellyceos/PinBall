using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rigidbody;

    /// <summary>
    /// Initialization
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Adds a force to the Rigidbody.
    /// </summary>
    /// <param name="force">Force vector in world coordinates.</param>
    public void AddForce(Vector3 force, ForceMode mode = ForceMode.Impulse)
    {
        _rigidbody.AddForce(force);
    }
}
