using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] float timeDisplayed; //how long the win popup is displayed in seconds
    public bool gameWon;

    [SerializeField] ChangeScenes changeScene;

    public void Win()
    {
        gameWon = true;
        winText.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWon)
        {
            timeDisplayed -= Time.deltaTime;
        }

        if(timeDisplayed <= 0)
        {
            changeScene.NextScene();
        }
    }
}
