using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeacherSkillsEnum : MonoBehaviour
{
   

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

    int lastValue;

    public void randomSkillGen()
    {
        randomSkill0 = (teacherSkills)Random.Range(0, 3);
        randomSkill1 = (teacherSkills)Random.Range(0, 3);
        randomSkill2 = (teacherSkills)Random.Range(0, 3);
    }


    public void commonTeacher()
    {
        if (gameObject.tag == "Common")
        {
            randomSkill0 = (teacherSkills)Random.Range(1, 3);

            switch (randomSkill0)
            {
                case teacherSkills.none:
                    Debug.Log("None");
                    break;
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer");
                    break;
            }
        }
    }
    public void rareTeacher()
    {
        if (gameObject.tag == "Rare")
        {
            randomSkill0 = (teacherSkills)Random.Range(1, 3);
            randomSkill1 = (teacherSkills)Random.Range(1, 3);

            switch (randomSkill0)
            {
                case teacherSkills.none:
                    Debug.Log("None");
                    break;
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer");
                    break;
            }
            switch (randomSkill1)
            {
                case teacherSkills.none:
                    Debug.Log("None");
                    break;
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer");
                    break;
            }
        }
    }

    public void legendaryTeacher()
    {
        if (gameObject.tag == "Legendary")
        {

            randomSkill0 = (teacherSkills)Random.Range(1, 3);
            randomSkill1 = (teacherSkills)Random.Range(2, 3);
            randomSkill2 = (teacherSkills)Random.Range(3, 3);

            switch (randomSkill0)
            {
                case teacherSkills.none:
                    Debug.Log("None");
                    break;
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer");
                    break;
            }
            switch (randomSkill1)
            {
                case teacherSkills.none:
                    Debug.Log("None");
                    break;
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer");
                    break;
            }
            switch (randomSkill2)
            {
                case teacherSkills.none:
                    Debug.Log("None");
                    break;
                case teacherSkills.axeThrowing:
                    Debug.Log("Axe Thrower");
                    break;
                case teacherSkills.hacking:
                    Debug.Log("Surfer");
                    break;
                case teacherSkills.magic:
                    Debug.Log("Magic");
                    break;
                case teacherSkills.surfing:
                    Debug.Log("Surfer");
                    break;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        commonTeacher();
        rareTeacher();
        legendaryTeacher();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
