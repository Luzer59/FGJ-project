using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    public float fade;
    public float fadeSpeed;

    public Text timerText;
    public MeshRenderer startButton;
    public MeshRenderer quitButton;
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
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000f, 1 << 12))
            {
                if (hit.transform.name == "Start")
                {
                    StartGame();
                }
                else if (hit.transform.name == "Quit")
                {
                    QuitGame();
                }
            }
        }

        if (LevelController.gameState == GameState.Menu)
        {
            fade = Mathf.Clamp01(fade + fadeSpeed * Time.deltaTime);
            if (fade >= 1f)
            {
                isActive = true;

                startButton.GetComponent<BoxCollider>().enabled = true;
                quitButton.GetComponent<BoxCollider>().enabled = true;
            }
        }
        else
        {
            fade = Mathf.Clamp01(fade - fadeSpeed * Time.deltaTime);
            if (fade <= 0f)
            {
                isActive = false;

                startButton.GetComponent<BoxCollider>().enabled = false;
                quitButton.GetComponent<BoxCollider>().enabled = false;
            }
        }

        timerText.color = new Color(timerText.color.r, timerText.color.b, timerText.color.g, 1 - fade);
        timerText.text = "Defend the Ritual\n" + levelController.levelTimeCurrent.ToString("000.00") + " s";
        startButton.material.color = new Color(startButton.material.color.r, startButton.material.color.b, startButton.material.color.g, fade);
        quitButton.material.color = new Color(quitButton.material.color.r, quitButton.material.color.b, quitButton.material.color.g, fade);
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
