using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setobject : MonoBehaviour
{
    public Administration[] ventanillas;

    void Start()
    {
        GameManager.instance.managementlines = ventanillas;
    }

    
}
