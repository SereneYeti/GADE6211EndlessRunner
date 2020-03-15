using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float forwardSpeed;
    public float jumpSpeed
    ;
    public bool alive = true;

    public TMPro.TextMeshProUGUI showScore;
    public ScoreController sc;
    public game_Manager gameManager;
    //private Rigidbody rb;
    private Vector3 playerPos;
    public bool onPath = true;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("P");
        //rb = GetComponent<Rigidbody>();
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<game_Manager>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Path")
        {
            onPath = true;
        }
        if (collision.gameObject.tag == "Coin")
        {
            sc.IncreaseScore();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
    }
    private void Awake()
    {
       
    }

    public void PlayerSetup()
    {
        player = GetComponent<GameObject>();
        playerPos = GetComponent<Transform>().position;
        //sc = GetComponent<ScoreController>();
        //gameManager = GetComponent <game_Manager>();
        //showScore = GetComponent<TMPro.TextMeshProUGUI>();

        alive = true;
        gameManager.Score = 0;
        showScore.text = "Score = " + gameManager.Score;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(onPath);
    }

    
    public void HandleScore()
    {
        //sc.IncreaseScore();
        showScore.text = "Score = " + gameManager.Score;
    }
    public void Movement()
    {

        //player.transform.position = transform.position + (Vector3.forward * forwardSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        //rb.AddForce(Vector3.forward*forwardSpeed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            //rb.AddForce(Vector3.left * forwardSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            //rb.AddForce(Vector3.right * forwardSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onPath)
            {
                onPath = false;
                transform.Translate(Vector3.up * jumpSpeed);
                //rb.AddForce(Vector3.up * jumpSpeed * Time.deltaTime);
            }
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
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
