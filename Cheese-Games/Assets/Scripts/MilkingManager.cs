using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkingManager : MonoBehaviour
{

    private MouseMovement mouseReference;

    // Start is called before the first frame update
    void Start()
    {
        mouseReference = GetComponent<MouseMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MouseMovement.totalDistance / 100 >= 200f)
        {
            Debug.Log("YOU WIN");
        }
    }
}
