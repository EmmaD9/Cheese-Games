using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] float tutorialTime;
    [SerializeField] GameObject tutorialBackgroundPrefab;
    private GameObject tutorialBackground;

    [SerializeField] GameObject tutorialMouse;
    [SerializeField] Animation anim;

    private float timeRemaining;
    
    // Start is called before the first frame update
    void Start()
    {
        tutorialBackground = Instantiate(tutorialBackgroundPrefab, new Vector3(0, 0), Quaternion.identity);
        tutorialBackground.SetActive(true);
        timeRemaining = tutorialTime;

    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if(timeRemaining <= 0)
        {
            tutorialMouse.SetActive(false);
            tutorialBackground.SetActive(false);
        }
    }
}
