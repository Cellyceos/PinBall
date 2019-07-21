using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    /// <summary>
    /// Rotation speed on XYZ axis
    /// </summary>
    [SerializeField]
    private Vector3 _rotationSpeed = new Vector3(0.0f, 5.0f, 0.0f);

    void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime);
    }
}
