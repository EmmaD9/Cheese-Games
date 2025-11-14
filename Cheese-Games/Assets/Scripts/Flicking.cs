using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Flicking : MonoBehaviour
{
    private bool isHolding = false;
    private bool flickCancelled = false;

    Vector2 startPos;
    Vector2 endPos;

    /// <summary>
    /// maximum angle from horizontal that a flick can be to be considered a left flick or a right flick
    /// </summary>
    [SerializeField] float maxFlickAngle;

    private CheeseRollingManager cheeseRollingManager;

    /// <summary>
    /// How long you can hold down click before the flick becomes invalid
    /// </summary>
    [SerializeField] float startTime;

    /// <summary>
    /// countdown timer
    /// </summary>
    [SerializeField] float actualTime;



    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            startPos = Mouse.current.position.ReadValue();
            isHolding = true;
        }
        else if (context.canceled && isHolding)
        {
            isHolding = false;
            if(actualTime >= 0)
            {
                endPos = Mouse.current.position.ReadValue();
                calculateFlick();
            }
        }
    }

    private void calculateFlick()
    {
        Vector2 flickVector = endPos - startPos;
        Vector2 right = new Vector2(1, 0);
        Vector2 left = new Vector2(-1, 0);

        float angleDifferenceRight = Vector2.Angle(flickVector, right);
        float angleDifferenceLeft = Vector2.Angle(flickVector, left);

        if(angleDifferenceRight <= maxFlickAngle)
        {
            cheeseRollingManager.rightFlick();
        }
        else if(angleDifferenceLeft <= maxFlickAngle)
        {
            cheeseRollingManager.leftFlick();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cheeseRollingManager = GetComponent<CheeseRollingManager>();
        actualTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {
            actualTime -= Time.deltaTime;
        }
        else
        {
            actualTime = startTime;
        }

        if(actualTime <= 0)
        {

        }
    }
}
