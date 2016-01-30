﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public Transform playPosition;
    public Transform menuPosition;
    public Vector3 menuSway;
    public float lerpSpeed;

    private GameState thisState;
    private float lerpValue = 0;
    private LevelController levelController;

    void Awake()
    {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    void Update()
    {
        float t = lerpValue;
        switch (LevelController.gameState)
        {
            case GameState.GameStart:
                lerpValue += lerpSpeed * Time.deltaTime;
                if (lerpValue >= 1f)
                {
                    lerpValue = 1f;
                    LevelController.gameState = GameState.GamePlay;
                }
                break;

            case GameState.GameEnd:
                lerpValue += -1f * lerpSpeed * Time.deltaTime;
                if (lerpValue <= 0f)
                {
                    lerpValue = 0f;
                    LevelController.gameState = GameState.Menu;
                }
                break;

            default:
                break;
        }
        transform.position = Vector3.Lerp(menuPosition.position, playPosition.position, t * t * t * (t * (6f * t - 15f) + 10f));
        transform.rotation = Quaternion.Slerp(menuPosition.rotation, playPosition.rotation, t * t * t * (t * (6f * t - 15f) + 10f));
    }
}
