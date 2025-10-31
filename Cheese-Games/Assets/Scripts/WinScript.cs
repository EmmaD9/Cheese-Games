using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    [SerializeField] GameObject winText;
    [SerializeField] float timeDisplayed; //how long the win popup is displayed in seconds
    public bool gameWon;

    [SerializeField] ChangeScenes changeScene;
    [SerializeField] Money money;

    public void Win()
    {
        if (!gameWon)
        {
            gameWon = true;
            money.EarnMoney();
            winText.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        changeScene = GetComponent<ChangeScenes>();
        money = GameObject.Find("Game Manager").GetComponent<Money>();
        gameWon = false;
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
