using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] WinScript win;

    public Hole holePrefab;
    public int totalHoles = 10;
    private int currentCount = 0;

    void Start()
    {
        SpawnNextHole();
    }

    private void Update()
    {
        if (currentCount < totalHoles)
        {
            win.Win();
        }
    }

    void SpawnNextHole()
    {
        if (currentCount >= totalHoles) return;

        Vector2 randomPos = Random.insideUnitCircle * 3f;
        Hole ht = Instantiate(holePrefab, randomPos, Quaternion.identity);

        ht.OnHoleResolved += HandleHoleResult;
        ht.Activate();
    }

    void HandleHoleResult(Hole target)
    {
        Destroy(target.gameObject);
        currentCount++;
        if (currentCount < totalHoles)
            SpawnNextHole();
    }
}
