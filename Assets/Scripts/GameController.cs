using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{
    public int maxLanes = 5;
    public int generateSpeed;
    public float forwardSpeed;

    PlayerController player = new PlayerController();
    public ScoreController sc;

    public GameObject[] path; //0 is single, 1 two blocks together either way(small), 2 is 3 blocks either way (medium) and 3 is 4 blocks either way (large)
    public GameObject wall;
    public GameObject roof;
    public GameObject FogWall;
    
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
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
        counter = generateSpeed;
        distance = 0f;

        easy = true;
        med = false;
        hard = false;

        for (int x = 0; x < 7; x++)
        {
            Instantiate(path[0], new Vector3(x, 0, distance), Quaternion.identity);
            lstgameObjects.Add(path[0]);
        }

        distance++;
        counter = generateSpeed;
        tempPlayerPos = player.GetPlayerPos();
    }

    private void FixedUpdate()
    {

        //while(player.alive == true)
        //{
        //    player.Death();
        //    setState();
        //    if (easy == true)
        //    {

        //    }
        //    else if (med == true)
        //    {
        //        //Uses medium path
        //    }
        //    else if (hard == true)
        //    {
        //        //Uses small path
        //    }
        //}

        for (float x = 0f; x < maxLanes; x++)
        {
            Instantiate(path[0], new Vector3(x, 0f, distance), Quaternion.identity);
            lstgameObjects.Add(path[0]);
        }
        cnt++;

        if (counter == 0)
        {
            for (float x = 0f; x < maxLanes; x++)
            {

                Instantiate(path[0], new Vector3(x, 0f, distance), Quaternion.identity);
                lstgameObjects.Add(path[0]);

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
            if(safeZone == 0)
            {
                for (float x = 0f; x < maxLanes; x++)
                {

                    temp = (Random.Range(0, 2));
                    if (temp == 1 && obsCnt < 2)
                    {
                        Instantiate(FogWall, new Vector3(x, 1f, distance), Quaternion.identity);
                        lstgameObjects.Add(FogWall);
                        obsCnt++;
                    }
                    else if (temp == 0)
                    {
                        Instantiate(path[0], new Vector3(x, 0f, distance), Quaternion.identity);
                        lstgameObjects.Add(path[0]);
                    }
                    else if (obsCnt == 2)
                    {
                        Instantiate(path[0], new Vector3(x, 0f, distance), Quaternion.identity);
                        lstgameObjects.Add(path[0]);
                    }
                    if (x == maxLanes - 1)
                    {
                        safeZone = 20;
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

                Instantiate(path[0], new Vector3(x, 0f, distance), Quaternion.identity);
                lstgameObjects.Add(path[0]);

            }
            distance++;            
        }


        //Debug.Log(distance);
        //if (distance > 8)
        //{
        //    temp = (Random.Range(0, 2));
        //    Debug.Log(temp);
        //    if (temp == 1)
        //    {

        //        Debug.Log(player.showScore);
        //        while (obsCnt != 2)
        //        {
        //            Debug.Log(player.alive);
        //            for (float x = 0f; x < maxLanes; x++)
        //            {
        //                if (Random.Range(0, 2) == 1)
        //                {
        //                    Instantiate(FogWall, new Vector3(x, 0, distance), Quaternion.identity);
        //                    lstgameObjects.Add(FogWall);
        //                    obsCnt++;
        //                }
        //            }
        //        }
        //    }
        //    if (obsCnt == 2)
        //    {
        //        obsCnt = 0;
        //    }

        //tempPlayerPos = player.GetPlayerPos();
        //foreach (GameObject g in lstgameObjects)
        //{
        //    if (g.transform.position.z == tempPlayerPos.z - 3)
        //    {
        //        Destroy(g);
        //    }
        //}
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
