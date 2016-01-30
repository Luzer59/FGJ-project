using UnityEngine;
using System.Collections;

public class SkillWater1 : MonoBehaviour
{
    public Vector2 iceFieldScaleLimits;
    public Vector2 iceMeshScaleLimits;
    public float lerpScaleSpeed;

    private Projector iceFieldProjection;
    private float lerpScale = 0f;
    private bool state = true;

    void Awake()
    {
        iceFieldProjection = GetComponentInChildren<Projector>();
    }

    void Start()
    {
        StartCoroutine(Shrink());
    }

    void Update()
    {
        if (lerpScale < 1f && state)
        {
            iceFieldProjection.orthographicSize = Mathf.Lerp(iceFieldScaleLimits.x, iceFieldScaleLimits.y, lerpScale);
            float newScale = Mathf.Lerp(iceMeshScaleLimits.x, iceMeshScaleLimits.y, lerpScale);
            transform.localScale = new Vector3(newScale, newScale, newScale);

            lerpScale += lerpScaleSpeed * Time.deltaTime;
        }

        if (!state)
        {
            iceFieldProjection.orthographicSize = Mathf.Lerp(iceFieldScaleLimits.x, iceFieldScaleLimits.y, lerpScale);
            float newScale = Mathf.Lerp(iceMeshScaleLimits.x, iceMeshScaleLimits.y, lerpScale);
            transform.localScale = new Vector3(newScale, newScale, newScale);

            lerpScale -= lerpScaleSpeed * 1.5f * Time.deltaTime;
            if (lerpScale < 0f)
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Shrink()
    {
        yield return new WaitForSeconds(3f);
        state = false;
    }
}
