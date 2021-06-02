using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroTextScript : MonoBehaviour
{
    public float scrollingSpeed;
    public float maxYPos;
    public float secondsUntilPrompt;

    RectTransform scrollingTextTransform;
    GameObject enterPrompt;

    // Start is called before the first frame update
    void Start()
    {
        scrollingTextTransform = transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        enterPrompt = transform.GetChild(1).gameObject;
        enterPrompt.SetActive(false);
        StartCoroutine(ShowEnterPrompt(secondsUntilPrompt));
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollingTextTransform.localPosition.y < maxYPos)
        {
            scrollingTextTransform.localPosition += new Vector3(0f, scrollingSpeed, 0f) * Time.deltaTime;
        }

        if (Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene("Main Scene");
        }
    }

    IEnumerator ShowEnterPrompt(float seconds = 5)
    {
        yield return new WaitForSeconds(seconds);
        enterPrompt.SetActive(true);
    }
}
