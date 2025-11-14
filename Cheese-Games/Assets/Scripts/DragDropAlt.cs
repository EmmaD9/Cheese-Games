using UnityEngine;
using UnityEngine.InputSystem;

public class DragDropAlt : MonoBehaviour
{
    private Vector2 mousePos;
    private bool isHolding;
    private Transform heldObject;
    private Vector3 offset;



    public void OnPoint(InputAction.CallbackContext context)
    {
        // Update mouse position
        mousePos = context.ReadValue<Vector2>();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // Adjust world position
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;

            // Find all draggable objects
            foreach (GameObject dragObject in GameObject.FindGameObjectsWithTag("Draggable"))
            {
                // Pick up object if in bounds
                Bounds bounds = dragObject.GetComponent<SpriteRenderer>().bounds;
                if (bounds.Contains(worldPos))
                {
                    Debug.Log("Ah shit");
                    heldObject = dragObject.transform;
                    offset = heldObject.position - worldPos;
                    isHolding = true;

                    break;
                }
            }
        }
        else if (context.canceled)
        {

            isHolding = false;
            heldObject = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding && heldObject != null)
        {
            // Move object position
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            worldPos.z = 0;
            heldObject.position = worldPos + offset;
        }
    }
}