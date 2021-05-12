using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNpc : MonoBehaviour
{
    GameObject child;
    RaycastHit2D playerHit;
    public float distance;
    public LayerMask playerMask;
    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        playerHit = Physics2D.Raycast(transform.position, Vector2.right, distance, playerMask);
        if (playerHit.collider != null)
        {
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
    }
}
