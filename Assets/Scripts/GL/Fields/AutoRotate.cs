using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [SerializeField]
    private Vector3 _rotationSpeed = new Vector3(0.0f, 5.0f, 0.0f);

    private void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime);
    }
}
