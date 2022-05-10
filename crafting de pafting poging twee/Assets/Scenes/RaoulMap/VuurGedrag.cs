using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VuurGedrag : MonoBehaviour
{
    private bool ietsGeraakt;
    GameObject geraaktObject;

    private void Awake()
    {
        StartCoroutine(fikken());
    }

    IEnumerator fikken()
    {
        yield return new WaitForSeconds(1);
        if (ietsGeraakt)
        {
            Debug.Log("geraakt");
            geraaktObject.SetActive(false);
        }
        yield return new WaitForSeconds(3);
        //  Destroy(gameObject);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<burnableObject>())
        {
            ietsGeraakt = true;
            geraaktObject = collision.gameObject;
        }
        else
        {
        }
            Debug.Log(collision.name);
    }

}
