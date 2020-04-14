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
    public GameObject Caffsit=null;

    public bool Paid = false;

    //-------------
    [SerializeField] private GameObject boyrig;
    [SerializeField] private GameObject girlrig;
    [SerializeField] private Animator animboy;    
    [SerializeField] private PercyTestStudentAnim script;    

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
        if (stdudentinfo.Gender1 == "Female")
        {
            boyrig.SetActive(false);
            animboy.enabled = false;
            girlrig.SetActive(true);
            script.enabled = false;
            
        }

    }

    // Update is called once per frame
    
    void Update()
    {
        if (gameObject.transform.position.y<manager.LevelMarkers[0].position.y)
        {
            Setmylayer(8);
        }
        else if (gameObject.transform.position.y > manager.LevelMarkers[0].position.y && gameObject.transform.position.y < manager.LevelMarkers[1].position.y)
        {
            Setmylayer(9);
        }
        else if (gameObject.transform.position.y > manager.LevelMarkers[1].position.y)
        {
            Setmylayer(10);
        }
        Schedule();
    }

    private void Setmylayer(int layer)
    {
        gameObject.layer = layer;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.layer = layer;
            if (transform.GetChild(i).childCount > 0)
            {
                for (int f = 0; f < gameObject.transform.GetChild(i).childCount; f++)
                {
                    transform.GetChild(i).gameObject.transform.GetChild(f).gameObject.layer = layer;
                }
            }
        }
    }

    public void GetPlaceoncafeteria() { 
    //{
    //    if (Caffsit != null&&caa)
    //    {

    //    }
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
  
    private void DetermineHappines()
    {
        //stdudentinfo.Happines1
        float HapyTemp = 0;

        if (stdudentinfo.ClassIgot1 == stdudentinfo.ClassIwant1)
        {
            HapyTemp += 40;
        }
              

    }



    public void Schedule()
    {
    
        if (ClassSit != null) { 
            //if (gtime.hour >= 3 && gtime.hour < 4)
            //{
            //    Paid = false;
            //}
                
            if (gtime.hour >3 && gtime.hour <= 10)
            {
                
                myNavAgent.SetDestination(ClassSit.transform.position);
            }
            if (gtime.hour > 10 && gtime.hour <= 13)
            {
                myNavAgent.SetDestination( RandomNavmeshLocation(25));
            }
            if (gtime.hour > 13 && gtime.hour <= 15)
            {
                myNavAgent.SetDestination(ClassSit.transform.position);
            }
            if (gtime.hour > 15 && gtime.hour <= 19)
            {
                myNavAgent.SetDestination(RandomNavmeshLocation(25));
            }
            if (gtime.hour > 19 && gtime.hour <= 24)
            {
                myNavAgent.SetDestination(ClassSit.transform.position);
            }

            if (gtime.hour > 24 && gtime.hour < 3)
            {
                myNavAgent.SetDestination(manager.LocationOfSpawn);
            }
        }
    }

 


}
