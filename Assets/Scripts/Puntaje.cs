using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntaje : MonoBehaviour
{
    public static int points = 0;
    void Start()
    {
        points = 0;
    }

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = points.ToString();
    }
}
