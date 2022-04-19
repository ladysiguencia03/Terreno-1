using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMenu : MonoBehaviour
{
   

    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject optionsMenu;
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Text resolutionText; 


    private int resolutionIndex;
    //Colocar resoluciones disponibles
    private int[] resolutionWidth = {1920,1280,640};
    private int[] resolutionHeight ={1080,720 ,360};

    private ControlJuego controlJuego;

    void Start()
    {
        controlJuego = FindObjectOfType<ControlJuego>();
        ShowMainMenu();
        volumeSlider.value=controlJuego.GetVolume();
        int actualResWidth=controlJuego.GetResolutionWidth();
        for(int i = 0; i < resolutionWidth.Length; i++)
        {
            if (resolutionWidth[i] == actualResWidth)
            {
                resolutionIndex = i;
            }

        }
        RefreshResolutionText();

    }

    void Update()
    {
        
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void ShowOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ResolutionRightButton()
    {
       
        resolutionIndex++;
        if (resolutionIndex >= resolutionWidth.Length)
        {
            resolutionIndex = 0;
        }
        RefreshResolutionText();
    }

    public void ResolutionLeftButton()
    {
       
        resolutionIndex--;
        if (resolutionIndex < 0)
        {
            resolutionIndex = resolutionWidth.Length-1;
        }
        RefreshResolutionText();
    }

    private void RefreshResolutionText()
    {
        resolutionText.text = resolutionWidth[resolutionIndex].ToString() + "x" + resolutionHeight[resolutionIndex].ToString();
    }


    public void ApplyChanges()
    {
        controlJuego.SetResolution(resolutionWidth[resolutionIndex], resolutionHeight[resolutionIndex]);
        controlJuego.SetVolume(volumeSlider.value);


    }



}
