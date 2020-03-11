using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TeacherFactory : MonoBehaviour
{
    #region Instance
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

    #region Teacher Traits

    private string PathTeacherTraits = "Assets/Resources/TeacherTraits.txt";

    readonly List<string> PathTeacherList = new List<string>();
    #endregion

    private GameManager manager ;
    private Teacher Teacher;

    void Start()
    {
        manager = GameManager.instance;
        var File4 = File.ReadAllLines(PathTeacherTraits);
        foreach (var w in File4) PathTeacherList.Add(w);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Teacher CreateTeacher()
    {
        int RandomNumofTrait = Random.Range(0, 2);
        int RandomTeacherTrait = Random.Range(0, PathTeacherList.Count);

        int NumOfTraits;
        string Traits, Traits2, Traits3;

        if (RandomNumofTrait == 0)      // ONE trait
        {
            NumOfTraits = 1;
            Traits = PathTeacherList[RandomTeacherTrait];
            Traits2 = null;
            Traits3 = null;
        }
        else if (RandomNumofTrait == 1) // TWO traits
        {
            NumOfTraits = 2;
            Traits = PathTeacherList[RandomTeacherTrait];
            Traits2 = PathTeacherList[RandomTeacherTrait];
            Traits3 = null;
        }
        else                            // THREE traits
        {
            NumOfTraits = 3;
            Traits = PathTeacherList[RandomTeacherTrait];
            Traits2 = PathTeacherList[RandomTeacherTrait];
            Traits3 = PathTeacherList[RandomTeacherTrait];
        }

        

        Teacher temp = new Teacher(NumOfTraits, Traits, Traits2, Traits3);
        return temp;
    }
}
