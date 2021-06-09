using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void Jugar()
    {
        Debug.Log ("Cargando Escena");
        SceneManager.LoadScene("Main Scene");
    }

    public void Salir()
    {
        Debug.Log ("Saliendo");
        Application.Quit();
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
