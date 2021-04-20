using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackArea : MonoBehaviour
{
    List<Collider2D> attackHits;
    BoxCollider2D playerCollider;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(name + " Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit " + collision.name);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        Debug.Log("Collision stayed");
    }
}
