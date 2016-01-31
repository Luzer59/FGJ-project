using UnityEngine;
using System.Collections;

public class PlayerSkills : MonoBehaviour
{
    public GameObject fireSkill1Object;
    public GameObject waterSkill1Object;
    public GameObject earthSkill1Object;
    public float skillTimer;
    public LayerMask mask = -1;

    private float skillTimerCurrent;

    void Update()
    {
        if (skillTimerCurrent > 0f)
        {
            skillTimerCurrent = Mathf.Clamp(skillTimerCurrent - Time.deltaTime, 0f, skillTimer);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateSkillFire();
                GetComponent<PlayerMovement>().AttackStateActivation();
                skillTimerCurrent = skillTimer;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ActivateSkillWater();
                GetComponent<PlayerMovement>().AttackStateActivation();
                skillTimerCurrent = skillTimer;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ActivateSkillEarth();
                GetComponent<PlayerMovement>().AttackStateActivation();
                skillTimerCurrent = skillTimer;
            }
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
