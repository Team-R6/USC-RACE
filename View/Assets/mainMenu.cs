using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
 public void LoadScene(string Escena2)
  {
    SceneManager.LoadScene(Escena2);
  }
   public void EscenaJuego2()
  {
    SceneManager.LoadScene(3);
  }

  public void salir()
  {
    Application.Quit();
  }
}
