using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessManager : MonoBehaviour
{
    [SerializeField] private string sceneA;
    [SerializeField] private string sceneB;
    [SerializeField] private string sceneC;

    //Add in later:
    //[SerializeField] private string sceneD;
    //[SerializeField] private string sceneE;
    //[SerializeField] private string sceneF;

    private List<string> possibleScenes;

    // Start is called before the first frame update
    void Start()
    {
        possibleScenes = new List<string>() {sceneA, sceneB, sceneC };
    }

    public void NextScene()
    {
        int randomNumberInt = Random.Range(0, possibleScenes.Count);

        string randomScene = possibleScenes[randomNumberInt];

        if (randomScene != null && randomScene != SceneManager.GetActiveScene().name)
        {
            Debug.Log("we should go to the next scene now!!!");
            SceneManager.LoadScene(randomScene);
        } else
        {
            Debug.Log("the scene is either null or it is the current scene");
            NextScene();
        }
        

    }
}
