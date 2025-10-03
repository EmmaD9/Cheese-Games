using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] float time;

    // Start is called before the first frame update
    void Start()
    {
        timeText.text = ((int)time).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (!outOfTime())
        {
            time -= Time.deltaTime;
            timeText.text = ((int)time).ToString();
        }
    }

    public bool outOfTime()
    {
        return time <= 0;
    }
}
