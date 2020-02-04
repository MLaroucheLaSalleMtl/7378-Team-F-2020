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
    
    //private int 
    private NavMeshAgent myNavAgent;
    private bool LobbyFound = false;



    Student instance;

    public Student(string sName, int happines, string classIwant)
    {
        SName = sName;
        Happines = happines;
        ClassIwant = classIwant;
        Scourse = "Not Registered";
    }

    private void Awake()
    {
        instance = this;
        GameManager.instance.AddStudent();
        
    }

    void Start()
    {
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
        

            if (GameObject.Find("Lobby"))
            {
                GameObject lobby = GameObject.Find("Lobby");
                Lobby.instance.FillList();
                Lobby.instance.TakePlace(instance);
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

    public IEnumerator Waaiter()
    {
        // do
        //{
        yield return new WaitForSeconds(20f);
        myNavAgent.SetDestination(RandomNavmeshLocation(20f));
            
        //} while (!GameObject.Find("Lobby")) ;
    }


}
