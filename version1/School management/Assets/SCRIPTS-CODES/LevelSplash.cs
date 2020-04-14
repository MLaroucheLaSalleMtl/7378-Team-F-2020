using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSplash : MonoBehaviour
{
    #region Singleton 
    public static LevelSplash instance = null;
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

    GameManager gamemanager;

    public Text infotext;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        levelSplashUI();
    }

    public void levelSplashUI()
    {
        if (gamemanager.PlayerLevel == 5)
        {
            infotext.text = "You are now Level " + gamemanager.PlayerLevel + "!" + "\n" + "\n" + "You can now buy the Hacking Classroom!";
        }
        else if (gamemanager.PlayerLevel == 10)
        {
            infotext.text = "You are now Level " + gamemanager.PlayerLevel + "!" + "\n" + "\n" + "You can now buy the Surfing Classroom!";
        }
        else if (gamemanager.PlayerLevel == 15)
        {
            infotext.text = "You are now Level " + gamemanager.PlayerLevel + "!" + "\n" + "\n" + "You can now buy the Axe Throwing Classroom!";
        }
        else 
        {
            infotext.text = "You are now Level " + gamemanager.PlayerLevel + "!";
        }
       
    }
}
