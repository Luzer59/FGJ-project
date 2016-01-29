using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {


	// Use this for initialization
    public Transform SpawnerTransform;
    public GameObject Enemy;
    public int spawnInterval = 10;
    public int startTime = 10;
	void Start () 
    {
        StartCoroutine(spawnEnemies(spawnInterval, startTime));
	}
	IEnumerator spawnEnemies(int spawnInterval, int startTime)
    {
        yield return new WaitForSeconds(startTime);
        Instantiate(Enemy, SpawnerTransform.position, SpawnerTransform.rotation);
        yield return new WaitForSeconds(spawnInterval);
    }

}
