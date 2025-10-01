using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MilkingManager : MonoBehaviour
{
    [SerializeField] float winThreshold;
    

    private MouseMovement mouseReference;

    // Start is called before the first frame update
    void Start()
    {
        mouseReference = GetComponent<MouseMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (MouseMovement.totalDistance / 100 >= winThreshold)
        {
            Debug.Log("YOU WIN");
        }
    }
}
