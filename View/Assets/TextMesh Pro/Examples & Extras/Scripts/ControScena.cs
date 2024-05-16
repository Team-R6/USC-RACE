using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEscena : MonoBehaviour
{
   public void LoadScene(String sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
}
