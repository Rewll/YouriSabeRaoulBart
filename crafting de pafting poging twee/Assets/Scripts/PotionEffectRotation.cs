using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffectRotation : MonoBehaviour
{
    public GameObject _Player;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = _Player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = _Player.transform.rotation;
    }
}
