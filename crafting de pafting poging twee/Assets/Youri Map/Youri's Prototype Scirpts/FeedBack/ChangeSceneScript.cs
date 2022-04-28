using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
public class ChangeSceneScript : MonoBehaviour
{
    [Header("Scene Settings")]
    [SerializeField] private string mainSceneName;

    void Start()
    {
        if (!Application.CanStreamedLevelBeLoaded(mainSceneName))
        {
            Debug.LogWarning(mainSceneName + " can't be found in the buildsettings");
        }
    }

    public void ChangeMainSceneName(string newSceneName)
    {
        mainSceneName = newSceneName;

        if (!Application.CanStreamedLevelBeLoaded(newSceneName))
        {
            Debug.LogWarning(newSceneName + " can't be found in the buildsettings");
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }

    public void LoadSceneByName(string sceneName)
    {
        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogWarning(sceneName + " can't be found in the buildsettings");
        }

        SceneManager.LoadScene(sceneName);
    }
}
