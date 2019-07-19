using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    /// <summary>
    /// Ball 3D model
    /// </summary>
    public GameObject ballModel;

    /// <summary>
    /// Min applied force to ball
    /// </summary>
    public float minAppliedForce = 20;

    /// <summary>
    /// Max applied force to ball
    /// </summary>
    public float maxAppliedForce = 35;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            // Spawn it at the spawnPoint and add force
            var ball = Instantiate(ballModel, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * maxAppliedForce, ForceMode.VelocityChange);
        }
    }
}
