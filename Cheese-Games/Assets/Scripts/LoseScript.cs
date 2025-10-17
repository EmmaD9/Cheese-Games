using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    [SerializeField] GameObject loseText;
    [SerializeField] float timeDisplayed; //how long the win popup is displayed in seconds
    public bool gameLost;

    [SerializeField] ChangeScenes changeScene;

    public void Lose()
    {
        gameLost = true;
        loseText.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        changeScene = GetComponent<ChangeScenes>();
        gameLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameLost)
        {
            timeDisplayed -= Time.deltaTime;
        }

        if (timeDisplayed <= 0)
        {
            changeScene.NextScene();
        }
    }
}
