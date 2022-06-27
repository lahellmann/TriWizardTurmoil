using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * For Moving the maze.
 **/

public class MoveMaze : MonoBehaviour
{
    public GameObject inner_maze;
    public GameObject gate;

    // LabChange UI:
    public LabChangeScreen LabChangeUI;
    public float displayTime = 1f;
    private float turnOff = 0f;

    private float moveAgain = 20;
    private float staticTime = 20f;

    // private bool gateActive = true;

    // death time when not entering the lab:
    private float enteringFrame = 30f;
    private float enteringLimit = 30f;
    // public GameObject killer;


    private bool[,] one = new bool[19, 19]{
                                            {false, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, true },
                                            {false, false, true, false, false, false, true, false, false, false, true, false, false, false, false, true, false, false, true },
                                            {false, false, false, true, false, false, true, false, true, true, true, true, true, true, true, true, false, false, false},
                                            { false, false, false, false, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false},
                                            { false, false, true, false, false, false, false, true, true, false, false, true, true, false, true, false, true, false, false},
                                            {false, false, true, true, true, true, false, false, false, false, true, false, false, false, false, false, false, true, false },
                                            {false, false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, true, true},
                                            { false, false, false, true, true, false, false, false, false, false, false, false, false, false, true, true, false, false, false},
                                            { true, true, false, false, false, false, false, true, false, true, true, false, false, false, true, true, true, true, true},
                                            { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false},
                                            { false, false, true, true, false, false, true, false, false, false, false, false, false, false, false, true, false, false, false},
                                            { false, false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false, false, false},
                                            { false, true, false, false, false, false, false, false, false, false, true, false, false, false, false, false, false, true, false},
                                            { false, false, false, true, true, true, false, true, false, false, false, false, false, true, false, false, false, true, false},
                                            { true, false, false, false, false, false, false, false, false, false, false, true, false, false, true, false, false, false, false},
                                            { false, false, false, true, true, true, true, true, false, true, false, false, true, true, false, true, true, false, false},
                                            { true, true, false, true, false, false, false, false, false, false, true, false, false, false, false, false, false, true, true},
                                            { false, false, false, true, false, false, false, false, true, true, true, false, false, false, false, false, false, true, false},
                                            {false, false, false, false, true, false, false, false, false, false, false, false, true, true, false, false, false, false, false }
                                            };

    private bool[,] two = new bool[19, 19]{
                                            {true, false, false, false, true, false, true, false, false, false, false, true, true, true, false, false, false, false, false},
                                            {false, true, true, true, true, false, true, true, false, true, true, false, false, true, true, true, false, true, false},
                                            {false, true, false, false, true, false, true, true, false, false, true, false, true, true, false, true, false, false, false},
                                            {false, true, true, false, false, false, false, true, true, true, true, false, false, false, false, true, false, false, false},
                                            {true, false, true, false, true, true, false, false, false, false, true, false, false, false, false, false, false, false, false},
                                            {true, false, false, false, false, true, false, false, false, false, false, false, true, false, true, true, true, true, false},
                                            {true, true, true, true, false, true, true, true, true, false, true, true, true, false, false, false, true, false, false},
                                            {false, false, false, true, false, true, false, false, true, true, true, false, false, false, false, true, true, false, false},
                                            {false, true, false, false, false, true, false, false, false, false, false, false, false, true, false, true, false, true, false},
                                            {false, true, true, false, false, false, false, true, false, false, false, true, true, true, true, true, true, false, false},
                                            {false, false, true, true, true, true, true, true, true, false, true, false, false, true, true, true, true, true, false},
                                            {false, false, true, false, false, true, false, true, true, false, false, false, false, false, false, false, false, false, false},
                                            {false, true, true, true, false, false, false, true, false, true, false, true, true, true, false, false, false, false, true},
                                            {false, true, false, false, false, false, true, true, false, false, false, false, true, false, true, false, false, false, false},
                                            {false, false, false, false, true, false, false, false, false, true, false, false, false, false, true, true, false, false, false},
                                            {false, false, true, true, true, false, true, false, false, true, true, true, true, false, false, true, true, true, false},
                                            {true, false, true, false, false, false, true, true, false, true, false, false, true, true, false, false, false, false, false},
                                            {false, false, true, false, true, false, true, false, false, false, false, false, true, false, false, true, false, false, false},
                                            {false, false, false, false, true, false, false, false, true, false, false, false, false, false, false, false, false, false, false}
                                            };

    private bool[,] three = new bool[19, 19]{
                                            {false, false, false, false, false, true, false, true, false, false, false, false, false, false, false, false, true, false, false},
                                            {true, false, false, true, false, true, false, false, false, true, true, true, true, true, false, true, true, true, false},
                                            {false, true, false, false, true, false, false, true, false, true, false, false, false, true, true, true, false, true, false},
                                            {false, true, true, false, true, false, false, false, true, true, false, true, false, false, false, false, false, true, false},
                                            {false, false, true, false, true, false, true, false, false, false, false, false, false, true, true, false, true, false, false},
                                            {false, false, true, false, false, false, true, false, true, true, true, true, true, true, false, false, true, false, false},
                                            {false, true, true, false, false, true, true, false, false, false, true, false, false, true, true, false, false, false, false},
                                            {false, false, false, false, false, false, false, false, true, false, true, false, false, false, true, false, true, false, false},
                                            {false, true, true, false, false, false, true, true, true, false, true, true, true, false, false, false, false, true, true},
                                            {false, false, true, false, true, true, false, false, false, false, false, false, false, true, false, true, false, false, false},
                                            {false, false, false, false, false, true, false, true, true, false, true, true, false, true, false, true, true, false, false},
                                            {false, true, true, true, false, false, false, false, true, false, true, false, false, true, true, true, false, false, false},
                                            {false, true, false, false, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false},
                                            {false, true, false, false, false, false, true, false, false, true, false, true, true, true, false, false, true, true, false},
                                            {false, false, true, true, false, false, true, true, true, true, false, true, false, false, false, false, false, false, false},
                                            {false, false, false, false, false, false, true, false, false, true, true, true, false, true, true, true, false, false, false},
                                            {false, false, true, true, true, false, false, false, false, true, false, false, false, false, false, true, true, true, false},
                                            {false, false, false, false, true, true, false, false, false, false, false, true, false, true, false, true, false, false, false},
                                            {false, true, false, false, false, false, true, false, false, true, false, false, false, false, false, true, false, false, false}
                                            };

