using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] float tutorialTime;
    [SerializeField] GameObject tutorialBackground;
    [SerializeField] GameObject tutorialMouse;

    private float timeRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = tutorialTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0)
        {
            Instantiate(tutorialBackground, new Vector3(0, 0), Quaternion.identity);
        }
    }
}
