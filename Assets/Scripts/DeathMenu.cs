using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Button btnPlay;
    public Button btnQuit;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = new GameManager();
        btnPlay.onClick.AddListener(this.PlayGame);
        btnQuit.onClick.AddListener(this.QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayGame()
    {
       
        SceneManager.LoadScene(1);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
