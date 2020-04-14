using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student
{


    private string SName;
    private string Scourse;
    private int Happines;
    private string ClassIwant;
    private string Gender;

    private string ClassIgot;

    public string SName1 { get => SName; set => SName = value; }
    public string Scourse1 { get => Scourse; set => Scourse = value; }
    public int Happines1 { get => Happines; set => Happines = value; }
    public string ClassIwant1 { get => ClassIwant; set => ClassIwant = value; }
    public string Gender1 { get => Gender; set => Gender = value; }
    public string ClassIgot1 { get => ClassIgot; set => ClassIgot = value; }

    public Student(string sName, string classIwant, string gender)
    {
        SName1 = sName;
        Happines1 = 60;
        ClassIwant1 = classIwant;
        Scourse1 = "Not Registered";
        Gender1 = gender;
        ClassIgot = "nada";
    }

}

