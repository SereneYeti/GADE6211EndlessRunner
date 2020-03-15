using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveController : MonoBehaviour
{
    //public game_Manager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        //if (gameManager == null)
        //{
        //    gameManager = FindObjectOfType<game_Manager>();
        //}
    }
        

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Hi");
        Destroy(other.gameObject);
    }

    

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.up * gameManager.forwardSpeed);
    }
}
