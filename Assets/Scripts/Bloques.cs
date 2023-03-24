using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloques : MonoBehaviour
{
    private static int Height = 21;
    private static int Width = 10;
    private static int playerPoints = 0;

    private static Transform[,] matriz = new Transform[Width, Height];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Limits(Transform thisBlock)
    {
        int positionX = Mathf.RoundToInt(thisBlock.position.x);
        int positionY = Mathf.RoundToInt(thisBlock.position.y);

        if (positionX < 0 || positionX >= Width || positionY < 0 || positionY >= Height)
        {
            return false;
        }

        if (matriz[positionX, positionY] != null)
        {
            return false;
        }

        return true;
    }

    public void AddToArray(Transform thisBlock)
    {
        int positionX = Mathf.RoundToInt(thisBlock.position.x);
        int positionY = Mathf.RoundToInt(thisBlock.position.y);

        matriz[positionX, positionY] = thisBlock;

        if (positionY >= 19)
        {
            StateMachine.stopGame = true;
            FindObjectOfType<StateMachine>().GameOver();
        }
    }

    public void CheckLines()
    {
        for (int i = Height - 1; i >= 0; i--)
        {
            if (HasLines(i))
            {
                EraseLine(i);
                DropLine(i);
            }
        }
    }

    private bool HasLines(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            if (matriz[j, i] == null)
            {
                return false;
            }
        }

        Debug.Log("Tiene linea");
        Puntaje.points += 100;
        playerPoints += 100;
        Debug.Log(playerPoints);
        return true;
    }

    private void EraseLine(int i)
    {
        for (int j = 0; j < Width; j++)
        {
            Destroy(matriz[j, i].gameObject);
            matriz[j, i] = null;
            Debug.Log("Linea borrada");
        }
    }

    private void DropLine(int i)
    {
        for (int y = i; y < Height; y++)
        {
            for (int j = 0; j < Width; j++)
            {
                if (matriz[j, y] != null)
                {
                    matriz[j, y - 1] = matriz[j, y];
                    matriz[j, y] = null;
                    matriz[j, y - 1].transform.position += new Vector3(0, -1, 0);
                    Debug.Log("Linea abajo");
                }
            }
        }
    }
}
