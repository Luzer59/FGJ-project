using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class CaptureSystem : MonoBehaviour
{
    public float maxHealth;
    public List<CaptureParameters> activeZoneList = new List<CaptureParameters> { };
    public bool gameOver = false;
    public Text gameOverText;

    private float fade;
    private float fadeSpeed = 1f;

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
            StartCoroutine(EndTimer());
        }
    }

    void Update()
    {
        if (gameOver)
        {
            fade = Mathf.Clamp01(fade + fadeSpeed * Time.deltaTime);

            gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.b, gameOverText.color.g, fade);
        }
        else
        {
            fade = Mathf.Clamp01(fade - fadeSpeed * Time.deltaTime);

            gameOverText.color = new Color(gameOverText.color.r, gameOverText.color.b, gameOverText.color.g, fade);
        }
    }

    IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(3f);
        gameOver = false;
        LevelController.gameState = GameState.GameEnd;
    }
}
