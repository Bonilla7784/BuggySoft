using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class KeyHolderScript : MonoBehaviour
{
    public GameObject keyPrefab;
    GameObject keyObject;
    AIDestinationSetter keyTargetScript;
    // Start is called before the first frame update
    void Start()
    {
        keyObject = Instantiate(keyPrefab, transform.position, Quaternion.Euler(0f,0f,0f));
        keyTargetScript = keyObject.GetComponent<AIDestinationSetter>();
        keyTargetScript.target = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackHit()
    {
        PlayerScript playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        playerScript.hasKey = true;
        keyTargetScript.target = GameObject.FindGameObjectWithTag("Player Target").transform;
        Destroy(gameObject);
    }
}
