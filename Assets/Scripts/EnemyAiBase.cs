using UnityEngine;
using System.Collections.Generic;

public class EnemyAiBase : MonoBehaviour
{
    public float moveSpeed;
    public enum State { idle, moveTowardsPlayer, moveTowardsObjective, meleeAttack, rangedAttack }
    public State state;

    private CaptureSystem captureSystem;
    private CaptureParameters captureParameters;
    private Transform target;
    private Transform objective;
    private int targetIndex;

    private Animator animator;
    private bool isAlreadyWalking = false;

    void Awake()
    {
        captureSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<CaptureSystem>();
    }

    void Start()
    {
        captureParameters = captureSystem.activeZoneList[Random.Range(0, captureSystem.activeZoneList.Count)];
        target = GameObject.FindGameObjectWithTag("Player").transform;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        switch (state)
        {
            case State.idle:
                StopWalking();

                break;

            case State.moveTowardsPlayer:
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                transform.Translate(transform.forward * moveSpeed, Space.World);
                break;

            case State.meleeAttack:
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                //attack code
                break;

            case State.moveTowardsObjective:   
                if (captureParameters.isCapturedByPlayer == false)
                {
                    captureParameters = captureSystem.activeZoneList[Random.Range(0, captureSystem.activeZoneList.Count)];
                }

                transform.LookAt(new Vector3(captureParameters.transform.position.x, transform.position.y, captureParameters.transform.position.z));
                transform.Translate(transform.forward * moveSpeed, Space.World);
                break;

            default:
                break;
        }

    }

    private void WalkCheckForAnimator()
    {
        if (isAlreadyWalking)
            return;
        else
        {
            animator.SetBool("isWalking", true);
            isAlreadyWalking = true;
        }
    }

    private void StopWalking()
    {
        animator.SetTrigger("StopWalking");
        isAlreadyWalking = false;
        animator.SetBool("isWalking", false);
    }
}
