using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    [SerializeField] private string targetSceneName;

    public void NextScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}