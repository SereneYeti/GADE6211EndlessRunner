using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{
    public int maxLanes = 5;
    public int generateSpeed;

    PlayerController player = new PlayerController();
    public ScoreController sc;

    public GameObject path;
    public GameObject FogWall;
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
        SpawnPath();
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
        for (float x = 0f; x < maxLanes; x++)
        {
            Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
            lstgameObjects.Add(path);
        }
        cnt++;

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
        if (distance > 10)
        {
            if (safeZone == 0)
            {
                int temp2 = 0;
                temp2 = Random.Range(0, 3);

                for (float x = 0f; x < maxLanes; x++)
                {

                    temp = (Random.Range(0, 2));
                    if (temp == 1 && obsCnt < 2)
                    {
                        
                        Instantiate(Obstacles[temp2], new Vector3(x, 0.5f, distance), Quaternion.identity);
                        
                        lstgameObjects.Add(Obstacles[temp2]);
                        obsCnt++;
                    }
                    else if (temp == 0)
                    {
                        Instantiate(path, new Vector3(x, 0f, distance), Quaternion.identity);
                        lstgameObjects.Add(path);
                    }
                    else if (obsCnt == 2)
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

            }
            else
            {
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
            distance++;
        }
    }
           
    private void FixedUpdate()
    {
        GenerateCourse();
    }
    


    // Update is called once per frame
    void Update()
    {

    }

    private void setState()
    {
        if (sc.Score == 120)
        {
            easy = false;
            med = true;
            hard = false;
        }
        else if (sc.Score == 240)
        {
            easy = false;
            med = false;
            hard = true;
        }
    }
}
