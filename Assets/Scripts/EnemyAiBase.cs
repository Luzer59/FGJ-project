using UnityEngine;
using System.Collections;

public class EnemyAiBase : MonoBehaviour
{
    public float moveSpeed;
    public enum State { idle, moveTowardsPlayer, moveTowardsObjective, meleeAttack, rangedAttack }
    public State state;
    public int health;
    [HideInInspector]
    public int maxHealth;
    public ParticleSystem deatheffect;
    public float deathSpeed;
    public GameObject mesh;

    private CaptureSystem captureSystem;
    private CaptureParameters captureParameters;
    //private Transform target;
    private Transform objective;
    private int targetIndex;

    private Animator animator;
    private bool isAlreadyWalking = false;
    private LevelController levelController;
    private bool isDead = false;

    void Awake()
    {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
        captureSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<CaptureSystem>();
    }

    void Start()
    {
        captureParameters = captureSystem.activeZoneList[Random.Range(0, captureSystem.activeZoneList.Count)];
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        maxHealth = health;
        animator = GetComponent<Animator>();
        
    }

    IEnumerator SpawnEffectTimer()
    {
        yield return new WaitForSeconds(1f);
    }

    IEnumerator DeathEffectTimer()
    {
        isDead = true;
        float scale = 1f;
        deatheffect.Play();
        while (true)
        {
            scale -= deathSpeed * Time.deltaTime;
            mesh.transform.localScale = new Vector3(1f, scale, 1f);
            if (scale <= 0f)
                break;
            yield return null;
        }
        Destroy(gameObject);
    }

    void Update()
    {
        if (LevelController.gameState != GameState.GamePlay && state != State.idle)
        {
            state = State.idle;
        }
        else if (LevelController.gameState == GameState.GameEnd)
        {
            StartCoroutine(DeathEffectTimer());
        }

        switch (state)
        {
            case State.idle:
                StopWalking();

                break;

            /*case State.moveTowardsPlayer:
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                transform.Translate(transform.forward * moveSpeed, Space.World);
                break;

            case State.meleeAttack:
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                //attack code
                break;*/

            case State.moveTowardsObjective:
                if (!captureSystem.gameOver && !isDead)
                {
                    WalkCheckForAnimator();

                    while (true)
                    {
                        if (captureParameters.isCapturedByPlayer == false)
                        {
                            captureParameters = captureSystem.activeZoneList[Random.Range(0, captureSystem.activeZoneList.Count)];
                        }
                        else
                        {
                            break;
                        }
                    }
                    transform.LookAt(new Vector3(captureParameters.transform.position.x, transform.position.y, captureParameters.transform.position.z));
                    transform.Translate(transform.forward * moveSpeed * Time.deltaTime, Space.World);
                }   
                break;

            default:
                break;
        }

    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            LevelController.killCount++;
            StartCoroutine(DeathEffectTimer());
        }
    }

    private void WalkCheckForAnimator()
    {
        if (isAlreadyWalking)
            return;
        else
        {
            animator.SetTrigger("StartWalking");
            isAlreadyWalking = true;
        }
    }

    private void StopWalking()
    {
        animator.SetTrigger("StopWalking");
        isAlreadyWalking = false;
    }
}
