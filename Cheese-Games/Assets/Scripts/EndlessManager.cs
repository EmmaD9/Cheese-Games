using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessManager : MonoBehaviour
{
    [SerializeField] private string sceneA;
    [SerializeField] private string sceneB;
    //[SerializeField] private string sceneC;

    //Add in later:
    //[SerializeField] private string sceneD;
    //[SerializeField] private string sceneE;
    //[SerializeField] private string sceneF;

    private List<string> possibleScenes;

    // Start is called before the first frame update
    void Start()
    {
        possibleScenes = new List<string> { sceneA, sceneB }
            .Where(scene => !string.IsNullOrEmpty(scene))
            .ToList();
    }
    public void NextScene()
    {
        int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            int randomNumberInt = Random.Range(0, possibleScenes.Count);
            string randomScene = possibleScenes[randomNumberInt];

            if (!string.IsNullOrEmpty(randomScene) && randomScene != SceneManager.GetActiveScene().name)
            {
                Debug.Log("we should go to the next scene now!!!");
                SceneManager.LoadScene(randomScene);
                return;
            }
        }

        Debug.LogWarning("Failed to find a valid next scene after multiple attempts.");
    }
}
