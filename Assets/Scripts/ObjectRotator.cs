using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(1.0f, 0.0f, 0.0f);
    [HideInInspector]
    public Vector3 rotationSpeedOriginal;

    void Start()
    {
        rotationSpeedOriginal = rotationSpeed;
    }

    void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }

}
