using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectFollowMouseScript : MonoBehaviour
{
    private Camera camera;
    private void Awake()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,0) - new Vector3(0,0,-10));
    }
}
