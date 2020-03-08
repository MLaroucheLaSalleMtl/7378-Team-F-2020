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

    public List<GameObject> StudentsInLine=new List<GameObject>();

    

    private void Start()
    {
        manager = GameManager.instance;
        InvokeRepeating("Register", 10, 10f);
    }
    void Update()
    {
       
    }

    //IEnumerator coroutineA()
    //{
    //    // wait for 1 second
    //    Debug.Log("coroutineA created");
    //    yield return new WaitForSeconds(1.0f);
    //    yield return StartCoroutine(coroutineB());
    //    Debug.Log("coroutineA running again");
    //}

    //IEnumerator coroutineB()
    //{
    //    Debug.Log("coroutineB created");

    //    yield return new WaitForSeconds(2.5f);
    //    Debug.Log("coroutineB enables coroutineA to run");
    //}
   
    //private IEnumerator Wait(float waitTime)
    //{
    //    float Count = 0;
    //    while (Count < waitTime)
    //    {
    //        Count += Time.deltaTime;
    //        Debug.Log("We have waited for: " + Count + " seconds");
    //        yield return null;
    //    }
    //    if (StudentsInLine.Count > 0)
    //    {

    //        Register();

    //    }
    //}
    public void FillList()
    {
        GameObject[] studs = GameObject.FindGameObjectsWithTag("PotentialStudent");
        StudentsInLine = new List<GameObject>(studs);
    }
    public void TakePlace(GameObject a) {
        lineup = 0;
        NavMeshAgent StudentPos = a.GetComponent<NavMeshAgent>();
        lineup = StudentsInLine.Count;
        Debug.Log(lineup);
        StudentPos.SetDestination(WaitingPos - (DistanceNeded * lineup));


    }

    public void Register()
    {
        FillList();
        if (StudentsInLine.Count > 0&&manager.SpaceOnClasroomBogth())
        {
            string studClassWanted;
            studClassWanted = StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIwant1;
            foreach (GameObject a in manager.Clasesbogth)
            {
                if (StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 == null)
                {
                    if (studClassWanted == a.tag && a.GetComponent<ClasroomScip>().IsthereSpace())
                    {
                        StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 = a.tag;
                        StudentsInLine[0].GetComponent<StudentMono>().ClassSit = a.GetComponent<ClasroomScip>().AvalableSit();
                        Debug.Log(StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1);
                    }
                }
            }
            if (StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 == null)
            {
                foreach (GameObject F in manager.Clasesbogth)
                {
                    if (StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 == null)
                    {
                        if (F.GetComponent<ClasroomScip>().IsthereSpace())
                        {
                            StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 = F.tag;
                            StudentsInLine[0].GetComponent<StudentMono>().ClassSit = F.GetComponent<ClasroomScip>().AvalableSit();
                            Debug.Log(StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1);
                        }
                    }

                }
                //    else
                //    // if()
                //    {
                //        StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 = a.tag;
                //        StudentsInLine[0].GetComponent<StudentMono>().ClassSit = a.GetComponent<ClasroomScip>().AvalableSit();
                //        Debug.Log(StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1);
                //    }
                //}

                //foreach (GameObject a in manager.Clasesbogth)
                //{
                //    if (studClassWanted == null && a.GetComponent<ClasroomScip>().IsthereSpace())
                //    {
                //        studClassWanted = a.name;
                //        StudentsInLine[0].GetComponent<StudentMono>().ClassSit = a.GetComponent<ClasroomScip>().AvalableSit();
                //        Debug.Log(StudentsInLine[0].GetComponent<Student>().ClassIgot1);
                //    }

                //}
            }
            StudentsInLine[0].tag = "RegisteredStudent";
            StudentsInLine[0].GetComponent<StudentMono>().Schedule();
            StudentsInLine.RemoveAt(0);
            if (StudentsInLine.Count > 0)
            {
                Organice();
            }
        }
    }
    

    private void Organice()
    {
       
        if (StudentsInLine[0].transform.position!=WaitingPos) {
            foreach (GameObject student in StudentsInLine)
            {
            NavMeshAgent studentNavAgent=student.GetComponent<NavMeshAgent>();
            //student.transform.rotation.y = 0;

            //student.GetComponentInChildren<Animator>().SetBool("isWalking", true);//No use
            studentNavAgent.SetDestination(student.transform.position+ new Vector3(0, 0, 3));
            
        }
       }
    }
}

    //private IEnumerator RegisterStudent()
    //{
        
    //}

