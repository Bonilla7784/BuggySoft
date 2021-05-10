using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    public PlayerScript playerScript;
    public GameObject heartPrefab;
    // Start is called before the first frame update
    void Start()
    {
        FillHearts(playerScript.health);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.health > transform.childCount)
        {
            AddHearts(playerScript.health - transform.childCount);
        }
        else if (playerScript.health < transform.childCount)
        {
            RemoveHearts(transform.childCount - playerScript.health);
        }
    }

    void FillHearts(int hearts = 0)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < hearts; i++)
        {
            Instantiate(heartPrefab, transform);
        }
    }
    
    void AddHearts(int hearts = 1)
    {
        for (int i = 0; i < hearts; i++)
        {
            Instantiate(heartPrefab, transform);
        }
    }

    void RemoveHearts(int hearts = 1)
    {
        for (int i = 0; i < hearts; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
