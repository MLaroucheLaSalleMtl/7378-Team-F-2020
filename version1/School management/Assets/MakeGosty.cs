using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeGosty : MonoBehaviour
{
    [SerializeField] private Material gostycolor;
    private Renderer rend;
   
    void Start()
    {
        for(int i=0;i<transform.childCount;i++)
        {
            rend = transform.GetChild(i).GetComponent<Renderer>();

            rend.material = gostycolor;
        } 
    }

   
}
