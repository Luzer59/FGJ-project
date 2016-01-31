using UnityEngine;
using System.Collections;

public class CaptureParameters : MonoBehaviour
{
    public bool isCapturedByPlayer = true;
    public float health;
    public float maxHealth;
    public float damageRate;
    public float healRate;
    public ObjectRotator rotatorTop;
    public ObjectRotator rotatorBottom;
    public MeshRenderer meshRendererTop;
    public MeshRenderer meshRendererBottom;
    public GameObject healParticles;
    public GameObject enterEffect;

    private Color startColorTop;
    private Color startColorBottom;
    private CaptureSystem cs;

    void Awake()
    {
        cs = GameObject.FindGameObjectWithTag("GameController").GetComponent<CaptureSystem>();
    }

    void Start()
    {
        health = maxHealth;
        meshRendererTop.material.EnableKeyword("_EMISSION");
        startColorTop = meshRendererTop.material.GetColor("_EmissionColor");
        startColorBottom = meshRendererBottom.material.GetColor("_EmissionColor");
    }

    void Reset()
    {
        health = maxHealth;
        isCapturedByPlayer = true;
    }

    IEnumerator Timer(GameObject target)
    {
        yield return new WaitForSeconds(2f);
        target.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && health > 0f)
        {
            if (enterEffect.activeInHierarchy)
            {
                enterEffect.SetActive(false);
            }
            enterEffect.SetActive(true);
            StartCoroutine(Timer(enterEffect));
            Destroy(other.gameObject);
            health -= damageRate;
            if (health <= 0f)
            {
                isCapturedByPlayer = false;
                health = 0f;
                cs.CheckCaptureStatus();
            }
        }
        if (other.tag == "Player" && health < maxHealth)
        {
            healParticles.SetActive(true);
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
            if (health >= maxHealth)
            {
                health = maxHealth;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            healParticles.SetActive(false);
        }
    }

    void Update()
    {
        rotatorTop.rotationSpeed = new Vector3(0f, Mathf.Lerp(0f, rotatorTop.rotationSpeedOriginal.y, health / maxHealth), 0f);
        rotatorBottom.rotationSpeed = new Vector3(0f, Mathf.Lerp(0f, rotatorBottom.rotationSpeedOriginal.y, health / maxHealth), 0f);
        meshRendererTop.material.SetColor("_EmissionColor", new Color(Mathf.Lerp(0f, startColorTop.r, health / maxHealth), Mathf.Lerp(0f, startColorTop.g, health / maxHealth), Mathf.Lerp(0f, startColorTop.b, health / maxHealth), 1f));
        meshRendererBottom.material.SetColor("_EmissionColor", new Color(Mathf.Lerp(0f, startColorBottom.r, health / maxHealth), Mathf.Lerp(0f, startColorBottom.g, health / maxHealth), Mathf.Lerp(0f, startColorBottom.b, health / maxHealth), 1f));

        if (LevelController.gameState == GameState.GameStart)
        {
            Reset();
        }
    }
}
