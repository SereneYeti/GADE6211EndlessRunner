using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{
    public int maxLanes = 6;
    public int generateSpeed;

    PlayerController player = new PlayerController();
    public ScoreController sc;

    public GameObject path;
    public GameObject coin;
    public GameObject[] Obstacles;
    //public GameObject player;

    //public GameObject[] course;

    private Vector3 tempPlayerPos;
    private int cnt;
    private int counter;
    private float distance;
    private List<GameObject> lstgameObjects = new List<GameObject>();
    

    private bool easy = true;
    private bool med = false;
    private bool hard = false;

    private int obsCnt = 0;
    private int temp;
    private int safeZone = 20;
    public int SafeZone;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("GC");
        //SpawnPath();
    }
    

    public void SpawnPath()
    {

        cnt = 0;
        counter = generateSpeed;
        distance = 0f;

        for (int x = 0; x < maxLanes; x++)
        {
            Instantiate(path, new Vector3(x, 0, distance), Quaternion.identity);
            lstgameObjects.Add(path);
        }

        distance++;
        counter = generateSpeed;
        
    }

    public void GenerateCourse()
    {
        
        int temp2 = 0;

        if (distance > 10)
        {
            if (safeZone == 0)
            {
                
                temp2 = Random.Range(0, 3);

                GenerateObstacles(temp2);
                
            }           
            else
            {
                if (counter == 0)
                {
                    for (float x = 0f; x < maxLanes; x++)
                    {

                            Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                            lstgameObjects.Add(path);
                        
                        

                    }
                    
                    distance++;
                    
                    counter = generateSpeed;
                }
                else
                {
                    counter--;
                }
                if (Random.Range(0, 5) == 1)
                {
                    Instantiate(coin, new Vector3(Random.Range(0, maxLanes), 1f, distance), Quaternion.identity);
                    lstgameObjects.Add(coin);
                }
                safeZone--;
            }
        }
        else
        {
            for (float x = 0f; x < maxLanes; x++)
            {
              
                    Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                    lstgameObjects.Add(path);
                

            }
            if (Random.Range(0, 5) == 1)
            {
                Instantiate(coin, new Vector3(Random.Range(0, maxLanes), 1f, distance), Quaternion.identity);
                lstgameObjects.Add(coin);
            }
            distance++;
        }
        
    }
           
    private void FixedUpdate()
    {
        //GenerateCourse();
    }
    
    private void GenerateObstacles(int obs)
    {
        switch(obs)
        {
            case 0:
                {
                    //Wall
                    for (float x = 0f; x < maxLanes; x++)
                    {
                        temp = (Random.Range(0, 2));
                        if (temp == 1&&obsCnt<maxLanes-1)
                        {

                            Instantiate(Obstacles[obs], new Vector3(x, 0.5f, distance), Quaternion.identity);
                            lstgameObjects.Add(Obstacles[obs]);
                            obsCnt++;
                        }
                        else if (temp == 0)
                        {
                            Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                            lstgameObjects.Add(path);
                        }
                        //else if (obsCnt == 2)
                        //{
                        //    Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                        //    lstgameObjects.Add(path);
                        //}
                        if (x == maxLanes - 1)
                        {
                            safeZone = SafeZone;
                        }

                    }
                    obsCnt = 0;
                    break;
                }

            case 1:
                {
                    //Floating Block
                    for (float x = 0f; x < maxLanes; x++)
                    {
                        temp = (Random.Range(0, 2));
                        if (temp == 1 && obsCnt < maxLanes - 1)
                        {

                            Instantiate(Obstacles[obs], new Vector3(x, 3, distance), Quaternion.identity);
                            lstgameObjects.Add(Obstacles[obs]);
                            obsCnt++;
                        }
                        else if (temp == 0)
                        {
                            Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                            lstgameObjects.Add(path);
                        }
                        //else if (obsCnt == 2)
                        //{
                        //    Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                        //    lstgameObjects.Add(path);
                        //}
                        if (x == maxLanes - 1)
                        {
                            safeZone = SafeZone;
                        }

                    }
                    obsCnt = 0;
                    break;
                }
            case 2:
                {
                    //Tentacles
                    for (float x = 0f; x < maxLanes; x++)
                    {
                        temp = (Random.Range(0, 2));
                        if (temp == 1)
                        {

                            Instantiate(Obstacles[obs], new Vector3(x, 0.5f, distance), Quaternion.identity);
                            lstgameObjects.Add(Obstacles[obs]);
                            obsCnt++;
                        }
                        else
                        {
                            Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                            lstgameObjects.Add(path);
                        }
                        if (x == maxLanes - 1)
                        {
                            safeZone = SafeZone;
                        }

                    }
                    obsCnt = 0;
                    break;
                }
              default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setState()
    {
        //if (sc.Score == 120)
        //{
        //    easy = false;
        //    med = true;
        //    hard = false;
        //}
        //else if (sc.Score == 240)
        //{
        //    easy = false;
        //    med = false;
        //    hard = true;
        //}
    }
}
