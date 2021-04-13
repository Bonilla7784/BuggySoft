using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Jugar()
    {
        Debug.Log ("Cargando Escena");
        SceneManager.LoadScene("Main Scene");
    }

    public void private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info) {
        {
            Debug.Log ("Saliendo");
            Application.Quit();
        }
    }
}
