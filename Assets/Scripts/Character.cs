using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Animator MyAnimator { get; set; }

    [SerializeField]
    protected float movementSpeed;

    protected bool facingRight;

    public bool Attack { get; set; }

    [SerializeField]
    private EdgeCollider2D SwordCollider;

    [SerializeField]
    private List<string> damageSources;
    [SerializeField]
    protected int health;

    public abstract bool isDead { get; }

    // Start is called before the first frame update
    public virtual void Start()
    {
        facingRight = false;

        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeDirection()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y * 1, 1);
    }

    public void MeleeAttack()
    {
        SwordCollider.enabled = !SwordCollider.enabled;
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (damageSources.Contains(other.tag))
        {
            StartCoroutine(TakeDamage());
        }
    }

    public abstract IEnumerator TakeDamage();
}