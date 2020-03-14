using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {   //Read only
        get
        {
            return instance;
        }
    }

    List<int> HighScores;

    public int forwardSpeed = 10;
    public int generateSpeed = 10;
    public int Score = 0;

    GameController course = new GameController();
    private void Awake()
    {
        if(instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        //Make only active instance
        instance = this;
        //Make Game Manager Persist.
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //course.SpawnPath();
    }

    // Update is called once per frame
    void Update()
    {
        //course.GenerateCourse();
    }
}
