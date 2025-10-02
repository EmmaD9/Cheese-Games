using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] Rect bounds = new Rect(100, 100, 400, 400);

    private bool isHolding = false;
    public static float totalDistance = 0f;

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

        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (bounds.Contains(mousePosWorld))
        {
            Vector2 delta = context.ReadValue<Vector2>();
            totalDistance += Mathf.Abs(delta.y);
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 bottomLeftCor = new Vector3(bounds.xMin, bounds.yMin, 0);
        Vector3 topRightCor = new Vector3(bounds.xMax, bounds.yMax, 0);
        Vector3 center = (bottomLeftCor + topRightCor) * 0.5f;
        Vector3 size = new Vector3(bounds.width, bounds.height, 0);
        Gizmos.DrawWireCube(center, size);
    }
}
