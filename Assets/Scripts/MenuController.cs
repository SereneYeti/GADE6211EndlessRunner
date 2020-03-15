using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button btnPlay;
    public Button btnQuit;
    public Button btnOptions;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("M");
        btnPlay.onClick.AddListener(this.PlayGame);
        btnQuit.onClick.AddListener(this.QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void PlayGame()
    {
        //Debug.Log("HI");
        SceneManager.LoadScene("Level1");
    }
    void QuitGame()
    {
        Application.Quit();
    }
}
