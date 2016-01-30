using UnityEngine;
using System.Collections;

public class ObjectRotator : MonoBehaviour {

    public Vector3 rotationSpeed = new Vector3( 1.0f, 0.0f, 0.0f );

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
	}

}
