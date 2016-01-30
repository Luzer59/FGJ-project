using UnityEngine;
using System.Collections;

public class StopEffect : MonoBehaviour
{
    public void Stop()
    {
        gameObject.SetActive(false);
    }
}
