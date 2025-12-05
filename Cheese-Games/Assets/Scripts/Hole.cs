using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public float shrinkDuration = 0.5f;
    public float hitTolerance = 0.5f;
    public Transform ring;
    public Transform circle;
    public GameObject holePrefab;

    private float timer = 0f;
    private bool active = false;

    public System.Action<Hole> OnHoleResolved;
    public System.Action<Hole> OnHoleMissed;

    public void Activate()
    {
        timer = 0f;
        active = true;
        ring.localScale = Vector3.one * 2.5f;
    }

    void Update()
    {
        if (!active) return;

        timer += Time.deltaTime;
        float t = timer / shrinkDuration;

        ring.localScale = Vector3.Lerp(Vector3.one * 2.5f, new Vector3(0.6f, 0.6f, 0.0f), t);

        if (t >= 1.0f)
        {
            active = false;
            OnHoleMissed?.Invoke(this);
        }

        if (Input.GetMouseButtonDown(0))
        {
            float difference = Mathf.Abs(ring.localScale.x - 0.6f);
            if (difference <= hitTolerance)
            {
                active = false;
                PunchHole();
                OnHoleResolved?.Invoke(this);
            }
            else
            {
                active = false;
                OnHoleMissed?.Invoke(this);
            }
        }
    }

    void PunchHole()
    {
        if (holePrefab != null)
        {
            GameObject hole = Instantiate(holePrefab, transform.position, Quaternion.identity);
        }
    }
}
