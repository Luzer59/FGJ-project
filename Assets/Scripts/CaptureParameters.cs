using UnityEngine;
using System.Collections;

public class CaptureParameters : MonoBehaviour
{
    public bool isCapturedByPlayer = true;
    public float health;
    public float maxHealth;
    public float damageRate;
    public float healRate;

    private CaptureSystem cs;

    void Awake()
    {
        cs = GameObject.FindGameObjectWithTag("GameController").GetComponent<CaptureSystem>();
    }

    void Start()
    {
        health = maxHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && health > 0f)
        {
            Destroy(other.gameObject);
            health -= damageRate;
            if (health <= 0f)
            {
                isCapturedByPlayer = false;
                health = 0f;
                cs.CheckCaptureStatus();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && health < maxHealth)
        {
            health += healRate;
            if (health > 0f)
            {
                isCapturedByPlayer = true;
            }
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}
