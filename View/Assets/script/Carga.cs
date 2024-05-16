using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Carga : MonoBehaviour{
    public GameObject image;
    public Image Loading;

    public void LoadScene(int sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync (int sceneName){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        image.SetActive(true);

        while(!operation.isDone){
            
            float progressValue = Mathf.Clamp01(operation.progress /0.9f);

            Loading.fillAmount = progressValue;
 
            yield return null;
        }
    }
}




