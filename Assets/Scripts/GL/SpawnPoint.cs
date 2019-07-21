using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpawnPoint : MonoBehaviour
{
    public static Action<float> onPowerChanged;

    /// <summary>
    /// Ball 3D model
    /// </summary>
    public GameObject ballModel;

    /// <summary>
    /// Min applied force to ball
    /// </summary>
    public float minAppliedForce = 10;

    /// <summary>
    /// Max applied force to ball
    /// </summary>
    public float maxAppliedForce = 35;

    /// <summary>
    /// 
    /// </summary>
    public float powerGain = 1.2f;
    private float _power = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // If the key is down gain power
        if (Input.GetMouseButton(1))
        {
            _power += powerGain * Time.deltaTime;
        }

        var clampedPower = Mathf.Clamp01(_power);
        if (Input.GetMouseButtonUp(1))
        {
            var forcePower = minAppliedForce + (clampedPower * (maxAppliedForce - minAppliedForce));
            _power = 0f;

            // Spawn it at the spawnPoint and add force
            var ball = Instantiate(ballModel, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * forcePower, ForceMode.VelocityChange);
        }

        // Inform subscribers
        onPowerChanged?.Invoke(clampedPower);
    }
}
