using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CargaPerfs : MonoBehaviour
{
    [Header("General Ajuste")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private ControlMPRIN controlimpr;


    [Header("Volumen Ajuste")]
    [SerializeField] private TMP_Text Text_valor_sonido = null;
    [SerializeField] private Slider VolumenSlider = null;

    [Header("Brillo ajuste")]
    [SerializeField] private Slider Brillo_slider = null;
    [SerializeField] private TMP_Text brilloTextValue = null;

    [Header("calidad level Ajuste")]
    [SerializeField] private TMP_Dropdown CalidadDropdown;

    [Header("Fullscreen ajuste")]
    [SerializeField] private Toggle FullScreenToggle;

    [Header("Sensibilidad Ajuste")]
    [SerializeField] private TMP_Text Control_sens_textvalue = null;
    [SerializeField] private Slider Control_sens_slider = null;

    [Header("invertir y ajuste")]
    [SerializeField] private Toggle invertYtoggle = null;

    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolumen"))
            {
                float localVolumen = PlayerPrefs.GetFloat("masterVolumen");

                Text_valor_sonido.text = localVolumen.ToString("0.0");
                VolumenSlider.value = localVolumen;
                AudioListener.volume = localVolumen;
            }
            else
            {
                controlimpr.ResetButton("Audio");
            }

            if (PlayerPrefs.HasKey("masterCalidad"))
            {
                int localCalidad = PlayerPrefs.GetInt("masterCalidad");
                CalidadDropdown.value = localCalidad;
                QualitySettings.SetQualityLevel(localCalidad);
            }

            if (PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");
                if (localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                    FullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    FullScreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("masterBrillo"))
            {
                float localBrillo = PlayerPrefs.GetFloat("masterBrillo");
                brilloTextValue.text = localBrillo.ToString("0.0");
                Brillo_slider.value = localBrillo;

            }
            if (PlayerPrefs.HasKey("masterSen"))
            {
                float localSens = PlayerPrefs.GetFloat("masterSen");
                Control_sens_textvalue.text = localSens.ToString("0");
                Control_sens_slider.value = localSens;
                controlimpr.mainControlSens = Mathf.RoundToInt(localSens);
            }
            if (PlayerPrefs.HasKey("masterInvertY"))
            {
                if (PlayerPrefs.GetInt("masterInvertY") == 1)
                {
                    invertYtoggle.isOn = true;

                }
                else
                {
                    invertYtoggle.isOn = false;
                }
            }
        }
    }
}
