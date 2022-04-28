using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[DisallowMultipleComponent]
public class InputScript : MonoBehaviour
{
    [SerializeField] private List<InputData> inputs;


    void Update()
    {
        for (int i = 0; i < inputs.Count; i++)
        {
            if (Input.GetKey(inputs[i].key))
            {
                inputs[i].onKey?.Invoke();
            }
            else
            {
                inputs[i].notOnKey?.Invoke();
            }

            if (Input.GetKeyDown(inputs[i].key))
            {
                inputs[i].onKeyDown?.Invoke();
            }

            if (Input.GetKeyUp(inputs[i].key))
            {
                inputs[i].onKeyUp?.Invoke();
            }
        }
    }
}

[System.Serializable]
public class InputData
{
    [SerializeField] private string nameInput;
    public KeyCode key;
    public UnityEvent onKey;
    public UnityEvent notOnKey;
    public UnityEvent onKeyDown;
    public UnityEvent onKeyUp;

}
