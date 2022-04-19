using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiaEscena : MonoBehaviour
{

    public GameObject funciones;
    public string _nuevojuegonivel;//Objeto donde ponemos la script

    public void cambiar()
    {
    
    SceneManager.LoadScene(_nuevojuegonivel);
        funciones.GetComponent<guardarpersonaje>().Guardar();
    }
}
