using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] WinScript win;
    [SerializeField] LoseScript lose;

    public Hole holePrefab;
    public int totalHoles = 10;
    private int currentCount = 0;

    //Audio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSfx;
    [SerializeField] private AudioClip badSfx;


    void Start()
    {
        SpawnNextHole();
    }

    private void Update()
    {
        if (currentCount >= totalHoles)
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
        ht.OnHoleMissed += HandleHoleMiss;
        ht.Activate();
    }

    void HandleHoleResult(Hole target)
    {
        // Play sound when points increase
        if (correctSfx != null && audioSource != null)
        {
            Debug.Log("there should be sound");
            audioSource.PlayOneShot(correctSfx);
        }

        Destroy(target.gameObject);
        currentCount++;
        if (currentCount < totalHoles)
            SpawnNextHole();
    }

    void HandleHoleMiss(Hole target)
    {
        // Play sound when points increase
        if (badSfx != null && audioSource != null)
        {
            Debug.Log("there should be sound");
            audioSource.PlayOneShot(badSfx);
        }

        lose.Lose();
    }
}
