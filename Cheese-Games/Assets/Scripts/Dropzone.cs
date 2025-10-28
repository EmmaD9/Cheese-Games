using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    private Bounds bounds;
    private int points = 0;

    void Awake()
    {
        bounds = GetComponent<SpriteRenderer>().bounds;
    }

    /// <summary>
    /// Check bounds
    /// </summary>
    /// <param name="worldPos"></param>
    /// <returns></returns>
    public bool IsContained(Vector3 worldPos)
    {
        return bounds.Contains(worldPos);
    }

    // Check whether object is good or bad and add points
    public void CheckObjects(Conveyor conveyorObj)
    {
        if (conveyorObj.objectType == Conveyor.Type.Bad)
        {
            points++;
        }

        Destroy(conveyorObj.gameObject);
    }

    void Update()
    {
        if (points >= 5)
        {
            Debug.Log("YOU WIN");
        }
    }
}
