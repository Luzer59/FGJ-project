using UnityEngine;
using System.Collections;

public class PlayerSkills : MonoBehaviour
{
    public GameObject fireSkill1Object;
    public GameObject waterSkill1Object;
    public LayerMask mask = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SkillWater1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SkillFlame1();
        }
    }

    void SkillFlame1()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, mask.value))
        {
            GameObject instance = (GameObject)Instantiate(fireSkill1Object, hit.point + new Vector3 (0f, 20f, 0f), Quaternion.identity);

        }
    }

    void SkillWater1()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000, mask.value))
        {
            GameObject instance = (GameObject)Instantiate(waterSkill1Object, hit.point, Quaternion.Euler(270f, 0f, Random.Range(0f, 360f)));
        }
    }
}
