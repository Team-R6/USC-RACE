using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MenuOpciones : MonoBehaviour
{
   [SerializeField] private AudioMixer audioMixer;
    void Start()
    {
       
        PantallaCompleta(true);
    }

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
    public void CambiarVolumen(float volumen)
    {
      audioMixer.SetFloat("Volumen", volumen);
    }
    public void SetQuality(int qualityIndex)
    {
      QualitySettings.SetQualityLevel(qualityIndex);
    }
}
