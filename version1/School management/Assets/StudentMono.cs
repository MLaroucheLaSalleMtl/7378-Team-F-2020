//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StudentMono : MonoBehaviour
{
    private Lobby loby;
    private GameManager manager;

    private GameTime gtime;
    private StudentFactory Sfactory;
    public Student stdudentinfo;
    private NavMeshAgent myNavAgent;
    private bool LobbyFound = false;
    public GameObject ClassSit=null;
    void Start()
    {
        loby = Lobby.instance;
        manager = GameManager.instance;

        Sfactory = StudentFactory.instance;

        stdudentinfo = Sfactory.CreateStudent();

        gtime = GameTime.instance;
        manager.AddStudent();
       
        myNavAgent = gameObject.GetComponent<NavMeshAgent>();

        loby.TakePlace(gameObject);
        //if (!GameObject.Find("Lobby"))myNavAgent.SetDestination(new Vector3(-10, 0, -10));


        //InvokeRepeating("OnSpawn", 10, 5f);

    }

    // Update is called once per frame
    void Update()
    {
        Schedule();
    }

    //public void OnSpawn()
    //{
      
    //    //if (GameObject.Find("Lobby"))
    //    //    {
                
    //         GameObject lobby = GameObject.Find("Lobby");
    //        //loby.FillList();
    //        //loby.StudentsInLine.Add(gameObject);
          
    //        loby.TakePlace(gameObject);
            
    //    //    CancelInvoke();
                
    //    //}
    //    //    else
    //    //    {

            
    //    //    myNavAgent.SetDestination(RandomNavmeshLocation(5f));
            
    //    //}
        
    //}
    public Vector3 RandomNavmeshLocation(float radius)
    {

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
  




    public void Schedule()
    {
    
        {if (ClassSit != null)
            
            if (gtime.hour >8 && gtime.hour <= 12)
            {
                myNavAgent.SetDestination(ClassSit.transform.position);
            }
            if (gtime.hour > 12 && gtime.hour <= 15)
            {
                RandomNavmeshLocation(25);
            }
            if (gtime.hour > 15 && gtime.hour <= 20)
            {
                myNavAgent.SetDestination(ClassSit.transform.position);
            }
            if (gtime.hour > 20)
            {
                myNavAgent.SetDestination(manager.LocationOfSpawn);
            }
        }
    }

 


}
