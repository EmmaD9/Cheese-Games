using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    [SerializeField] private int money = 0;
    [SerializeField] private int minMoney; // max money you can earn
    [SerializeField] private int maxMoney; // min money you can earn

    private TextMeshProUGUI moneyText;

    private System.Random rand = new System.Random();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckSceneAndFindObject();
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


    void CheckSceneAndFindObject()
    {
        string targetSceneName = "Farm Scene";
        string targetObjectName = "Money Text";
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == targetSceneName)
        {
            GameObject obj = GameObject.Find(targetObjectName);
            if (obj != null)
            {
                TextMeshProUGUI foundText = obj.GetComponent<TextMeshProUGUI>();
                if (foundText != null)
                {
                    Debug.Log($"Found object '{targetObjectName}' in scene '{targetSceneName}'.");
                    foundText.text = money.ToString();
                }
                else
                {
                    Debug.LogWarning($"'{targetObjectName}' exists but does not have a TextMeshProUGUI component.");
                }
            }
            else
            {
                Debug.LogWarning($"Object '{targetObjectName}' not found in scene '{targetSceneName}'.");
            }
        }
        else
        {
            Debug.Log($"Current scene is '{currentScene}', not '{targetSceneName}'.");
        }
    }

}
