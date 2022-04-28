using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.visible = false;
    }

    public void CursorVisible(bool visuable) 
    {
        Cursor.visible = visuable;
    }

    public void Curerlocked(bool isTrue) 
    {
        if (isTrue) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

        Cursor.lockState = CursorLockMode.None;
    }

    public void CurserConfined() 
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
