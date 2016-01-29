using UnityEngine;
using System.Collections;

public class PlayerSkills : MonoBehaviour
{
    public GameObject fireSkill1Object;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(SkillFlame1());
        }
    }

    IEnumerator SkillFlame1()
    {
        GameObject instance = (GameObject)Instantiate(fireSkill1Object, transform.position + transform.forward * 5, Quaternion.identity);
        instance.transform.SetParent(transform);
        instance.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(2f);
        Destroy(instance);
    }
}
