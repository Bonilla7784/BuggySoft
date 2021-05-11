using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public Canvas pauseCanvas;
    public GameObject pauseCanvasObject;
    public AudioSource bgmSource;
    public PlayerScript playerScript;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (pauseCanvasObject.activeSelf)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
            Debug.Log("Pause Pressed");
        }
    }

    public void Unpause()
    {
        pauseCanvasObject.SetActive(false);
        playerScript.enabled = true;
        Time.timeScale = 1f;
        bgmSource.Play();
    }

    public void Pause()
    {
        pauseCanvasObject.SetActive(true);
        playerScript.enabled = false;
        Time.timeScale = 0f;
        bgmSource.Pause();
    }
}
