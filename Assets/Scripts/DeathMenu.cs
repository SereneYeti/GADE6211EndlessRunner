using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Button btnPlayAgain;
    public Button btnQuit;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = new GameManager();
        btnPlayAgain.onClick.AddListener(this.PlayGameAgain);
        btnQuit.onClick.AddListener(this.QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayGameAgain()
    {
        Debug.Log("PlayAgain");
        SceneManager.LoadScene(1);
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
