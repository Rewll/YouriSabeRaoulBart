//OldScript

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//[DisallowMultipleComponent]
//public class BoolListScript : MonoBehaviour
//{
//    [SerializeField] private List<BoolList> bools;
//    [SerializeField] private UnityEvent<string, bool> Return;

//    public void GetBool(string nameSender, int number)
//    {
//        Return.Invoke(nameSender, bools[number].active);
//    }

//    public void GetBoolByName(string nameSender, string nameBool)
//    {
//        for (int i = 0; i < bools.Count; i++)
//        {
//            if (nameSender == bools[i].boolName)
//            {
//                Return.Invoke(nameSender, bools[i].active);
//            }
//        }
//    }


//}

//[System.Serializable]
//public class BoolList
//{
//    [Header("Bool")]
//    public string boolName;
//    public bool active;
//}