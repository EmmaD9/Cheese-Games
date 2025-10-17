using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetMinigame : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void reLoad()
    {
        SceneManager.LoadScene(sceneName);
    }
}
