using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSkills : MonoBehaviour
{
    public GameObject hitIndicator;
    public GameObject fireSkill1Object;
    public GameObject waterSkill1Object;
    public GameObject earthSkill1Object;
    public float skillTimer;
    public LayerMask mask = -1;

    public GameObject SpellAvailableUI;
    public GameObject SpellsOnCooldownUI;
    public Image cooldownBarToAnimate;

    private float skillTimerCurrent;

    void Update()
    {
        if (skillTimerCurrent > 0f)
        {
            skillTimerCurrent = Mathf.Clamp(skillTimerCurrent - Time.deltaTime, 0f, skillTimer);
            Debug.Log(skillTimerCurrent);
            cooldownBarToAnimate.fillAmount =  skillTimerCurrent+ 0.1f;
        }
        else
        {
            ShowSkillsAsAvailable();
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ActivateSkillFire();
                GetComponent<PlayerMovement>().AttackStateActivation();
                skillTimerCurrent = skillTimer;
                ShowSkillsOnCooldown();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ActivateSkillWater();
                GetComponent<PlayerMovement>().AttackStateActivation();
                skillTimerCurrent = skillTimer;
                ShowSkillsOnCooldown();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ActivateSkillEarth();
                GetComponent<PlayerMovement>().AttackStateActivation();
                skillTimerCurrent = skillTimer;
                ShowSkillsOnCooldown();
            }
        }
    }

    void ShowSkillsAsAvailable()
    {
        SpellAvailableUI.SetActive(true);
        SpellsOnCooldownUI.SetActive(false);
    }

    void ShowSkillsOnCooldown()
    {
        SpellsOnCooldownUI.SetActive(true);
        SpellAvailableUI.SetActive(false);

    }

    void ActivateSkillFire()
    {
        RaycastHit hit;

        
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, mask.value))
        {
            //GameObject instance = (GameObject)
            GameObject asd = (GameObject)Instantiate(hitIndicator, hit.point, Quaternion.identity);
            Destroy(asd, 3f);
            Instantiate(fireSkill1Object, hit.point + new Vector3 (0f, 60f, 0f), Quaternion.identity);
        }

        TurnTowardsRay(hit.point);
    }
    void ActivateSkillWater()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, mask.value))
        {
            //GameObject instance = (GameObject)
            Instantiate(waterSkill1Object, hit.point, Quaternion.Euler(270f, Random.Range(0f, 360f), 0f));
        }

        TurnTowardsRay(hit.point);
    }

    void ActivateSkillEarth()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, mask.value))
        {
            //GameObject instance = (GameObject)
            Instantiate(earthSkill1Object, hit.point + new Vector3(0f, 0.1f, 0f), Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
        }

        TurnTowardsRay(hit.point);
    }

    void TurnTowardsRay(Vector3 pos)
    {
        transform.LookAt(pos, Vector3.up);
    }
}
