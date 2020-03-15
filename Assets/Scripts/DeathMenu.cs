using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public Button btnPlayAgain;
    public Button btnQuit;
    public TMPro.TextMeshProUGUI score;

    public ScoreController sc;
    // Start is called before the first frame update
    void Start()
    {
        btnPlayAgain.onClick.AddListener(this.PlayGameAgain);
        btnQuit.onClick.AddListener(this.QuitGame);
        //Debug.Log("DM");
        score.text = "Your Score is " + sc.GetScore();
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
