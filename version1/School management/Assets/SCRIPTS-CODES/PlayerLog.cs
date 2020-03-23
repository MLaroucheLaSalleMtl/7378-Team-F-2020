using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLog : MonoBehaviour
{

    // Private VARS
    private Queue<string> Eventlog = new Queue<string>();
    private string guiText = "";

    // Public VARS
   [SerializeField] public int maxLines;



    public void AddEvent(string eventString)
    {
        
        if (Eventlog.Count >= maxLines)
            Eventlog.Clear();
        Eventlog.Enqueue(eventString);

        guiText = "";

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "\n";
        }
    }

    void OnGUI()
    {

        //GUI.Label(new Rect(1500, (Screen.height) - (Screen.height / 4), Screen.width / 5, Screen.height / 8), guiText, GUI.skin.textArea);
        GUI.Label(new Rect(1500, Screen.height - (Screen.height / 7), Screen.width / 5, Screen.height / 5), guiText, GUI.skin.textArea);
        //GUI.Label(new Rect(0, Screen.height - (Screen.height / 3), Screen.width, Screen.height / 3), guiText, GUI.skin.textArea);

    }


    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
