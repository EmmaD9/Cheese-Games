using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charcuterie : MonoBehaviour
{
    [SerializeField] WinScript win;
    [SerializeField] LoseScript lose;
    [SerializeField] Timer time;

    [SerializeField] private GameObject board;
    private Bounds bounds;
    private List<GameObject> boardObjects = new List<GameObject>();
    [SerializeField] private int winCount;

    //Audio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSfx;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer spriteRenderer = board.GetComponent<SpriteRenderer>();
        bounds = spriteRenderer.bounds;
    }

    // Update is called once per frame
    void Update()
    {
        int objectsOnBoard = 0;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Draggable"))
        {
            SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) continue;

            Vector3 center = spriteRenderer.bounds.center;

            if (bounds.Contains(center))
            {
                if (correctSfx != null && audioSource != null && !audioSource.isPlaying)
                {
                    audioSource.clip = correctSfx;
                    audioSource.Play();
                }

                objectsOnBoard++;
            }
        }

        if (objectsOnBoard >= winCount && !lose.gameLost)
        {
            win.Win();

        }

        // LOSE CONDITION
        if (time.outOfTime() && !win.gameWon)
        {
            lose.Lose();
        }
    }
}