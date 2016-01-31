using UnityEngine;
using System.Collections;

public class MouseTutorialController : MonoBehaviour {

	public Projector projector;
	public GameObject particlesToShowOnDisable;

	public float animationSpeed = 1.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		projector.orthographicSize += animationSpeed * Time.deltaTime;
		
		if(projector.orthographicSize > 10f || projector.orthographicSize < 6f) {
			animationSpeed *= -1f;
		}
	
	
	}
	
	void OnTriggerEnter( Collider other) 
	{
		if(other.tag == "Player") {
			DisableMe();
		}
	
	}
	
	void DisableMe() 
	{
		GameObject.Instantiate(particlesToShowOnDisable, transform.position + new Vector3(0f,-6f,0f), transform.rotation);
		gameObject.SetActive(false);
	}
	
}
