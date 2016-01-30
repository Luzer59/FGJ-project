using UnityEngine;
using System.Collections;

public enum GameState { Menu, GameStart, GamePlay, GameEnd }

public class LevelController : MonoBehaviour
{  
    public static GameState gameState;
    public static int killCount;

    public float levelTimeStart;
    public float levelTimeCurrent;

    void Update()
    {
        MenuInput();

        if (gameState == GameState.GameStart)
        {
            levelTimeCurrent = levelTimeStart;
        }
        else if (gameState == GameState.GamePlay && levelTimeCurrent > 0f)
        {
            levelTimeCurrent -= Time.deltaTime;
            if (levelTimeCurrent <= 0f)
            {
                levelTimeCurrent = 0f;
                gameState = GameState.GameEnd;
                PlayerWin();
            }
        }
    }

    void PlayerWin()
    {

    }

    void MenuInput()
    {
        switch (gameState)
        {
            case GameState.Menu:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameState = GameState.GameStart; 
                }
                break;

            case GameState.GamePlay:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameState = GameState.GameEnd;
                }
                break;

            default:
                break;
        }
    }
}
