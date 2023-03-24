using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public GameObject[] figures;
    void Start()
    {
        NewFigure();
    }

    void Update()
    {
        
    }

    public void NewFigure()
    {
        Instantiate(figures[Random.Range(0, figures.Length)], transform.position, Quaternion.identity);
    }
}
