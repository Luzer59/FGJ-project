using UnityEngine;
using System.Collections;

public class SkillFire1 : MonoBehaviour
{
    public float moveSpeed;

    private bool hasHitGround = false;

    void Update()
    {
        if (!hasHitGround)
        {
            //transform.Translate(0f, moveSpeed, 0f, Space.World);
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
