using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveController : MonoBehaviour
{
    public BoxCollider caveBounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }
        

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Hi");
        Destroy(other.gameObject);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
