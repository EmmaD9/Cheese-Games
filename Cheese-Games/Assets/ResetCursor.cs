using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCursor : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 hotSpot = Vector2.zero; // Offset from top-left corner

    void Start()
    {
        Cursor.SetCursor(null, hotSpot, CursorMode.Auto);
    }

}
