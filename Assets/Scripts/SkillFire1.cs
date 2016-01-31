using UnityEngine;
using System.Collections;

public class SkillFire1 : MonoBehaviour
{
    public GameObject explosion;

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
        GetComponent<Rigidbody>().isKinematic = true;
        explosion.SetActive(true);
        GetComponent<AudioSource>().Play();
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject, 1f);
    }
}
