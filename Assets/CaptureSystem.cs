using UnityEngine;
using System.Collections;

public class CaptureSystem : MonoBehaviour
{
    public float maxHealth;
    public GameObject[] capturezones;
    public float[] health;

    private bool[] isEnemyCaptured;

    void Start()
    {
        isEnemyCaptured = new bool[capturezones.Length];
        health = new float[capturezones.Length];
    }

    void Update()
    {

    }
}
