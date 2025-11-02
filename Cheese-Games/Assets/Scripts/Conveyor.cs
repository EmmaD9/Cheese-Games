using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public enum Type
    {
        Good,
        Bad
    }
    public Type objectType;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float fallSpeed = 5f;
    private bool isHeld = false;
    private bool isFalling = false;
    private Camera mainCamera;
    private float rightEdge;
    private float bottomEdge;

    void Start()
    {
        mainCamera = Camera.main;

        // Find edges
        Vector3 tempRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        Vector3 tempBottom = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));

        rightEdge = tempRight.x;
        bottomEdge = tempBottom.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeld) return;

        if (isFalling)
        {
            // Falling cheese
            transform.position += Vector3.down * fallSpeed * Time.deltaTime;
        }
        else
        {
            // Conveyor to the right
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (transform.position.x > rightEdge || transform.position.y < bottomEdge)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Toggle hold
    /// </summary>
    /// <param name="held"></param>
    public void Hold(bool held)
    {
        isHeld = held;
        if (isHeld)
        {
            isFalling = false;
        }
    }

    public void Drop()
    {
        isHeld = false;
        isFalling = true;
    }
}
