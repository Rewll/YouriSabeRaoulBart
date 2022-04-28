using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Vector3 rotation;
    [SerializeField] private Vector3 ofsetPos;
    [SerializeField] private GameObject spawnedObject;

    public void SpawnObjectOnThis()
    {
        Instantiate(spawnedObject, this.transform.position, this.transform.rotation);
    }
    public void SpawnObjectOnThisWithOfset()
    {
        Instantiate(spawnedObject, (this.transform.position + ofsetPos), this.transform.rotation);
    }

    public void SpawnObjectOnPos()
    {
        Instantiate(spawnedObject, position, Quaternion.Euler(rotation));
    }

    public void SpawnObjectOnPosWithOfset()
    {
        Instantiate(spawnedObject, position + ofsetPos, Quaternion.Euler(rotation));
    }

    public void ChangePos(Vector3 pos)
    {
        position = pos;
    }

    public void ChangeOfset(Vector3 Ofs)
    {
        ofsetPos = Ofs;
    }

    public void ChangeRot(Vector3 rot)
    {
        rotation = rot;
    }

    public void ChangeSpawnObject(GameObject newObject)
    {
        spawnedObject = newObject;
    }
}
