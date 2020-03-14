using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public GameManager gameManager = new GameManager();

    public ScoreController() { }
    public void IncreaseScore()
    {
        gameManager.Score++;
    }

    private void Awake()
    {

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
