using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BARRA : MonoBehaviour
{
    public Scrollbar barradevida;
    public float daño;
    float vida = 1;
 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barradevida.size = vida;
        if (vida <= 0)
        {
            Time.timeScale = 0f;
            GameOver.gamerover.callGamerOver();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            vida -= daño;
        }
    }
}
