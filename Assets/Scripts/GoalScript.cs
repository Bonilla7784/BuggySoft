using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{
    public bool playerInside;
    GameObject promptObject;
    // Start is called before the first frame update
    void Start()
    {
        playerInside = false;
        promptObject = transform.GetChild(0).gameObject;
        promptObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInside = true;
            PlayerScript playerScript = collision.gameObject.GetComponent<PlayerScript>();
            if (playerScript.hasKey)
            {
                SceneManager.LoadScene("End Screen");
            }
            else
            {
                promptObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInside = false;
            promptObject.SetActive(false);
        }
    }
}
