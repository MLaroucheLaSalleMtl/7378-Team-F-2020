using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeacherSkillsEnum : MonoBehaviour
{
    GameManager gamemanager;
    PlayerLog eventLog;

    public enum teacherSkills
    {
        none,
        axeThrowing,
        surfing,
        magic,
        hacking
    }

    public teacherSkills randomSkill0;
    public teacherSkills randomSkill1;
    public teacherSkills randomSkill2;

    [SerializeField] private int cEfficiency;
    [SerializeField] private int gEfficiency;
    [SerializeField] private int rEfficiency;
    [SerializeField] private int lEfficiency;

    public int CEfficiency

    {
        get { return cEfficiency; }

        set { cEfficiency = Mathf.Clamp(value, 10, 30); }

    }

    public int GEfficiency

    {
        get { return gEfficiency; }

        set { gEfficiency = Mathf.Clamp(value, 10, 55); }

    }


    public int REfficiency

    {
        get { return rEfficiency; }

        set { rEfficiency = Mathf.Clamp(value, 30, 70); }

    }

    public int LEfficiency

    {
        get { return lEfficiency; }

        set { lEfficiency = Mathf.Clamp(value, 70, 100); }

    }

    public void randomSkillGen()
    {
        randomSkill0 = (teacherSkills)Random.Range(0, 4);
        randomSkill1 = (teacherSkills)Random.Range(0, 4);
        randomSkill2 = (teacherSkills)Random.Range(0, 4);
    }


    public void commonTeacher()
    {
        if (gameObject.tag == "Common")
        {
            eventLog.AddEvent("You hired a Common teacher!");

            randomSkill0 = (teacherSkills)Random.Range(1, 4);

            CEfficiency = Random.Range(0, 50);

            switch (randomSkill0)
            {
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Axe Thrower, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Magic, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + CEfficiency + "%");
                    break;
                default:
                    Debug.Log("None");
                    eventLog.AddEvent("None");
                    break;
            }
        }
    }

    public void greatTeacher()
    {
        if (gameObject.tag == "Great")
        {
            eventLog.AddEvent("You hired a Great teacher!");

            randomSkill0 = (teacherSkills)Random.Range(1, 4);

            GEfficiency = Random.Range(0, 70);

            switch (randomSkill0)
            {
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower, efficiency of " + GEfficiency + "%");
                    eventLog.AddEvent("Axe Thrower, efficiency of " + GEfficiency + "%");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer, efficiency of " + GEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + GEfficiency + "%");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic, efficiency of " + GEfficiency + "%");
                    eventLog.AddEvent("Magic, efficiency of " + GEfficiency + "%");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer, efficiency of " + GEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + GEfficiency + "%");
                    break;
                default:
                    Debug.Log("None");
                    eventLog.AddEvent("None");
                    break;
            }
        }
    }

    public void rareTeacher()
    {
        if (gameObject.tag == "Rare")
        {
            eventLog.AddEvent("You hired a Rare teacher!");

            randomSkill0 = (teacherSkills)Random.Range(1, 2);
            randomSkill1 = (teacherSkills)Random.Range(3, 4);

            CEfficiency = Random.Range(0, 50);
            REfficiency = Random.Range(0, 90);

            switch (randomSkill0)
            {
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Axe Thrower, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Magic, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + CEfficiency + "%");
                    break;
                default:
                    Debug.Log("None");
                    eventLog.AddEvent("None");
                    break;
            }
            switch (randomSkill1)
            {
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Axe Thrower, efficiency of " + REfficiency + "%");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + REfficiency + "%");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Magic, efficiency of " + REfficiency + "%");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + REfficiency + "%");
                    break;
                default:
                    Debug.Log("None");
                    eventLog.AddEvent("None");
                    break;
            }
        }
    }

    public void legendaryTeacher()
    {
        if (gameObject.tag == "Legendary")
        {
            eventLog.AddEvent("You hired a Legandary teacher!");

            randomSkill0 = (teacherSkills)Random.Range(1, 1);
            randomSkill1 = (teacherSkills)Random.Range(2, 2);
            randomSkill2 = (teacherSkills)Random.Range(3, 4);

            CEfficiency = Random.Range(0, 50);
            REfficiency = Random.Range(0, 90);
            LEfficiency = Random.Range(0, 100);

            switch (randomSkill0)
            {
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Axe Thrower, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Magic, efficiency of " + CEfficiency + "%");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer, efficiency of " + CEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + CEfficiency + "%");
                    break;
                default:
                    Debug.Log("None");
                    eventLog.AddEvent("None");
                    break;
            }
            switch (randomSkill1)
            {
                
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Axe Thrower, efficiency of " + REfficiency + "%");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + REfficiency + "%");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Magic, efficiency of " + REfficiency + "%");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer, efficiency of " + REfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + REfficiency + "%");
                    break;
                default:
                    Debug.Log("None");
                    eventLog.AddEvent("None");
                    break;
            }
            switch (randomSkill2)
            {
                
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower, efficiency of " + LEfficiency + "%");
                    eventLog.AddEvent("Axe Thrower, efficiency of " + LEfficiency + "%");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer, efficiency of " + LEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + LEfficiency + "%");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic, efficiency of " + LEfficiency + "%");
                    eventLog.AddEvent("Magic, efficiency of " + LEfficiency + "%");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer, efficiency of " + LEfficiency + "%");
                    eventLog.AddEvent("Surfer, efficiency of " + LEfficiency + "%");
                    break;
                default:
                    Debug.Log("None");
                    eventLog.AddEvent("None");
                    break;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.instance;
        eventLog = PlayerLog.instance;

        commonTeacher();
        greatTeacher();
        rareTeacher();
        legendaryTeacher();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
