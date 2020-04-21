using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reputation : MonoBehaviour
{
    public static Reputation instance = null;
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


    private GameManager manager;
    private GameTime time;
    private float REP;

    void Start()
    {
        manager = GameManager.instance;
        time = GameTime.instance;
    }


    private void determineReputation()
    {
        REP1 = 0;

        float happytemp = 0;
        

        foreach(GameObject student in manager.Allregisteredstudents)
        {
            happytemp += student.GetComponent<StudentMono>().stdudentinfo.Happines1;
        }
        happytemp = happytemp / manager.Allregisteredstudents.Count;
        if (happytemp >= 0 && happytemp < 45)
        {
            REP1 += 20;
        }else if (happytemp >= 45 && happytemp < 75)
        {
            REP1 += 40;
        }else if(happytemp >= 75 && happytemp <= 100)
        {
            REP1 += 60;
        }

        float[] rarity=new float[3];
        //Common = 0, Great = 0, Rare = 0, Legendary = 0
        float bestrarity = 0;
        int place = 0;
        bestrarity = rarity[0];
        foreach (GameObject teacher in manager.HiredTeachers)
        {
            if(teacher.tag== "Common")
            {
                rarity[0]++;
                if (rarity[0] > bestrarity)
                {
                    bestrarity = rarity[0];
                    place = 0;
                }
            }
            else if(teacher.tag== "Great")
            {
                rarity[1]++;
                if (rarity[1] > bestrarity)
                {
                    bestrarity = rarity[1];
                    place = 1;
                }
            }
            else if(teacher.tag== "Rare")
            {
                rarity[2]++;
                if (rarity[2] > bestrarity)
                {
                    bestrarity = rarity[2];
                    place = 2;
                }
            }
            else if(teacher.tag== "Legendary")
            {
                rarity[3]++;
                if (rarity[3] > bestrarity)
                {
                    bestrarity = rarity[3];
                    place = 3;
                }
                
            }
        }
        

        if (place == 0)
        {
            REP1 += 5;
        }else if (place == 1)
        {
            REP1 += 10;
        }
        else if (place == 2)
        {
            REP1 += 15;
        }
        else if (place == 3)
        {
            REP1 += 20;
        }


        
        if (manager.Playerpublicity >= 45 && manager.Playerpublicity < 65)
        {
            REP1 += 10;
        }
        else if (manager.Playerpublicity >= 65)
        {
            REP1 += 20;
        }




    }
    private int permastudenttospawn = 3;
    private int studentstominusplus=1;
    

    public Vector3 LocationOfSpawn = new Vector3(-7.98f, 0f, -72f);
    [SerializeField] private GameObject stud, Clockposs;

    public float REP1 { get => REP; set => REP = value; }
   

    public void Spawnstudents()
    {
        int studentstospawn = permastudenttospawn; 
        float randomval = Random.Range(0, 101);

        if (REP1 < 45)
        {
            if (randomval > 50) {

                studentstospawn -= studentstominusplus;

            }


        }else if (REP1 >= 65)
        {
            if (randomval > 50)
            {

                studentstospawn += studentstominusplus;

            }

        }
        do
        {
            Instantiate(stud, transform.position, Quaternion.identity, Clockposs.transform);
            studentstospawn--;
        } while (studentstospawn != 0);
    }

    public void Progresive()
    {
        permastudenttospawn += 1;
        studentstominusplus -= 1;
        
    }


    void Update()
    {
        determineReputation();
        
    }
}
