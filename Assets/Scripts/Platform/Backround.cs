using System.Collections;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float toggleInterval = 1f;  
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ToggleVisibility());
    }

    private IEnumerator ToggleVisibility()
    {
        while (true)
        {
            yield return new WaitForSeconds(toggleInterval);  
            spriteRenderer.enabled = !spriteRenderer.enabled;  
        }
    }
}
