using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{
    public GameObject Panel;

    //pop up message
    public void OpenPanel()
    {
        if(Panel !=null)
        {
            Panel.SetActive(false);
        }

        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
