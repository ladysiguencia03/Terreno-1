using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject GamerOver;
    public static GameOver gamerover;


    void Start()
    {
        gamerover = this;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void callGamerOver()
    {
        GamerOver.SetActive(true);
        
    }
    public void Reiniciar()
    {

    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
