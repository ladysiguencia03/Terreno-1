using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
    

    private bool menuActivated;

    private bool gamePaused;

    private ControlInterfaz interfaz;

    [SerializeField]
    private GameObject characterPrefab;
    [SerializeField]
    private GameObject characterInitialPosition;

    private GameObject characterInstance;
   
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;

    private AudioSource[] audioSources;

    private float generalVolume;
    private float defaultVolume=0.75f;

    private int resWidth;
    private int resHeight;
    private int defResWidth=1920;
    private int defResHeight=1080;


    public void Start()
    {

        interfaz = FindObjectOfType<ControlInterfaz>();
        characterInstance = Instantiate(characterPrefab, characterInitialPosition.transform.position, Quaternion.identity);
        firstPersonController = characterInstance.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        gamePaused = false;

        audioSources = FindObjectsOfType<AudioSource>();

        DeactivateMenu();

        LoadData();

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (menuActivated)
            {
                DeactivateMenu();
            }
            else
            {
                ActivateMenu();
            }
        }
        
    }

    private void ActivateMenu()
    {
        menuActivated = true;
        interfaz.SetMenuState(true);

        firstPersonController.SetCursorLock(false);

        firstPersonController.enabled = false;
      
    }

    private void DeactivateMenu()
    {
        menuActivated = false;
        interfaz.SetMenuState(false);

        firstPersonController.enabled = true;

        firstPersonController.SetCursorLock(true);
    }

    public void SetVolume(float v)
    {
        generalVolume = v;
        foreach (AudioSource a in audioSources)
        {
            a.volume = v;
        }
        SaveVolumeData();
    }

    public void SetResolution(int w,int h)
    {
        resWidth = w;
        resHeight = h;
        Screen.SetResolution(w, h, true);
        SaveResolutionData();
    }

    public void Reanudar()
    {
        DeactivateMenu();
    }

    public void Salir()
    {
        SceneManager.LoadScene("menu");
    }

    public bool IsGamePaused()
    {
        return gamePaused;
    }

    private void PauseGame()
    {
        gamePaused = true;
    }

    private void UnpauseGame()
    {
        gamePaused = false;
    }

    public float GetVolume()
    {
        return generalVolume;
    }

    public int GetResolutionWidth()
    {
        return resWidth;
    }

    private void LoadData()
    {
        LoadVolumeData();
        LoadResolutionData();
    }

    private void SaveVolumeData()
    {
        PlayerPrefs.SetFloat("volume", generalVolume);
    }

    private void LoadVolumeData()
    {
        if(PlayerPrefs.HasKey("volume")){
            generalVolume = PlayerPrefs.GetFloat("volume");

        }
        else
        {
            generalVolume = defaultVolume;
            
        }

        SetVolume(generalVolume);
    }

    private void SaveResolutionData()
    {
        PlayerPrefs.SetInt("resH", resHeight);
        PlayerPrefs.SetInt("resW", resWidth);

    }

    private void LoadResolutionData()
    {
        if (PlayerPrefs.HasKey("resH"))
        {
            resHeight = PlayerPrefs.GetInt("resH");
            resWidth = PlayerPrefs.GetInt("resW");

        }
        else
        {
            resHeight = defResHeight;
            resWidth = defResWidth;
            SaveResolutionData();
        }

        SetResolution(resWidth, resHeight);
    }

   

}
