using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;

public class StudentFactory : MonoBehaviour
{
    #region Singleton
    public static StudentFactory instance = null;
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

    #region Students Name

    private string PathGirlNames = "Assets/Resources/GirlNames.txt";
    private string PathBoyNames = "Assets/Resources/BoyNames.txt";
    private string PathLastNames = "Assets/Resources/LastName.txt";

    readonly List<string> BoyNamesList = new List<string>();
    readonly List<string> GirNamesList = new List<string>();
    readonly List<string> LastNameList = new List<string>();


    #endregion


    private GameManager manager ;
    private Student Student;

    void Start()
    {
        manager = GameManager.instance;
        var File1 = File.ReadAllLines(PathBoyNames);
        foreach (var w in File1) BoyNamesList.Add(w);
        var File2 = File.ReadAllLines(PathGirlNames);
        foreach (var w in File2) GirNamesList.Add(w);
        var File3 = File.ReadAllLines(PathLastNames);
        foreach (var w in File3) LastNameList.Add(w);

        //foreach (string a in BoyNamesList)
        //{
        //    Debug.Log(a);
        //}
        //Student = CreateStudent();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Student CreateStudent()
    {
        int RandsBoy=Random.Range(0, BoyNamesList.Count);
        int RandsGirl=Random.Range(0, GirNamesList.Count);
        int Randslastname=Random.Range(0, LastNameList.Count);
        int temporary = manager.AvalableClases.Length;
        int random=Random.Range(0, temporary);
        int binary = Random.Range(0,2);
        string gender,firstname,lastname,classwanted;

        classwanted = manager.AvalableClases[random];
        lastname = LastNameList[Randslastname];

        if (binary == 1)
        {
            gender = "Male";
            firstname = BoyNamesList[RandsBoy];
            
        }
        else {

            gender = "Female";
            firstname = GirNamesList[RandsGirl];
            
        }

        Student temp = new Student(firstname +" "+ lastname, classwanted, gender);
        return temp;
    }
}
