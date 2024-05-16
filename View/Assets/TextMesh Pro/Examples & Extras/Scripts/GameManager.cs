using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int index;
    public GameObject[] cars;

    void Start()
    {
        // Obtener el índice del PlayerPrefs
        index = PlayerPrefs.GetInt("carIndex", 0);

        // Asegurarse de que el índice esté dentro del rango válido
        if (index < 0 || index >= cars.Length)
        {
            // Ajustar el índice al más cercano dentro del rango válido
            index = Mathf.Clamp(index, 0, cars.Length - 1);
            Debug.LogWarning("Índice de auto fuera de rango, ajustado a " + index);
        }

        // Instanciar el auto correspondiente al índice
        GameObject car = Instantiate(cars[index+1], Vector3.zero, Quaternion.identity);
    }
}

