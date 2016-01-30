using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

    GameObject Player;
    enum state {moving, attacking};
    public int Damage = 10;
    public float Speed = 10.0f;
    int ST;

	void Start () 
    {
        Player = GameObject.Find("Player");
	}
    
    void Update ()
    {
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);

        var distance = Vector3.Distance(transform.position, Player.transform.position);

    }
    IEnumerator attacking(int damage)
    {
        yield return new WaitForSeconds(1.0f);
    }

}
