using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlMPRIN : MonoBehaviour
{
    

       [Header("Volumen Ajuste")]
    [SerializeField] private TMP_Text Text_valor_sonido = null;
    [SerializeField] private Slider VolumenSlider = null;
    [SerializeField] private float defaultvolume = 1.0f;

    [Header("Ajuste de juego")]
    [SerializeField] private TMP_Text Control_sens_textvalue = null;
    [SerializeField] private Slider Control_sens_slider = null;
    [SerializeField] private int defaultSen = 4;
    public int mainControlSens = 4;

    [Header("toggles ajustes")]
    [SerializeField] private Toggle invertYtoggle = null;

    [Header("Grafico ajustes")]
    [SerializeField] private Slider Brillo_slider = null;
    [SerializeField] private TMP_Text brilloTextValue = null;
    [SerializeField] private float defaultBrillo = 1;

    [Space(10)]
    [SerializeField] private TMP_Dropdown CalidadDropdown;
    [SerializeField] private Toggle FullScreenToggle;


    private int _calidadLevel;
    private bool __fullscreen;
    private float _brilloLevel;

    [Header("confirmacion")]
    [SerializeField] private GameObject confirmationPrompt = null;


    [Header("niveles de carga")]
    public string _nuevojuegonivel;
    private string niveldeInicio;
    [SerializeField] private GameObject noSalvojuego_Game = null;

    [Header("resolucion Dropdowns")]
    public TMP_Dropdown resolucionDropdown;
    private Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolucionDropdown.ClearOptions();

        List<string> opcions = new List<string>();
        int ActualResolucion = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string opcion = resolutions[i].width + "x" + resolutions[i].height;
            opcions.Add(opcion);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                ActualResolucion = i;
            }
        }
        resolucionDropdown.AddOptions(opcions);
        resolucionDropdown.value = ActualResolucion;
        resolucionDropdown.RefreshShownValue();

    }

    public void SetResolucion(int resolucionIndex)
    {
        Resolution resolucion = resolutions[resolucionIndex];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
    public void nuevojuego_dialogo_si()
    {
        SceneManager.LoadScene(_nuevojuegonivel);

    }

    public void iniciando_juego_dialogo_si()
    {
        if (PlayerPrefs.HasKey("Salvado_nivel"))
        {
            niveldeInicio = PlayerPrefs.GetString("Salvado_nivel");
            SceneManager.LoadScene(niveldeInicio);
        }
        else
        {
            noSalvojuego_Game.SetActive(true);
        }
    }

    public void Salir_button()
    {
        
        Application.Quit();

    }

    public void SetVolumen(float volume)
    {
        AudioListener.volume = volume;
        Text_valor_sonido.text = volume.ToString("0.0");

    }
    public void Volumen_applicar()
    {
        PlayerPrefs.SetFloat("volumen_principal", AudioListener.volume);
        StartCoroutine(ConfirmacionBox());
    }

    public void SetControlSens(float sensibilidad)
    {
        mainControlSens = Mathf.RoundToInt(sensibilidad);
        Control_sens_textvalue.text = sensibilidad.ToString("0");

    }

    public void GamePlayApply()
    {
        if (invertYtoggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }
        PlayerPrefs.SetFloat("masterSen", mainControlSens);
        StartCoroutine(ConfirmacionBox());
    }

    public void SetBrillo(float brillo)
    {
        _brilloLevel = brillo;
        brilloTextValue.text = brillo.ToString("0.0");
    }

    public void SetFullscreen(bool fullscreen)
    {
        __fullscreen = fullscreen;
    }

    public void SetCalidad(int calidadIndex)
    {
        _calidadLevel = calidadIndex;
    }
    public void GraficoApply()
    {
        PlayerPrefs.SetFloat("masterBrillo", _brilloLevel);

        PlayerPrefs.SetInt("masterCalidad", _calidadLevel);
        QualitySettings.SetQualityLevel(_calidadLevel);

        PlayerPrefs.SetInt("masterFullscreen", (__fullscreen ? 1 : 0));
        Screen.fullScreen = __fullscreen;
        StartCoroutine(ConfirmacionBox());
    }
    public void ResetButton(string MenuType)
    {
        if (MenuType == "Grafico")
        {
            Brillo_slider.value = defaultBrillo;
            brilloTextValue.text = defaultBrillo.ToString("0.0");
            CalidadDropdown.value = 1;
            QualitySettings.SetQualityLevel(1);
            FullScreenToggle.isOn = false;
            Screen.fullScreen = false;
            Resolution ActualResolucion = Screen.currentResolution;
            Screen.SetResolution(ActualResolucion.width, ActualResolucion.height, Screen.fullScreen);
            resolucionDropdown.value = resolutions.Length;
            GraficoApply();


        }
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultvolume;
            VolumenSlider.value = defaultvolume;
            Text_valor_sonido.text = defaultvolume.ToString("0.0");
            Volumen_applicar();
        }
        if (MenuType == "Gameplay")
        {
            Control_sens_textvalue.text = defaultSen.ToString("0");
            Control_sens_slider.value = defaultSen;
            mainControlSens = defaultSen;
            invertYtoggle.isOn = false;
            GamePlayApply();
        }

    }
    public IEnumerator ConfirmacionBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        confirmationPrompt.SetActive(false);
    }
}
