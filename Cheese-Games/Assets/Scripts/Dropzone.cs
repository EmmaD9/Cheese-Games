using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    [SerializeField] WinScript win;
    [SerializeField] LoseScript lose;
    [SerializeField] Timer time;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pointIncreaseSfx;
    [SerializeField] private AudioClip garbageSfx;

    private Bounds bounds;
    private int points = 0;
    private Timer timer;

    void Awake()
    {
        bounds = GetComponent<SpriteRenderer>().bounds;
    }

    /// <summary>
    /// Check bounds
    /// </summary>
    /// <param name="worldPos"></param>
    /// <returns></returns>
    public bool IsContained(Vector3 worldPos)
    {
        return bounds.Contains(worldPos);
    }

    // Check whether object is good or bad and add points
    public void CheckObjects(Conveyor conveyorObj)
    {
        if (conveyorObj.objectType == Conveyor.Type.Bad)
        {
            points++;
            Debug.Log("there should be points increased");

            // Play sound when points increase
            if (pointIncreaseSfx != null && audioSource != null)
            {
                Debug.Log("there should be sound");
                audioSource.PlayOneShot(pointIncreaseSfx);
            }

        } else
        {
            audioSource.PlayOneShot(garbageSfx);
        }

            Destroy(conveyorObj.gameObject);
    }

    void Update()
    {
        if (points >= 5 && !lose.gameLost)
        {
            win.Win();
        }

        if (time.outOfTime() && !win.gameWon)
        {
            lose.Lose();
        }
    }
}
