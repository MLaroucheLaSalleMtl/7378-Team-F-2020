using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLog : MonoBehaviour
{

    #region Instance
    public static PlayerLog instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    // Private VARS
    private Queue<string> Eventlog = new Queue<string>();
    private string guiText = "";
    public Font font;

    // Public VARS
    [SerializeField] public int maxLines;

    private GUIStyle guiStyle = new GUIStyle();


    public void AddEvent(string eventString)
    {

        if (Eventlog.Count >= maxLines)
            Eventlog.Clear();
            guiText = "";

            Eventlog.Enqueue(eventString);

            

        foreach (string logEvent in Eventlog)
        {
            guiText += logEvent;
            guiText += "\n";
        }
    }

    void OnGUI()
    {
        guiStyle.fontSize = 20;
        GUI.skin.textArea = guiStyle;
        GUI.skin.scrollView = guiStyle;
        guiStyle.font = font;


       GUI.Label(new Rect(1560, Screen.height - (Screen.height / 7), Screen.width / 5, Screen.height / 5), guiText, guiStyle);
       
       GUI.EndScrollView();
    }


    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("C"))
        {
            Eventlog.Clear();
            guiText = "";
            Debug.Log("if you press C, it CLEARS the PlayerLog, b-baka");
        }
    }
}
