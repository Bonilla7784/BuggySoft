using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseCanvas;
    public AudioSource bgmSource;
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (!pauseCanvas.enabled)
            {
                pauseCanvas.enabled = true;
                Time.timeScale = 0f;
                bgmSource.Pause();
            }
            else
            {
                pauseCanvas.enabled = false;
                Time.timeScale = 1f;
                bgmSource.Play();
            }
            Debug.Log("Pause Pressed");
        }
    }
}
