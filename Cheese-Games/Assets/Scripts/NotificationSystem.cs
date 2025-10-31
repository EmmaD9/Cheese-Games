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

        if (feedbackMessages.Count > 0)
        {
            StartCoroutine(CycleMessages());
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