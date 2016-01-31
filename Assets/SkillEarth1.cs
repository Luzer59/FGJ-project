using UnityEngine;
using System.Collections;

public class SkillEarth1 : MonoBehaviour
{
    public ParticleSystem leafEffect;

    void Start()
    {
        GetComponent<AudioSource>().Play();
        leafEffect.Play(true);
        Destroy(gameObject, 2f);
    }
}