using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheeseRollingManager : MonoBehaviour
{
    public GameObject whiteWheel;
    public GameObject yellowWheel;
    public float flickForce;

    private System.Random rand;

    private GameObject currentWheel;
    [SerializeField] WinScript win;
    [SerializeField] LoseScript lose;
    [SerializeField] Timer time;

    private bool cheeseInPlay = false;
    private bool isCheeseWhite = false;

    public uint score = 0;
    public uint scoreToWin;

    //Left is yellow
    //Right is white

    public void leftFlick()
    {
        Debug.Log("left");

        if (currentWheel.transform.position.y < -2.5f)
        {
            currentWheel.GetComponent<Rigidbody2D>().AddForce(new Vector2(flickForce * -1.0f, 0));

            if (!isCheeseWhite)
            {
                score++;
            }
            else
            {
                //fail stuff
            }

            cheeseInPlay = false;
        }
    }

    public void rightFlick()
    {
        Debug.Log("right");

        if (currentWheel.transform.position.y < -2.5f)
        {
            currentWheel.GetComponent<Rigidbody2D>().AddForce(new Vector2(flickForce, 0));

            if (isCheeseWhite)
            {
                score++;
            }
            else
            {
                //fail stuff
            }

            cheeseInPlay = false;
        }

    }

    private void spawnCheese()
    {

        double result = rand.NextDouble();
        if (result >= 0.5)
        {
            currentWheel = Instantiate(whiteWheel, new Vector3(0, 10, 0), Quaternion.identity);
            isCheeseWhite = true;
        }
        else
        {
            currentWheel = Instantiate(yellowWheel, new Vector3(0, 10, 0), Quaternion.identity);
        }

        cheeseInPlay = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        win = GetComponent<WinScript>();
        lose = GetComponent<LoseScript>();
        time = GetComponent<Timer>();
        rand = new System.Random();

        spawnCheese();
    }

    // Update is called once per frame
    void Update()
    {
        if (!cheeseInPlay && !win.gameWon && !lose.gameLost)
        {
            spawnCheese();
        }

        if (time.outOfTime() && !win.gameWon)
        {
            lose.Lose();
        }

        if (score >= scoreToWin && !lose.gameLost)
        {
            win.Win();
            Debug.Log("YOU WIN");
        }
    }
}
