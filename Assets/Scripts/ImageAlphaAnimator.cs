using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageAlphaAnimator : MonoBehaviour {
	public float animationSpeed = 0.11f;
	private Image imgComponent;
	
	// Use this for initialization
	void Start () {
		imgComponent = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		Color old = imgComponent.color;
		imgComponent.color = new Color( old.r, old.g, old.b, old.a + animationSpeed * Time.deltaTime );
		
		if( imgComponent.color.a > 0.9f || imgComponent.color.a < 0.5f) {
			animationSpeed *= -1f;
		}
	}
}
