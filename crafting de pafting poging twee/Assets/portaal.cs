using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portaal : MonoBehaviour
{
    private void Awake()
    {
        GameObject text = Instantiate(Resources.Load<GameObject>("Prefabs/PortaalText"), transform.GetChild(0).transform.position, Quaternion.identity);
        text.transform.SetParent(GameObject.Find("CanvasWorld").transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}