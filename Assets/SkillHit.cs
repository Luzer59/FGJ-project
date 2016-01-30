using UnityEngine;
using System.Collections;

public class SkillHit : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyAiBase>().TakeDamage();
        }
    }
}
