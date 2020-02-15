using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Student : MonoBehaviour
{
    private string SName;
    private string Scourse;
    private int Happines;
    private string ClassIwant;
    private char Gender;
    
    //private int 
    private NavMeshAgent myNavAgent;
    private bool LobbyFound = false;

    public Animator anim;


    Student instance;

    public Student(string sName, string classIwant,char gender)
    {
        SName = sName;
        Happines = 70;
        ClassIwant = classIwant;
        Scourse = "Not Registered";
        Gender = gender;
    }

    private void Awake()
    {
        instance = this;
       
        
    }

    void Start()
    {
        GameManager.instance.AddStudent();
        anim = GetComponent<Animator>(); //animation
        myNavAgent = gameObject.GetComponent<NavMeshAgent>();

        
        if (!GameObject.Find("Lobby"))myNavAgent.SetDestination(new Vector3(-10, 0, -10));

        
        InvokeRepeating("OnSpawn", 0, 5f);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawn()
    {
        anim.SetBool("isWalking", true); //WALKING
        if (GameObject.Find("Lobby"))
            {
                
                GameObject lobby = GameObject.Find("Lobby");
                Lobby.instance.FillList();
                Lobby.instance.TakePlace(instance);
            anim.SetBool("isWalking", true); //WALKING
            CancelInvoke();
                
        }
            else
            {

            
            myNavAgent.SetDestination(RandomNavmeshLocation(5f));
            
        }
        
    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        anim.SetBool("isWalking", true); //WALKING
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            
            finalPosition = hit.position;
            
        }
        

        return finalPosition;
        

    }

 


}
