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
    public Image fullFade;
    public Sprite fadeImage;

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
        fullFade.sprite = fadeImage;
        fullFade.color = Color.white;
        float tempFade = 0f;
        while (true)
        {
            tempFade += Time.deltaTime;
            fullFade.color = new Color(fullFade.color.r, fullFade.color.b, fullFade.color.g, tempFade);
            if (tempFade >= 1f)
                break;
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        while (true)
        {
            tempFade -= Time.deltaTime;
            fullFade.color = new Color(fullFade.color.r, fullFade.color.b, fullFade.color.g, tempFade);
            if (tempFade <= 0f)
                break;
            yield return null;
        }
        gameOver = false;
        LevelController.gameState = GameState.GameEnd;
    }
}
