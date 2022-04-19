using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class subMenu : MonoBehaviour

{
    [SerializeField]  public bool pause = false;
    [SerializeField] public GameObject menupause;
    private float generalVolume;
    private float defaultVolume = 0.75f;
    private AudioSource[] audioSources;
    private int resWidth;
    private int resHeight;
    private int defResWidth = 1920;
    private int defResHeight = 1080;
    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
            {
                Renaudir();

            }
            else
            {
                Pause();
            }

        }
    }
      public void Pause()
    {
        pause = true;
        Time.timeScale = 0f;
        menupause.SetActive(true);
    }
    public void Renaudir()
    {
        pause = false;
        Time.timeScale = 1f;
        menupause.SetActive(false);
    }
    public void Reiniciar()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

        public void Salir()
    {
        SceneManager.LoadScene("menu");
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

    public void SetResolution(int w, int h)
    {
        resWidth = w;
        resHeight = h;
        Screen.SetResolution(w, h, true);
        SaveResolutionData();
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
        if (PlayerPrefs.HasKey("volume"))
        {
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
