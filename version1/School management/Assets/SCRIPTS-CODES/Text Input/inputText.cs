using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputText : MonoBehaviour
{
    public string schoolName;
    public GameObject inputField;
    public GameObject textDisplay;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StoreName()
    {
        schoolName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome to " + schoolName + "!";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
