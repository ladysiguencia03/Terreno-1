using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class subOption : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider volumeSlider;
    [SerializeField]
    private Text resolutionText;


    private int resolutionIndex;
    //Colocar resoluciones disponibles
    private int[] resolutionWidth = { 1920, 1280, 640 };
    private int[] resolutionHeight = { 1080, 720, 360 };
    private subMenu submenu;
   void Start()
    {
        submenu = FindObjectOfType<subMenu>();
     
        volumeSlider.value = submenu.GetVolume();
        int actualResWidth = submenu.GetResolutionWidth();
        for (int i = 0; i < resolutionWidth.Length; i++)
        {
            if (resolutionWidth[i] == actualResWidth)
            {
                resolutionIndex = i;
            }

        }
        RefreshResolutionText();
    }

    // Update is called once per frame
    void Update()
    {
        
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
            resolutionIndex = resolutionWidth.Length - 1;
        }
        RefreshResolutionText();
    }

    private void RefreshResolutionText()
    {
        resolutionText.text = resolutionWidth[resolutionIndex].ToString() + "x" + resolutionHeight[resolutionIndex].ToString();
    }


    public void ApplyChanges()
    {
        submenu.SetResolution(resolutionWidth[resolutionIndex], resolutionHeight[resolutionIndex]);
        submenu.SetVolume(volumeSlider.value);


    }
}
