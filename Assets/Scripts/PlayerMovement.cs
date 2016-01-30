﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public Transform resetPosition;
    public Transform moveTarget;
    public float moveTargetCompleteDistance;
    public float moveSpeed;

    void Update()
    {
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

            if (Vector3.Distance(transform.position, moveTarget.position) > moveTargetCompleteDistance)
            {
                transform.LookAt(moveTarget);
                transform.Translate(transform.forward * moveSpeed, Space.World);
            }
        }
    }
}
