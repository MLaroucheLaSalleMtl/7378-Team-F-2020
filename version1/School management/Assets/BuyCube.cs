using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCube : MonoBehaviour
{
    public Color hovercolor;
    private Renderer rend;
    private Color Defaaultcollor;
    private GameObject[] classrooms;
    private GameObject Classselected;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
    }


    private void OnMouseDown()
    {
        //display ui to pick
        //Build classroom
        //deactivate vbuy option
        //minus the money
    }
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        rend.material.color = hovercolor;
    }
    private void OnMouseExit()
    {
        rend.material.color = Defaaultcollor;
    }
}
