using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{

    private bool isHolding = false;
    private float totalDistance = 0f;

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isHolding = true;
        }
        else if (context.canceled)
        {
            isHolding = false;
            Debug.Log("Distance: " + totalDistance / 100);
        }
    }

    public void OnDelta(InputAction.CallbackContext context)
    {
        if (!isHolding) return;

        Vector2 delta = context.ReadValue<Vector2>();
        totalDistance += Mathf.Abs(delta.y);
    }
}
