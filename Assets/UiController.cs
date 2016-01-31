using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public float fade;
    public float fadeSpeed;

    public Text timerText;
    public Image startButton;
    public Image fullFade;

    private bool isActive;
    private LevelController levelController;
    private float fullFadeValue = 1f;
    private float fullFadeSpeed = 1f;

    void Awake()
    {
        levelController = GetComponent<LevelController>();
    }

    void Start()
    {
        StartCoroutine(FullFade());
    }

    void Update()
    {
        if (LevelController.gameState == GameState.Menu)
        {
            fade = Mathf.Clamp01(fade + fadeSpeed * Time.deltaTime);
            if (fade >= 1f)
            {
                isActive = true;

                startButton.raycastTarget = true;
            }
        }
        else
        {
            fade = Mathf.Clamp01(fade - fadeSpeed * Time.deltaTime);
            if (fade <= 0f)
            {
                isActive = false;

                startButton.raycastTarget = false;
            }
        }

        timerText.color = new Color(timerText.color.r, timerText.color.b, timerText.color.g, 1 - fade);
        timerText.text = levelController.levelTimeCurrent.ToString("000.00");
        startButton.color = new Color(startButton.color.r, startButton.color.b, startButton.color.g, fade);
    }

    IEnumerator FullFade(int levelIndex)
    {
        while (true)
        {
            if (fullFadeValue >= 1f)
            {
                break;
            }

            fullFade.color = new Color(0f, 0f, 0f, fullFadeValue);
            fullFadeValue += fullFadeSpeed * Time.deltaTime;
            yield return null;
        }
        if (levelIndex == -1)
        {
            Application.Quit();
        }
        else if (levelIndex >= 0)
        {
            Application.LoadLevel(levelIndex);
        }
    }

    IEnumerator FullFade()
    {
        while (true)
        {
            if (fullFadeValue <= 0f)
            {
                break;
            }

            fullFade.color = new Color(0f, 0f, 0f, fullFadeValue);
            fullFadeValue -= fullFadeSpeed* Time.deltaTime;
            yield return null;
        }
    }

    public void StartGame()
    {
        LevelController.gameState = GameState.GameStart;
    }

    public void QuitGame()
    {
        StartCoroutine(FullFade(-1));
    }
}