    private bool[,] four = new bool[19, 19]{
                                            {false, false, false, false, false, false, false, false, false, true, true, false, false, false, false, false, false, true, false},
                                            {true, false, true, false, false, true, true, true, false, false, true, false, true, true, false, true, false, false, false},
                                            {false, true, true, false, true, true, false, false, false, false, false, true, false, false, false, true, true, true, false},
                                            {false, false, true, false, false, false, false, true, false, true, false, false, false, false, true, true, false, false, false},
                                            {false, false, true, true, true, false, true, false, false, true, true, false, false, true, true, false, false, true, false},
                                            {true, false, false, false, true, false, true, false, false, false, true, false, true, true, false, false, true, true, false},
                                            {false, false, true, true, true, false, true, true, false, false, true, false, true, false, false, true, true, false, false},
                                            {true, false, false, false, true, false, false, false, true, false, true, false, false, false, true, true, false, false, false},
                                            {false, false, true, true, false, true, false, true, true, false, true, true, true, true, true, false, false, false, false},
                                            {false, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, true, false, false},
                                            {false, true, true, false, false, false, false, true, true, false, true, true, false, true, false, false, true, false, false},
                                            {false, false, false, true, true, false, true, false, true, false, true, false, false, true, true, false, false, false, false},
                                            {false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false, true, false, false},
                                            {false, true, false, false, false, false, false, false, false, true, true, false, false, false, true, false, false, false, false},
                                            {false, true, false, false, true, false, false, false, true, false, false, true, true, true, false, false, true, true, false},
                                            {false, true, true, true, true, false, true, false, false, false, false, false, true, false, false, true, false, false, false},
                                            {false, true, false, false, false, false, true, true, false, false, false, false, false, false, true, false, true, true, false},
                                            {false, true, false, false, true, false, false, true, false, true, true, false, false, false, false, false, false, true, false},
                                            {false, false, false, false, false, true, false, false, false, false, false, false, true, false, false, true, false, false, false}
                                            };

    // variable to fill for constructing the maze:
    private bool[,] lab;


    // Start is called before the first frame update
    void Start()
    {
        // at first, the gate should be open at all costs!
        gate.gameObject.SetActive(false);
        // gateActive = false;

        ChangeLabyrinth(one, two, three, four);
    }

    // Update is called once per frame
    void Update()
    {

        if (moveAgain <= Time.time)
        {
            // gate.gameObject.SetActive(true);
            // gateActive = true;

            // put LabChangeUI on Display:
            LabChangeUI.DisplayLabChangeUI();
            turnOff = Time.time + displayTime;

            moveAgain = Time.time + staticTime;
            ChangeLabyrinth(one, two, three, four);

            Debug.Log("Labyrinth was changed");
        }

        if (Time.time >= turnOff)
        {
            // remove the Lab ChangeUI as soon as the displayTime has passed:
            LabChangeUI.RemoveLabChangeUI();
        }

        if (Time.time >= enteringLimit)
        {
            // && transform außerhalb maze
            // FindObjectOfType<GameManager>().GameOver();
            // killer.SetActive(true);
        }
    }

    public void HideMaze()
    {
        gameObject.SetActive(false);
    }

    public void ChangeLabyrinth(bool[,] lab_1, bool[,] lab_2, bool[,] lab_3, bool[,] lab_4)
    {
        // iterating over every distinct sqare:
        for (int s = 0; s < 16; s++)
        {
            // choose a template randomly:
            int num = Random.Range(0, 4);
            Debug.Log(num);

            // save the lab that is chosen for the current iteration:
            switch (num)
            {
                case 0:
                    lab = lab_1;
                    break;

                case 1:
                    lab = lab_2;
                    break;

                case 2:
                    lab = lab_3;
                    break;

                case 4:
                    lab = lab_4;
                    break;

            }

            // iterating through the rows of the maze:
            for (int i = 0; i < 19; i++)
            {
                // iterating through the columns of the maze:
                for (int j = 0; j < 19; j++)
                {
                    GameObject square = inner_maze.transform.GetChild(s).gameObject;

                    // get the corresponding row:
                    GameObject row_i = square.transform.GetChild(i).gameObject;

                    // switch the corresponding brick on or off:
                    GameObject brick_j = row_i.transform.GetChild(j).gameObject;
                    brick_j.gameObject.SetActive(lab[i, j]);

                }
            }
        }

    }

    public void ResetMaze()
    {
        moveAgain = Time.time + displayTime;
        enteringLimit = Time.time + enteringFrame;
        Start();

    }

    public void PostponeMoving()
    {
        moveAgain += Time.deltaTime;
    }
}
