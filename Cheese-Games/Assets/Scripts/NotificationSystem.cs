using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro; // Add this at the top

public class NotificationSystem : MonoBehaviour
{
    [SerializeField] private List<string> feedbackMessages = new List<string>();
    [SerializeField] private float displayDuration = 3f;
    [SerializeField] private TextMeshProUGUI messageText;

    //sets diff kinds of notifs
    [SerializeField] private bool cycle;
    [SerializeField] private bool conditional;
    [SerializeField] private bool instructions;


    private Canvas canvas;
    private int currentIndex = 0;

    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas not found in scene.");
            return;
        }

        if (messageText == null)
        {
            //messageText = canvas.GetComponentInChildren<Text>();
            if (messageText == null)
            {
                Debug.LogError("No Text component found in Canvas.");
                return;
            }
        }

        if (feedbackMessages.Count > 0 && cycle == true)
        {
            StartCoroutine(CycleMessages());
        }

        if(conditional == true)
        {
            //TODO: working on this one rn
        }

        //Calls a new instruction to the screen each time u go back to the farm scene
        if (instructions == true)
        {
            string randomMessage = feedbackMessages[Random.Range(0, feedbackMessages.Count)];
            messageText.text = randomMessage;
        }
    }

    IEnumerator CycleMessages()
    {
        while (true)
        {
            messageText.text = feedbackMessages[currentIndex];
            currentIndex = (currentIndex + 1) % feedbackMessages.Count;
            yield return new WaitForSeconds(displayDuration);
        }
    }
}