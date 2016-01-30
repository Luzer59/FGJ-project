using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {

    public float duration = 1.0F;
    public Light lt;
    void Start()
    {
        lt = GetComponent<Light>();
    }
    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.75F + 6.0F;
        lt.intensity = amplitude;
    }
}
