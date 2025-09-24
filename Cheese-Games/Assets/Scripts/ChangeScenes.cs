using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] Scene targetScene;
    public void nextScene()
    {
        SceneManager.LoadScene(targetScene.name);
    }
}
