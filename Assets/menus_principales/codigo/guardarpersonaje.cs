using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guardarpersonaje : MonoBehaviour
{
    public bool cubo;
    public bool clasula;
    public bool cilindro;

    private void Awake()
    {
        cubo = PlayerPrefs.GetInt("cuboSelect") == 1;
        clasula = PlayerPrefs.GetInt("clasulaSelect") == 1;
        cilindro = PlayerPrefs.GetInt("cilindroSelect") == 1;
    }

    private void Update()
    {
        if (cubo == false && clasula == false && cilindro == false)
        {
            cubo = true;
        }
    }

    public void PersonajeCubo()
    {
        cubo = true;
        clasula = false;
        cilindro = false;
        Guardar();
    }

    public void PersonajeClasula()
    {
        cubo = false;
        clasula = true;
        cilindro = false;
        Guardar();
    }

    public void PersonajeCilindro()
    {
        cubo = false;
        clasula = false;
        cilindro = true;
        Guardar();
    }

    public void Guardar()
    {
        PlayerPrefs.SetInt("cuboSelect", cubo ? 1 : 0);
        PlayerPrefs.SetInt("clasulaSelect", clasula ? 1 : 0);
        PlayerPrefs.SetInt("cilindroSelect", cilindro ? 1 : 0);
    }
}
