using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    public Vector2 hotSpot = Vector2.zero; // Offset from top-left corner


    // Example: Change cursor on mouse enter/exit of an object with a collider
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }
}