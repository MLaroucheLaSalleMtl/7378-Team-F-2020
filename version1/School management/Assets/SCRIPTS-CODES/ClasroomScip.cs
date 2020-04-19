using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasroomScip : MonoBehaviour
{
    public int ClassCost;
    public List<GameObject> Sits;
    //public string ChildTagName;
    public GameObject Teacher = null;
    public int Teficiency=0;
    private bool once = true;

   // private teacherSkills Typeofclass = 0;
    private void Awake()
    {
        //ChildTagName = null;
    }
        private void Start()
        {
           for(int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).tag == "Sit")
                {
                    Sits.Add(transform.GetChild(i).gameObject);
                }
            }

        
    //    if (gameObject.tag == "Magic")
    //    {
    //        Typeofclass ==teacherSkills.magic;
    //    }
    //    else if (gameObject.tag == "Surfing")
    //    {
    //        Typeofclass = 2;
    //    }
    //    else if (gameObject.tag == "Haking")
    //    {
    //        Typeofclass = 4;
    //    }
    //    else if (gameObject.tag == "AxeTrowing")
    //    {
    //        Typeofclass = 1;
    //    }
    }
   
    private void Update() 
        {
        
       
        
        }

    private void LateUpdate()
    {

        if (Teacher != null)
        {
            SetTeacherSkill();
            once = false;

        }
    }
    public bool IsthereSpace()
    {
        int count=0;
        foreach (GameObject sit in Sits)
        {
            if (sit.GetComponent<SitUsed>().Ocupied==false)
                count++;
           
        }
        if (count >0 )
            return true;
        else return false;
    }
    public GameObject AvalableSit()
    {
        List<GameObject> tep = new List<GameObject>();
        foreach (GameObject sit in Sits)
        {
            if (sit.GetComponent<SitUsed>().Ocupied==false)
                tep.Add(sit);
            
        }
        int a = Random.Range(0, tep.Count);
        tep[a].GetComponent<SitUsed>().Ocupied = true;
        return tep[a];
    }

    //none, 0
    //axeThrowing, 1
    //surfing, 2
    //magic, 3 
    //hacking 4

    public void SetTeacherSkill()
    {
       
        
        if (Teacher.tag== "Common")
        {
            if (Teacher.GetComponent<TeacherSkillsEnum>().randomSkill0.ToString() ==gameObject.tag)
            {
                Teficiency = Teacher.GetComponent<TeacherSkillsEnum>().CEfficiency;

            }
            
        }else if(Teacher.tag == "Great") 
        {
            if (Teacher.GetComponent<TeacherSkillsEnum>().randomSkill0.ToString() == gameObject.tag)
            {
                Teficiency =Teacher.GetComponent<TeacherSkillsEnum>().GEfficiency;
            }

        }else if(Teacher.tag == "Rare") 
        {
            if (Teacher.GetComponent<TeacherSkillsEnum>().randomSkill0.ToString() == gameObject.tag)
            {
                Teficiency = Teacher.GetComponent<TeacherSkillsEnum>().CEfficiency;
            }else if (Teacher.GetComponent<TeacherSkillsEnum>().randomSkill1.ToString() == gameObject.tag)
            {
                Teficiency = Teacher.GetComponent<TeacherSkillsEnum>().REfficiency;
            }

        }else if(Teacher.tag == "Legendary") 
        {
            if (Teacher.GetComponent<TeacherSkillsEnum>().randomSkill0.ToString() == gameObject.tag)
            {
                Teficiency = Teacher.GetComponent<TeacherSkillsEnum>().CEfficiency;
            }
            else if (Teacher.GetComponent<TeacherSkillsEnum>().randomSkill1.ToString() == gameObject.tag)
            {
                Teficiency = Teacher.GetComponent<TeacherSkillsEnum>().REfficiency;
            }
            if (Teacher.GetComponent<TeacherSkillsEnum>().randomSkill2.ToString() == gameObject.tag)
            {
                Teficiency = Teacher.GetComponent<TeacherSkillsEnum>().LEfficiency;
            }
            

        }


    }
    

}
