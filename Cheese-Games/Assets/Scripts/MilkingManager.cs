using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class MilkingManager : MonoBehaviour
{
    [SerializeField] float winThreshold;
    [SerializeField] float distance; // total mouse distance divided by 100
    [SerializeField] WinScript win;
    [SerializeField] LoseScript lose;
    [SerializeField] Timer time;

    private MouseMovement mouseReference;

    // Start is called before the first frame update
    void Start()
    {
        mouseReference = GetComponent<MouseMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = MouseMovement.totalDistance / 100;

        if (time.outOfTime() && !win.gameWon)
        {
            lose.Lose();
        }

        if (distance >= winThreshold && !lose.gameLost)
        {
            win.Win();
            Debug.Log("YOU WIN");
        }
    }
}
