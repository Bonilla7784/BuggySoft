using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpSpeed;
    [SerializeField]
    LayerMask floormask;
    [SerializeField]
    LayerMask playerMask;
    [SerializeField]
    AudioClip jumpSound;
    [SerializeField]
    AudioClip attackSound;
    [SerializeField]
    AudioClip hurtSound;
    [SerializeField]
    GameObject blackScreen;
    [SerializeField]
    ParticleSystem walkDust;

    Rigidbody2D rb2d;
    BoxCollider2D collider2d;
    Animator animController;
    SpriteRenderer spriteRender;
    AudioSource audioSrc;
    float inputX, inputY;
    Vector2 inputVector;
    RaycastHit2D floor;
    readonly float yoffset = 0.1f;
    bool jumpProcessing = false, attackProcessing = false;
    public bool isMoving = false, isGrounded = false, facingRight = true;
    Collider2D[] hits;
    public int health = 3;
    public Vector3 spawnPoint;
    bool immune = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<BoxCollider2D>();
        animController = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        audioSrc = GetComponent<AudioSource>();
        health = 3;
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        
        spriteRender.flipX = !facingRight;
        animController.SetBool("isMoving", isMoving);
        animController.SetBool("isGrounded", isGrounded);

        if (isMoving && isGrounded)
            walkDust.Play();
        
        inputVector = new Vector2(inputX, inputY);

    }

    void FixedUpdate()
    {

        rb2d.velocity = inputVector;
        if (jumpProcessing)
            audioSrc.PlayOneShot(jumpSound, 0.8f);
        jumpProcessing = false;
        HandleAttack();
    }

    bool IsGrounded()
    {
        floor = Physics2D.BoxCast(collider2d.bounds.center, collider2d.bounds.size, 0f, Vector2.down, yoffset, floormask);
        if (floor.collider != null)
        {
            Debug.DrawRay(new Vector3(collider2d.bounds.center.x - collider2d.bounds.extents.x, collider2d.bounds.center.y - (collider2d.bounds.extents.y + yoffset), 0), Vector3.right * collider2d.bounds.size.x, Color.green);
        }
        else
        {
            Debug.DrawRay(new Vector3(collider2d.bounds.center.x - collider2d.bounds.extents.x, collider2d.bounds.center.y - (collider2d.bounds.extents.y + yoffset), 0), Vector3.right * collider2d.bounds.size.x, Color.red);
        }
        return floor.collider != null;
    }
    void HandleAttack()
    {
        if (attackProcessing)
        {
            animController.SetTrigger("Attack");
            audioSrc.PlayOneShot(attackSound);
            if (facingRight)
            {
                hits = Physics2D.OverlapBoxAll(transform.position + new Vector3(1f, 1.9f, 0f), new Vector2(4f, 3.5f), 0f, ~playerMask);
            }
            else
            {
                hits = Physics2D.OverlapBoxAll(transform.position + new Vector3(-1f, 1.9f, 0f), new Vector2(4f, 3.5f), 0f, ~playerMask);
            }
            foreach (Collider2D hit in hits)
            {
                Debug.Log("Hit " + hit.name);
                if (hit.CompareTag("Destructible"))
                {
                    Debug.Log("Destroyed " + hit.name);
                    hit.gameObject.GetComponent<BreakableBox>().PublicBreak();
                }
            }
        }
        attackProcessing = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (facingRight)
        {
            Gizmos.DrawWireCube(transform.position + new Vector3(1f, 1.9f, 0f), new Vector2(4f, 3.5f));
        }
        else
        {
            Gizmos.DrawWireCube(transform.position + new Vector3(-1f, 1.9f, 0f), new Vector2(4f, 3.5f));
        }
    }

    void GetInput()
    {

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            inputX = moveSpeed;
            facingRight = true;
            isMoving = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            inputX = -moveSpeed;
            facingRight = false;
            isMoving = true;
        }
        else
        {
            inputX = 0f;
            isMoving = false;
        }

        isGrounded = IsGrounded();
        if (jumpProcessing || Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpProcessing = true;
            inputY = jumpSpeed;
        }
        else
        {
            inputY = rb2d.velocity.y;
        }

        if (Input.GetButtonDown("Fire1") || attackProcessing)
        {
            attackProcessing = true;
        }
    }

    public void Kill()
    {
        transform.position = spawnPoint;
        rb2d.velocity = Vector2.zero;
        immune = false;
        Hurt(1);
    }

    public void Hurt(int damage = 1)
    {
        if (!immune)
        {
            audioSrc.PlayOneShot(hurtSound, 0.8f);
            if (health - damage > 0)
            {
                health -= damage;
                StartCoroutine(FlickerImmunity(3f));
            }
            else
            {
                health = 0;
                blackScreen.SetActive(true);
                StartCoroutine(GameOver());
            }
        }
    }

    IEnumerator GameOver()
    {
        immune = true;
        yield return new WaitForEndOfFrame();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");

    }

    IEnumerator FlickerImmunity(float seconds = 3f)
    {
        immune = true;
        for (;seconds > 0f; seconds -= 0.2f)
        {
            spriteRender.enabled = false;
            yield return new WaitForSeconds(0.1f);
            spriteRender.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        immune = false;
    }

    public void GiveHealth(int quantity = 1)
    {
        health += quantity;
    }

}
