using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class bushScript : MonoBehaviour
{
    public UnityEvent einde;
    public GameObject vuur;
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<FireEffect>())
        {
            if (collision.GetComponent<FireEffect>().gooien)
            {
                Debug.Log("Verbranden NU");
                StartCoroutine(vuuur());
            }
        }
    }

    public IEnumerator vuuur()
    {
        vuur.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);        
    }
}
