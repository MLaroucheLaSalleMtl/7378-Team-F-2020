using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher
{
    private int numOfTraits;
    private string traits;
    private string traits2;
    private string traits3;

    
    public int numOfTraits1 { get => numOfTraits; set => numOfTraits = value; }
    public string traits1 { get => traits; set => traits = value; }
    public string traits12 { get => traits2; set => traits2 = value; }
    public string traits13 { get => traits3; set => traits3 = value; }

    public Teacher(int NumOfTraits, string Traits, string Traits2, string Traits3)
    {
        numOfTraits1 = NumOfTraits;
        traits1 = Traits;
        traits12 = traits2;
        traits13 = traits3;
    }

}

