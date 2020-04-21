using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private float reputation;
    void Start()
    {
        manager = GameManager.instance;
        time = GameTime.instance;
    }


    private void determineReputation()
    {
        float happytemp = 0;

        foreach(GameObject student in manager.Allregisteredstudents)
        {
            happytemp += student.GetComponent<StudentMono>().stdudentinfo.Happines1;
        }
        happytemp = happytemp / manager.Allregisteredstudents.Count;
        if (happytemp >= 0 && happytemp < 45)
        {
            reputation += 20;
        }else if (happytemp >= 45 && happytemp < 75)
        {
            reputation += 40;
        }else if(happytemp >= 75 && happytemp <= 100)
        {
            reputation += 60;
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
            reputation += 5;
        }else if (place == 1)
        {
            reputation += 10;
        }
        else if (place == 2)
        {
            reputation += 15;
        }
        else if (place == 3)
        {
            reputation += 20;
        }


        
        if (manager.Playerpublicity >= 45 && manager.Playerpublicity < 65)
        {
            reputation += 10;
        }
        else if (manager.Playerpublicity >= 65)
        {
            reputation += 20;
        }




    }
    private int permastudenttospawn = 3;
    private int studentstominusplus=1;
    

    public Vector3 LocationOfSpawn = new Vector3(-7.98f, 0f, -72f);
    [SerializeField] private GameObject stud, Clockposs;
    public void Spawnstudents()
    {
        int studentstospawn = permastudenttospawn; 
        float randomval = Random.Range(0, 101);

        if (reputation < 45)
        {
            if (randomval > 50) {

                studentstospawn -= studentstominusplus;

            }


        }else if (reputation >= 65)
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
