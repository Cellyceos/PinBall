using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    /// <summary>
    /// Raise when the ball was launched
    /// </summary>
    public static Action onBallLaunched;

    /// <summary>
    /// Raise when power was changed
    /// </summary>
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

    /// <summary>
    /// Update is called once per frame 
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _power += powerGain * Time.deltaTime;
        }

        var clampedPower = Mathf.Clamp01(_power);
        if (Input.GetMouseButtonUp(0))
        {
            LaunchBall(clampedPower);
            clampedPower = _power = 0.0f;
        }

        // Inform subscribers
        onPowerChanged?.Invoke(clampedPower);
    }

    public void LaunchBall(float power)
    {
        var forcePower = minAppliedForce + (power * (maxAppliedForce - minAppliedForce));

        // Spawn it at the spawnPoint and add force
        var ball = Instantiate(ballModel, transform.position, transform.rotation);
        ball.GetComponent<Rigidbody>().AddForce(Vector3.forward * forcePower, ForceMode.VelocityChange);

        onBallLaunched?.Invoke();
    }
}
