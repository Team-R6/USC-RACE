using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPausa : MonoBehaviour
{
   public GameObject PausePanel;

   void Update()
   {    
    if (Input.GetKeyDown(KeyCode.Space))
       {
           Pause();
       }
   }
   public void Pause()
   {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
   }

   public void Continue()
   {
    PausePanel.SetActive(false);
    Time.timeScale = 1;
   }
   
   public void Reiniciar(int sceneIndex = 2)
   
    {
        SceneManager.LoadScene(sceneIndex);
        Time.timeScale = 1; 
    }

   public void salir()
   {
    Application.Quit();
   }
}
