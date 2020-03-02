using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class StudentMono : MonoBehaviour
{
    private GameTime gtime;
    private StudentFactory Sfactory;
    public Student stdudentinfo;
    private NavMeshAgent myNavAgent;
    private bool LobbyFound = false;

    void Start()
    {
        Sfactory = StudentFactory.instance;
        stdudentinfo = Sfactory.CreateStudent();
        gtime = GameTime.instance;
        GameManager.instance.AddStudent();
       
        myNavAgent = gameObject.GetComponent<NavMeshAgent>();

        
        if (!GameObject.Find("Lobby"))myNavAgent.SetDestination(new Vector3(-10, 0, -10));

        
        InvokeRepeating("OnSpawn", 0, 5f);

        Debug.Log(stdudentinfo.SName1 +" - "+ stdudentinfo.ClassIwant1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawn()
    {
      
        if (GameObject.Find("Lobby"))
            {
                
                GameObject lobby = GameObject.Find("Lobby");
                Lobby.instance.FillList();
          
            Lobby.instance.TakePlace(gameObject);
            
            CancelInvoke();
                
        }
            else
            {

            
            myNavAgent.SetDestination(RandomNavmeshLocation(5f));
            
        }
        
    }
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

    private void Schedule()
    {
        if (stdudentinfo.ClassIgot1 != null)
        {
            
            if (gtime.hour >8 && gtime.hour <= 12)
            {
                //Go to class
            }
            if (gtime.hour > 12 && gtime.hour <= 15)
            {
                //break
            }
            if (gtime.hour > 15 && gtime.hour <= 20)
            {
                //go to class
            }
            if (gtime.hour > 20)
            {
                //go Home
            }
        }
    }

 


}
