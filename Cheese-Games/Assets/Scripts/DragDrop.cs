using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragDrop : MonoBehaviour
{
    private Vector2 mousePos;
    private bool isHolding;
    private Transform heldObject;
    private Vector3 offset;

    [SerializeField] private Dropzone dropzone;

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
                    heldObject = dragObject.transform;
                    offset = heldObject.position - worldPos;
                    isHolding = true;
                    heldObject.GetComponent<Conveyor>().Hold(true);
                    break;
                }
            }
        }
        else if (context.canceled)
        {
            if (isHolding && heldObject != null)
            {
                Conveyor conveyorObj = heldObject.GetComponent<Conveyor>();
                conveyorObj.Hold(false);

                // Check when released in dropzone
                if (dropzone.IsContained(heldObject.position))
                {
                    dropzone.CheckObjects(conveyorObj);
                }
                else
                {
                    conveyorObj.Drop();
                }
            }
            
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
