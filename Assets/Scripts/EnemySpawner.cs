using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public Transform SpawnerTransform;
    public GameObject Enemy;
    public int spawnInterval = 10;
    public int startTime = 10;

    private LevelController levelController;
    private bool active = false;

    void Awake()
    {
        levelController = GameObject.FindGameObjectWithTag("GameController").GetComponent<LevelController>();
    }

    void Update()
    {
        if (LevelController.gameState == GameState.GamePlay && !active)
        {
            active = true;
            StartCoroutine(spawnEnemies(spawnInterval, startTime));
        }
    }

    IEnumerator spawnEnemies(int spawnInterval, int startTime)
    {
        yield return new WaitForSeconds(startTime);
        while (true)
        {
            Instantiate(Enemy, SpawnerTransform.position, SpawnerTransform.rotation);
            if (LevelController.gameState != GameState.GamePlay)
            {
                active = false;
                break;
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

}
