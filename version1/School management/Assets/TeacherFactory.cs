using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TeacherFactory : MonoBehaviour
{
    #region Singleton
    public static TeacherFactory instance = null;
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


    private GameManager manager ;
    private Teacher Teacher;

    void Start()
    {
        manager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Teacher CreateTeacher()
    {
        int RandomNumofTrait = Random.Range(0, 2);
        int NumOfTraits = RandomNumofTrait;
        string Traits, Traits2, Traits3;
        

        if (RandomNumofTrait == 0)
        {
            
            Traits = "Magic";
            Traits2 = null;
            Traits3 = null;
        }
        else if (RandomNumofTrait == 1)
        {
           
            Traits = "Magic";
            Traits2 = "Oof";
            Traits3 = null;
        }
       else if (RandomNumofTrait == 2)
        {
            Traits = "Magic";
            Traits2 = "Warrior";
            Traits3 = "Surfing";
        }

        Teacher temp = new Teacher(NumOfTraits, Traits, Traits2, Traits3);
        return temp;
    }
}
