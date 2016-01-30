using UnityEngine;
using System.Collections;

public class PlayerSkills : MonoBehaviour
{
    public GameObject fireSkill1Object;
    public GameObject waterSkill1Object;
    public GameObject earthSkill1Object;
    public LayerMask mask = -1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateSkillFire();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateSkillWater();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateSkillEarth();
        }
    }

    void ActivateSkillFire()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, mask.value))
        {
            //GameObject instance = (GameObject)
            Instantiate(fireSkill1Object, hit.point + new Vector3 (0f, 60f, 0f), Quaternion.identity);
        }
    }
    void ActivateSkillWater()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, mask.value))
        {
            //GameObject instance = (GameObject)
            Instantiate(waterSkill1Object, hit.point, Quaternion.Euler(270f, Random.Range(0f, 360f), 0f));
        }
    }

    void ActivateSkillEarth()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, mask.value))
        {
            //GameObject instance = (GameObject)
            Instantiate(earthSkill1Object, hit.point + new Vector3(0f, 0.1f, 0f), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        }
    }
}
