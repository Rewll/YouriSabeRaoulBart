using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class ChangeMaterialOnMeshScript : MonoBehaviour
{

    [Header("material")]
    [SerializeField] private Material mainNewMaterial;

    public void ChangeMaterial()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = mainNewMaterial;
    } 

    public void ChangeMaterialWith(Material newMaterial)
    {
        this.gameObject.GetComponent<MeshRenderer>().material = newMaterial;
    }

}
