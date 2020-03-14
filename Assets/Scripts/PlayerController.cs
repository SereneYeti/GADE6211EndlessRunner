using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float forwardSpeed;
    public bool alive = true;

    public TMPro.TextMeshProUGUI showScore;
    public ScoreController sc;

    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        player = GetComponent<GameObject>();
        playerPos = GetComponent<Transform>().position;
        sc = new ScoreController();
        //showScore = GetComponent<TMPro.TextMeshProUGUI>();

        alive = true;
        sc.Score = 0;
        showScore.text = "Score = " + sc.Score;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        sc.IncreaseScore();
        showScore.text = "Score = " + sc.Score;
    }


    void Movement()
    {
       
        //player.transform.position = transform.position + (Vector3.forward * forwardSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        }
        playerPos = GetComponent<Transform>().position;
    }

    public Vector3 GetPlayerPos()
    {
        Vector3 tempPos = new Vector3(0,0,0);
        tempPos = playerPos;
        return tempPos;
    }

    public void Death()
    {
        if(GetPlayerPos().y <= -3)
        {
            alive = false;
        }
    }
}
