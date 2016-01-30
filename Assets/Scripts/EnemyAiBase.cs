using UnityEngine;
using System.Collections.Generic;

public class EnemyAiBase : MonoBehaviour
{
    public float moveSpeed;
    public enum State { idle, moveTowardsPlayer, moveTowardsObjective, meleeAttack, rangedAttack }
    public State state;

    private CaptureSystem captureSystem;
    private Transform target;
    private Transform objective;

    void Awake()
    {
        captureSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<CaptureSystem>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        switch (state)
        {
            case State.idle:
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
                //List<>         
                if (!objective)
                {
                    for (int i = 0; i < captureSystem.capturezones.Length; i++)
                    {

                    }
                    //captureSystem.
                }
                transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
                transform.Translate(transform.forward * moveSpeed, Space.World);
                break;

            default:
                break;
        }
    }
}
