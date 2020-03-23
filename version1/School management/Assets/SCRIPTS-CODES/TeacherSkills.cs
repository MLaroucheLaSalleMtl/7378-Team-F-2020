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

    #region Teacher Skills CYCLING THROUGH ALL 4
    //foreach (Action trait in possibleSkills)
    //{

    //    if (UnityEngine.Random.Range(0, 2) == 1)
    //    {
    //        // This gives you a 50/50 chance this skill will be applied
    //        knownSkills += trait.Invoke;

    //    }
    //}
    //knownSkills(); // calls all of the skill methods below, that have been added to this delegate in the foreach loop above
    #endregion

    GameManager gamemanager;

    PlayerLog eventLog;

    Teachermanager teachermanager;

    delegate void TraitHandler();

    List<Action> possibleSkills;
    TraitHandler knownSkills;

    


    void Start()
    {
        gamemanager = GameManager.instance;
        eventLog = PlayerLog.instance;
        teachermanager = Teachermanager.instance;

        possibleSkills = new List<Action>() { axeThrowing, surfing, magic, hacking }; // 0,1,2,3

        //Common Teacher
        commonTeacher();

        //Rare Teacher
        rareTeacher();

        //Legendary Teacher
        legendaryTeacher();

    }


    public void commonTeacher()
    {
        if (gameObject.tag == "Common")
        {
            eventLog.AddEvent("You hired a Common teacher!");

            knownSkills += possibleSkills[0].Invoke;
            

            // there is a 1/20 chance which is 5%
            if (UnityEngine.Random.Range(0, 19) == 1)
            {
                knownSkills += possibleSkills[1].Invoke;
                knownSkills += possibleSkills[2].Invoke;
                knownSkills += possibleSkills[3].Invoke;
            }
            knownSkills();


        }
    }

    public void rareTeacher()
    {
        if (gameObject.tag == "Rare")
        {
            eventLog.AddEvent("You hired a Rare teacher!");

            knownSkills += possibleSkills[0].Invoke;
            knownSkills += possibleSkills[1].Invoke;
            
            // there is a 1/10 chance which is 10%
            if (UnityEngine.Random.Range(0, 9) == 1)
            {
                knownSkills += possibleSkills[2].Invoke;
                knownSkills += possibleSkills[3].Invoke;
            }
            knownSkills();


        }
    }

    public void legendaryTeacher()
    {
        if (gameObject.tag == "Legendary")
        {
            eventLog.AddEvent("Wow, a Legendary teacher!");

            knownSkills += possibleSkills[0].Invoke;
            knownSkills += possibleSkills[1].Invoke;
            knownSkills += possibleSkills[2].Invoke;

            //there is a 1/4 chances so 25%
            if (UnityEngine.Random.Range(0, 3) == 1)
            {
                knownSkills += possibleSkills[3].Invoke;

            }
            knownSkills();


        }
    }


    public void axeThrowing()
    {
        print("Axe Thrower");
        eventLog.AddEvent("Knows Axe throwing");
    }

    public void surfing()
    {
        print("Surfer");
        eventLog.AddEvent("Knows Surfing");
    }

    public void magic()
    {

        print("Magic Power");
        eventLog.AddEvent("Knows Magic");
    }

    public void hacking()
    {
        
        print("Hacker");
        eventLog.AddEvent("Knows Hacking");
    }

 

    // Update is called once per frame
    void Update()
    {

    }



}
