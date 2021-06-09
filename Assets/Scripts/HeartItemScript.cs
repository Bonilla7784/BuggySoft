using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItemScript : MonoBehaviour
{

    Pathfinding.AIDestinationSetter destinationScript;
    Transform playerTransform;
    AudioSource audioSrc;
    SpriteRenderer sprRenderer;
    Collider2D coll;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player Target").transform;
        destinationScript = GetComponent<Pathfinding.AIDestinationSetter>();
        destinationScript.target = playerTransform;
        audioSrc = GetComponent<AudioSource>();
        sprRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().GiveHealth(1);
            audioSrc.Play();
            StartCoroutine(Despawn(audioSrc.clip.length));
        }
    }

    IEnumerator Despawn(float seconds)
    {
        Destroy(rb2d);
        sprRenderer.enabled = false;
        coll.enabled = false;
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
