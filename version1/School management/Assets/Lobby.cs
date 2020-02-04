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

        WaitingPos=gameObject.transform.position-new Vector3(0,0,1);
    }
    #endregion

    private int lineup;


    private Vector3 WaitingPos; //-0,0,3 to add each student
    private Vector3 DistanceNeded = new Vector3(0,0,2);

    private List<GameObject> StudentsInLine;
   

    void Update()
    {
        
    }

    public void FillList()
    {
        GameObject[] studs = GameObject.FindGameObjectsWithTag("PotentialStudent");
        StudentsInLine = new List<GameObject>(studs);
    }
    public void TakePlace(Student a) {

        NavMeshAgent StudentPos=a.GetComponent<NavMeshAgent>();
        lineup = StudentsInLine.Count;
        Debug.Log(lineup);
        StudentPos.SetDestination(WaitingPos- (DistanceNeded*lineup));


    }

    private void Register()
    {

    }

    private void Organice()
    {
       
        //if (StudentsInLine[0].transform.position!=WaitingPos) {
            foreach (GameObject student in StudentsInLine)
            {
                NavMeshAgent studentNavAgent=student.GetComponent<NavMeshAgent>();
                studentNavAgent.SetDestination(student.transform.position- new Vector3(0, 0, 3));
            }
       // }
    }

    //private IEnumerator RegisterStudent()
    //{
        
    //}
}
