using UnityEngine;
using System.Collections.Generic;

public class CaptureSystem : MonoBehaviour
{
    public float maxHealth;
    public List<CaptureParameters> activeZoneList = new List<CaptureParameters> { };
    public bool gameOver = false;

    public void CheckCaptureStatus()
    {
        gameOver = true;

        for (int i = 0; i < activeZoneList.Count; i++)
        {
            if (activeZoneList[i].isCapturedByPlayer)
                gameOver = false;
        }
        if (gameOver)
        {
            LevelController.gameState = GameState.GameEnd;
        }
    }
}
