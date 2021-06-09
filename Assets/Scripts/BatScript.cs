using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BatScript : MonoBehaviour
{
    AIPath pathScript;
    SpriteRenderer spriterndr;
    KeyHolderScript keyholder;
    Vector3 startingPoint;
    Vector3 targetPoint;
    bool goingRight;
    public float aggroRadius;
    public LayerMask playerLayer;
    public float patrolDist = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startingPoint = transform.position;
        pathScript = GetComponent<AIPath>();
        spriterndr = GetComponent<SpriteRenderer>();
        goingRight = true;
        targetPoint = GetNewPos();
        pathScript.destination = targetPoint;
        keyholder = GetComponent<KeyHolderScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pathScript.reachedDestination)
        {
            goingRight = !goingRight;
            targetPoint = GetNewPos();
            pathScript.destination = targetPoint;
        }
    }

    Vector3 GetNewPos()
    {
        RaycastHit2D playerhit = Physics2D.CircleCast(startingPoint, aggroRadius, Vector2.zero, 0f, playerLayer);

        if (playerhit.collider != null)
        {
            return playerhit.transform.position + new Vector3(0f, 2f, 0f);
        }

        if (goingRight)
        {
            spriterndr.flipX = false;
            return startingPoint + new Vector3(patrolDist,0f,0f);
        }
        else
        {
            spriterndr.flipX = true;
            return startingPoint + new Vector3(-patrolDist, 0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Hurt();
        }
    }

    public void AttackHit()
    {
        if (keyholder != null)
        {
            keyholder.AttackHit();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
