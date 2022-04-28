using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManager", menuName = "ScriptableObjects/ChangeScene")]
public class ScriptableChangeScene : ScriptableObject
{
    [ContextMenuItem("CheckIfAllScenesExist", "TestScenes")]
    [SerializeField] private string[] Scenes;


    private void TestScenes() 
    {
        for (int i = 0; i < Scenes.Length; i++)
        {
            if (!Application.CanStreamedLevelBeLoaded(Scenes[i]))
            {
                Debug.LogWarning(Scenes[i] + " can't be found in the buildsettings in the list on element " + i.ToString());
            }
        }
    }

    public void LoadSceneByName(string name) 
    {
        for (int i = 0; i < Scenes.Length; i++)
        {
            if (Scenes[i] == name.ToString())
            {
                SceneManager.LoadScene(Scenes[i]);
                return;
            }
            if (i == Scenes.Length - 1) 
            {
                Debug.LogWarning(name + " Does not exist in the scriptableobject list");
            }
        }
    }

    public void LoadSceneByNumber(int number)
    {
        if (Scenes.Length <= number)
        {
            Debug.LogWarning(number + " is out of range.");
            return;
        }
        SceneManager.LoadScene(Scenes[number]);
    }

    public void seks(string Name) 
    {
        SceneManager.LoadScene(Name);
    }
    


}
