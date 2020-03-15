﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game_Manager : MonoBehaviour
{
    private static game_Manager instance = null;
    public static game_Manager Instance
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

   

    public GameController course = new GameController();
    Scene test;
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
        //Debug.Log("GM");
        test = SceneManager.GetActiveScene();
        if(test.name == "Level1")
        {
            course.SpawnPath();
        }      
                
    }

    // Update is called once per frame
    void Update()
    {
        test = SceneManager.GetActiveScene();
        if (test.name == "Level1")
        {
            course.GenerateCourse();
        }
            
    }
}