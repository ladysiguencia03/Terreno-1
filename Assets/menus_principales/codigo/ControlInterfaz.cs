using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInterfaz : MonoBehaviour
{
    

    [SerializeField]
    private GameObject menuObject;

    public void SetMenuState(bool s)
    {
        if (s)
        {
            menuObject.SetActive(true);
        }
        else
        {
            menuObject.SetActive(false);
        }
    }

}
