using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private int money = 0;
    [SerializeField] private int minMoney; // max money you can earn
    [SerializeField] private int maxMoney; // min money you can earn

    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnMoney(int amount)
    {
        if (amount > 0)
            money += amount;
    }

    public void EarnMoney()
    {
        money += rand.Next(minMoney, maxMoney + 1);
    }

    public bool SpendMoney(int amount)
    {
        if (amount > 0 && money - amount >= 0)
        {
            money -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}
