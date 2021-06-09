using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private IEnemyState currentState;

    public bool isMoving = false;

    public GameObject Target { get; set; }

    [SerializeField]
    private float meleeRange;



    public bool InMeleeRange
    {
        get
        {
            if (Target != null)
            {
                return Vector2.Distance(transform.position, Target.transform.position) <= meleeRange;
            }

            return false;
        }
    }

    public override bool isDead
    {
        get
        {
            return health <= 0;
        }
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        MyAnimator.SetBool("isMoving", isMoving);

        currentState.Execute();

        LookAtTarget();
    }

    private void LookAtTarget()
    {
        if (Target != null)
        {
            float xDir = Target.transform.position.x - transform.position.x;

            if (xDir < 0 && facingRight || xDir > 0 && !facingRight)
            {
                ChangeDirection();
            }
        }
    }


    public void ChangeState(IEnemyState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }

        currentState = newState;

        currentState.Enter(this);
    }

    public void Move()
    {
        if (!Attack)
        {
            isMoving = true;

            transform.Translate(GetDirection() * movementSpeed * Time.deltaTime);
        }

    }

    public Vector2 GetDirection ()
    {
        return facingRight ? Vector2.right : Vector2.left;
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        currentState.OntriggerEnter(other);
    }

    public override IEnumerator TakeDamage()
    {
        health -= 10;

        if(!isDead)
        {
            MyAnimator.SetTrigger("Damage");
        }
        else
        {
            MyAnimator.SetTrigger("Die");
            yield return null;
        }
    }

}
