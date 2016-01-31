using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum GameState { Menu, GameStart, GamePlay, GameEnd }

public class LevelController : MonoBehaviour
{  
    public static GameState gameState;
    public static int killCount;

    public GameState gameStateDisplay;
    public float levelTimeStart;
    public float levelTimeCurrent;
    public Text winText;
    public GameObject helpProjector;
    public Image fullFade;
    public Sprite fadeImage;

    private bool gameOver = false;
    private float fade;
    private float fadeSpeed = 1f;
    private bool isHelpVisible = false;

    void Start()
    {
        gameState = gameStateDisplay;
    }

    void Update()
    {
        MenuInput();

        if (gameState == GameState.GameStart)
        {
            levelTimeCurrent = levelTimeStart;
            if (!isHelpVisible)
            {
                isHelpVisible = true;
                StartCoroutine(HelpProjectorFade());
            }
        }
        else if (gameState == GameState.GamePlay && levelTimeCurrent > 0f)
        {
            levelTimeCurrent -= Time.deltaTime;
            if (levelTimeCurrent <= 0f)
            {
                levelTimeCurrent = 0f;
                gameOver = true;
                StartCoroutine(PlayerWin());
            }
        }
        if (gameOver)
        {
            fade = Mathf.Clamp01(fade + fadeSpeed * Time.deltaTime);

            winText.color = new Color(winText.color.r, winText.color.b, winText.color.g, fade);
        }
        else
        {
            fade = Mathf.Clamp01(fade - fadeSpeed * Time.deltaTime);

            winText.color = new Color(winText.color.r, winText.color.b, winText.color.g, fade);
        }
    }

    IEnumerator HelpProjectorFade()
    {
        yield return new WaitForSeconds(3f);
        helpProjector.SetActive(true);
        yield return new WaitForSeconds(15f);
        helpProjector.SetActive(false);
        isHelpVisible = false;
    }

    IEnumerator PlayerWin()
    {
        fullFade.sprite = fadeImage;
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
        gameState = GameState.GameEnd;
    }

    void MenuInput()
    {
        switch (gameState)
        {
            /*case GameState.Menu:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameState = GameState.GameStart; 
                }
                break;*/

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
