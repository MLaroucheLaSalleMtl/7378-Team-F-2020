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


    delegate void TraitHandler();

    List<Action> possibleSkills;
    TraitHandler knownSkills;

    public void commonTeacher()
    {
        if (gameObject.tag == "Common")
        {


            knownSkills += possibleSkills[0].Invoke;
            


            if (UnityEngine.Random.Range(0, 10) == 1)
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


            knownSkills += possibleSkills[0].Invoke;
            knownSkills += possibleSkills[1].Invoke;
            

            if (UnityEngine.Random.Range(0, 5) == 1)
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


            knownSkills += possibleSkills[0].Invoke;
            knownSkills += possibleSkills[1].Invoke;
            knownSkills += possibleSkills[2].Invoke;

            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                knownSkills += possibleSkills[3].Invoke;

            }
            knownSkills();


        }
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

    void Start()
    {
        gamemanager = GameManager.instance;
        possibleSkills = new List<Action>() { axeThrowing, surfing, magic, hacking }; // 0,1,2,3

        //Common Teacher
        commonTeacher();

        //Rare Teacher
        rareTeacher();

        //Legendary Teacher
        legendaryTeacher();
        
    }

    // Update is called once per frame
    void Update()
    {

    }



}
