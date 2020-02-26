using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAdmin : MonoBehaviour
{
    private Color Defaaultcollor;
    public Color hovercolor;
    private Renderer rend;

    [SerializeField] private GameObject Admin;
    [SerializeField] private Vector3 PossitionOfcet;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
    }

    private void OnMouseDown()
    {
        GameObject ClassToBuild = Buildingmanager.instance.GetClassToBuild();
        Instantiate(Admin, transform.position + PossitionOfcet, transform.rotation);
        Destroy(gameObject);
    }
}
