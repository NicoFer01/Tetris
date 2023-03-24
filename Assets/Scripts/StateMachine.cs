using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    [SerializeField] public GameObject UIGameplay;
    [SerializeField] public GameObject UIGameOver;
    public static bool stopGame;
    void Start()
    {
        Time.timeScale = 1;
    }

    void Update()
    {
        
    }

    public void GameOver()
    {
        UIGameplay.SetActive(false);
        UIGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}
