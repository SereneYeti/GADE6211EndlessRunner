using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public game_Manager gameManager;

    public ScoreController() { }
    public void IncreaseScore()
    {
        gameManager.Score++;
    }

    private void Awake()
    {
        gameManager = FindObjectOfType<game_Manager>();
    }

    public int GetScore()
    {
        return gameManager.Score;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
