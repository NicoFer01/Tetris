using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject UINewGame;
    [SerializeField] public GameObject UIGameplay;
    [SerializeField] public StateMachine _State;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void NewGame()
    {
        UINewGame.SetActive(false);
        UIGameplay.SetActive(true);
        Time.timeScale = 1;
        StateMachine.stopGame = false;
    }
}
