using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherSkills : MonoBehaviour
{
   

    #region Instance
    public static TeacherSkills instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            // Destroy(gameObject);
        }
    }
    #endregion

    #region Teacher Traits

    //private string PathTeacherTraits = "Assets/Resources/TeacherTraits.txt";
    //readonly List<string> PathTeacherList = new List<string>();

    #endregion

    GameManager gamemanager;


    delegate void TraitHandler();

    List<Action> possibleSkills;
    TraitHandler knownSkills;

    void Start()
    {
        gamemanager = GameManager.instance;

        possibleSkills = new List<Action>()
        {
            axeThrowing, surfing, magic, hacking
        };


        foreach (Action trait in possibleSkills)
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                // This gives you a 50/50 chance this skill will be applied
                knownSkills += trait.Invoke;
            }
        }
        knownSkills(); // calls all of the skill methods below, that have been added to this delegate in the foreach loop above

    }

    public void axeThrowing()
    {
        print("Axe Thrower");
    }

    public void surfing()
    {
        print("Surfer");
    }

    public void magic()
    {
        print("Magic Power");
    }

    public void hacking()
    {
        print("Hacker");
    }

    // Update is called once per frame
    void Update()
    {

    }



}
