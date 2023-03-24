using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Piezas : MonoBehaviour
{
    private float previousTime;
    private float fallTime = 1f;

    public Vector3 rotationPoint;

    [SerializeField] private Transform block1;
    [SerializeField] private Transform block2;
    [SerializeField] private Transform block3;
    [SerializeField] private Transform block4;

    private Bloques blocks;

    void Start()
    {
        blocks = FindObjectOfType<Bloques>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - previousTime > fallTime)
        {
            transform.position += new Vector3(0, -1, 0);
            if (!blocks.Limits(block1) || !blocks.Limits(block2) || !blocks.Limits(block3) || !blocks.Limits(block4))
            {
                transform.position -= new Vector3(0, -1, 0);

                blocks.AddToArray(block1);
                blocks.AddToArray(block2);
                blocks.AddToArray(block3);
                blocks.AddToArray(block4);

                blocks.CheckLines();

                this.enabled = false;
                if (!StateMachine.stopGame) FindObjectOfType<Generador>().NewFigure();
            }
            
            previousTime = Time.time;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!blocks.Limits(block1) || !blocks.Limits(block2) || !blocks.Limits(block3) || !blocks.Limits(block4))
            {
                transform.position += new Vector3(1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!blocks.Limits(block1) || !blocks.Limits(block2) || !blocks.Limits(block3) || !blocks.Limits(block4))
            {
                transform.position += new Vector3(-1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), -90);
            if (!blocks.Limits(block1) || !blocks.Limits(block2) || !blocks.Limits(block3) || !blocks.Limits(block4))
            {
                transform.RotateAround(transform.TransformPoint(rotationPoint), new Vector3(0, 0, 1), 90);
            }
        }
    }
    
    
    
    
    
    
    
    
    

    /*if (Time.time - previousTime > (Input.GetKeyDown(KeyCode.DownArrow) ? fallTime/20: fallTime)) //Modificar?
    {

    
    }

    public bool Limits() //Modificar para cada direccion individual
    {
        foreach (Transform son in transform)
        {
            int positionX = Mathf.RoundToInt(son.transform.position.x);
            int positionY = Mathf.RoundToInt(son.transform.position.y);

        int positionX = Mathf.RoundToInt(transform.position.x);
        int positionY = Mathf.RoundToInt(transform.position.y);

        if (positionX < 0 || positionX >= Width || positionY < 0 || positionY >= Height)
        {
            return false;
        }

        if (matriz[positionX, positionY] != null) 
        {
            return false;
        }

        return true;
        //}
    }*/

    /*public void AddToArray() //Modificar
    {
        foreach (Transform son in transform) 
        {
            int positionX = Mathf.RoundToInt(son.transform.position.x);
            int positionY = Mathf.RoundToInt(son.transform.position.y);

            matriz[positionX, positionY] = son; //Corregir

            if (positionY >= 19)
            {
                FindObjectOfType<StateMachine>().GameOver();
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }*/
}
