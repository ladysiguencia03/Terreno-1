using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargarpersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cuboPersonaje;
    public GameObject clasulaPersonaje;
    public GameObject cilindroPersonaje;

    public bool cubo;
    public bool clasula;
    public bool cilindro;

    private void Update()
    {
        cubo = PlayerPrefs.GetInt("cuboSelect") == 1;
        clasula = PlayerPrefs.GetInt("clasulaSelect") == 1;
        cilindro = PlayerPrefs.GetInt("cilindroSelect") == 1;

        if (cubo == true)
        {
            cuboPersonaje.SetActive(true);
            Destroy(clasulaPersonaje);
            Destroy(cilindroPersonaje);
        }

        if (clasula == true)
        {
            clasulaPersonaje.SetActive(true);
            Destroy(cuboPersonaje);
            Destroy(cilindroPersonaje);
        }

        if (cilindro == true)
        {
            cilindroPersonaje.SetActive(true);
            Destroy(clasulaPersonaje);
            Destroy(cuboPersonaje);
        }
    }
}
