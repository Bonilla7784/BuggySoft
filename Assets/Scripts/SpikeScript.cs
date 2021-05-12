using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hit(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Hit(collision.gameObject);
    }

    void Hit(GameObject playerObject)
    {
        if (playerObject.CompareTag("Player"))
        {
            playerObject.GetComponent<PlayerScript>().Hurt(1);
        }
    }
}
