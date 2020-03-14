using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{
    List<string> dogs = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
        dogs.Add("maltese");    // Contains maltese
        dogs.Add("otterhound"); // maltese, otterhound
        dogs.Add("rottweiler"); // maltese, otterhound, rottweiler
        dogs.Add("bulldog");    // ... rottweiler, bulldog
        dogs.Add("whippet");
        Debug.Log(dogs[0]);
        dogs.RemoveAt(0);
        Debug.Log("Value"+dogs[0]);
        dogs.RemoveAt(0);
        Debug.Log(dogs[0]);
        dogs.RemoveAt(0);
        Debug.Log(dogs[0]);
        dogs.RemoveAt(0);
        Debug.Log(dogs[0]);

       //    // .... rottweiler, bulldog, 
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
