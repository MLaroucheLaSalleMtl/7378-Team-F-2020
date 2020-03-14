using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTip : MonoBehaviour
{
    public string lastTooltip = " ";

    void OnGUI()
    {
        GUILayout.Button(new GUIContent("Play Game", "Button1"));
        GUILayout.Button(new GUIContent("Quit", "Button2"));

        if (Event.current.type == EventType.Repaint && GUI.tooltip != lastTooltip)
        {
            if (lastTooltip != "")
            {
                SendMessage(lastTooltip + "OnMouseOut", SendMessageOptions.DontRequireReceiver);
            }

            if (GUI.tooltip != "")
            {
                SendMessage(GUI.tooltip + "OnMouseOver", SendMessageOptions.DontRequireReceiver);
            }

            lastTooltip = GUI.tooltip;
        }
    }

    public void Button1OnMouseOver()
    {
        Debug.Log("Play game got focus");
    }

    public void Button2OnMouseOut()
    {
        Debug.Log("Quit lost focus");
    }
}
