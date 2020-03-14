using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private static ScoreController instance = null;

    public static ScoreController Instance
    {
        get
        {
            return instance;
        }
    }

    private int score;

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public ScoreController() { }
    public void IncreaseScore()
    {
        Score = Mathf.RoundToInt(Time.timeSinceLevelLoad);
    }

    private void Awake()
    {
        if(instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
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
