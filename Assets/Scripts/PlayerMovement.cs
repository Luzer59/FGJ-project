using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Transform resetPosition;
    public Transform moveTarget;
    public float moveTargetCompleteDistance;
    public float moveSpeed;
    public enum State { idle, move, attack }
    public State state = State.idle;
    public float attackLenght;

    private float attackTimer = 0f;
    private Animator animator;
    private State oldState = State.idle;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (attackTimer > 0f)
        {        
            attackTimer = Mathf.Clamp(attackTimer - Time.deltaTime, 0f, attackLenght);
        }
        else if (state == State.attack)
        {
            state = State.idle;
        }

        if (LevelController.gameState == GameState.GameStart)
        {
            moveTarget.position = resetPosition.position;
            if (Vector3.Distance(transform.position, moveTarget.position) > moveTargetCompleteDistance)
            {
                transform.LookAt(moveTarget);
                transform.Translate(transform.forward * moveSpeed, Space.World);
            }
        }

        if (LevelController.gameState == GameState.GamePlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    moveTarget.position = hit.point;
                }
            }

            moveTarget.position = new Vector3(moveTarget.position.x, transform.position.y, moveTarget.position.z);

            if (Vector3.Distance(transform.position, moveTarget.position) > moveTargetCompleteDistance && state != State.attack)
            {
                transform.LookAt(moveTarget);
                transform.Translate(transform.forward * moveSpeed, Space.World);
                state = State.move;
            }
            else if (state == State.move)
            {
                state = State.idle;
            }
        }
        StateMachine();
    }

    public void AttackStateActivation()
    {
        state = State.attack;
        attackTimer = attackLenght;
    }

    void StateMachine()
    {
        if (state != oldState)
        {
            switch (state)
            {
                case State.idle:
                    animator.SetTrigger("StopWalking");
                    break;

                case State.move:
                    animator.SetTrigger("StartWalking");
                    break;

                case State.attack:
                    animator.SetTrigger("Attack");
                    break;

                default:
                    break;
            }
            oldState = state;
        }   
    }
}
