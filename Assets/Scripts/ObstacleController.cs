﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    public ScoreController sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = FindObjectOfType<ScoreController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if((collision.gameObject.tag == "Path")&&(gameObject.transform.position.x == collision.gameObject.transform.position.x) &&
            (gameObject.transform.position.y >= collision.gameObject.transform.position.y) &&
            (gameObject.transform.position.z == collision.gameObject.transform.position.z))          
        {
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((gameObject.transform.position.x == other.gameObject.transform.position.x) &&
            (gameObject.transform.position.y >= other.gameObject.transform.position.y) &&
            (gameObject.transform.position.z == other.gameObject.transform.position.z))
        {
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if ((gameObject.transform.position.x == other.gameObject.transform.position.x) &&
            (gameObject.transform.position.y >= other.gameObject.transform.position.y) &&
            (gameObject.transform.position.z == other.gameObject.transform.position.z))
        {
            Destroy(other.gameObject);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
