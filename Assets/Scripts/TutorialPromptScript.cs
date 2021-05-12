using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPromptScript : MonoBehaviour
{
    bool keyPressed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Prompt());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            keyPressed = true;
        }
    }

    IEnumerator Prompt()
    {
        yield return new WaitForSeconds(0.5f);
        keyPressed = false;
        yield return new WaitForSeconds(3f);
        while (!keyPressed)
        {
            yield return 0;
        }
        Destroy(gameObject);
    }
}
