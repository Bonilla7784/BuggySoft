using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D collider2d;

    //private State state;
    public AIPath aiPath;
    private object pathfindingMovement;

    /*private enum State
    {
        Roaming,
        ChaseTarget,
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);

        } else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

  /*  private void FixedUpdate()
    {
        switch (state)
        {
            case State.ChaseTarget:
                pathfindingMovement.MoveToTimer(PlayerPrefs.Instance.GetPosition());
                break;
        }
    }
  */
}