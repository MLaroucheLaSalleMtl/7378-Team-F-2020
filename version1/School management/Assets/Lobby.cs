using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Lobby : MonoBehaviour
{
    #region SingletonDeclaration
    public static Lobby instance = null;



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

        WaitingPos = gameObject.transform.position - new Vector3(0, 0, 1);
    }
    #endregion

    private int lineup;

    private GameManager manager;

    private Vector3 WaitingPos; //-0,0,3 to add each student
    private Vector3 DistanceNeded = new Vector3(0, 0, 2);

    private List<GameObject> StudentsInLine;

    private void Start()
    {
        manager = GameManager.instance;
    }

    void Update()
    {

    }

    public void FillList()
    {
        GameObject[] studs = GameObject.FindGameObjectsWithTag("PotentialStudent");
        StudentsInLine = new List<GameObject>(studs);
    }
    public void TakePlace(GameObject a) {

        NavMeshAgent StudentPos = a.GetComponent<NavMeshAgent>();
        lineup = StudentsInLine.Count;
        Debug.Log(lineup);
        StudentPos.SetDestination(WaitingPos - (DistanceNeded * lineup));


    }

    private void Register()
    {
       string studClassWanted;
       studClassWanted = StudentsInLine[0].GetComponent<Student>().ClassIwant1;
      foreach(string a in manager.Clasesbogth)
        {
            if (studClassWanted==a)
            {
                StudentsInLine[0].GetComponent<Student>().ClassIgot1 = a;
                Debug.Log(StudentsInLine[0].GetComponent<Student>().ClassIgot1);
            }
        }
       
     }
    

    private void Organice()
    {
       
        //if (StudentsInLine[0].transform.position!=WaitingPos) {
            foreach (GameObject student in StudentsInLine)
            {
            NavMeshAgent studentNavAgent=student.GetComponent<NavMeshAgent>();
            //student.transform.rotation.y = 0;

            student.GetComponentInChildren<Animator>().SetBool("isWalking", true);
            studentNavAgent.SetDestination(student.transform.position- new Vector3(0, 0, 3));
            
        }
       // }
    }
}

    //private IEnumerator RegisterStudent()
    //{
        
    //}

