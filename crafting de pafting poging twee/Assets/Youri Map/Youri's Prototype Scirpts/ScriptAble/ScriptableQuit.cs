using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuitGame", menuName = "ScriptableObjects/QuitGame")]
public class ScriptableQuit : ScriptableObject
{
    public void QuitGame()
    {
        Application.Quit();
    }
}
