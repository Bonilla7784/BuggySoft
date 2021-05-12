using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePrompt : MonoBehaviour
{
    RaycastHit2D playerhit;
    RaycastHit2D containerhit;
    SpriteRenderer spriteRenderer;
    public float distance = 1f;
    public LayerMask playerMask;
    public LayerMask containerMask;
    bool despawing;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        despawing = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerhit = Physics2D.Raycast(transform.position, Vector2.left, distance, playerMask);
        if (playerhit.collider == null) // Look right if there's no hit
        {
            playerhit = Physics2D.Raycast(transform.position, Vector2.right, distance, playerMask);
        }

        if (!despawing)
        {
            if (playerhit.collider != null)
            {
                spriteRenderer.enabled = true;
            }
            else
            {
                spriteRenderer.enabled = false;
            }
        }

        containerhit = Physics2D.Raycast(transform.position, Vector2.left, 0.5f, containerMask);
        if (containerhit.collider == null)
        {
            containerhit = Physics2D.Raycast(transform.position, Vector2.right, 0.5f, containerMask);
        }
        if (containerhit.collider == null)
        {
            StartCoroutine(Despawn());
        }
    }

    IEnumerator Despawn()
    {
        despawing = true;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
