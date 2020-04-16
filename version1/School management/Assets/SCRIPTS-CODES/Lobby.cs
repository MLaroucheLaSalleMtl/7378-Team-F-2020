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

        WaitingPos = gameObject.transform.position - new Vector3(0, 0, 2);
    }
    #endregion

    private int lineup;

    private GameManager manager;

    private Vector3 WaitingPos; //-0,0,3 to add each student
    private Vector3 DistanceNeded = new Vector3(0, 0, 2);

    public List<GameObject> StudentsInLine=new List<GameObject>();
    private Waitingpossition waitingspaces;
    

    private void Start()

    {
        waitingspaces = Waitingpossition.instance;
        manager = GameManager.instance;
        InvokeRepeating("Register", 10, 10f);
        lineup = StudentsInLine.Count;

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
    //public void FillList()
    //{
    //    //GameObject[] studs = GameObject.FindGameObjectsWithTag("PotentialStudent");
    //    //StudentsInLine = new List<GameObject>(studs);
    //}
    public void TakePlace(GameObject a) {
        
        NavMeshAgent StudentPos = a.GetComponent<NavMeshAgent>();
        lineup++;
        Debug.Log(lineup);
        StudentsInLine.Add(a);
        StudentPos.SetDestination(waitingspaces.ArrayOfWaitingposs[lineup]);
        


    }

    public void Register()
    {
        
        if (StudentsInLine.Count > 0&&manager.SpaceOnClasroomBogth()==true)
        {
            

            StudentMono studentfirs=StudentsInLine[0].GetComponent<StudentMono>();
            foreach (GameObject a in manager.Clasesbogth)
            {
                if (studentfirs.stdudentinfo.ClassIgot1 == "nada")
                {
                    if (studentfirs.stdudentinfo.ClassIwant1 == a.tag && a.GetComponent<ClasroomScip>().IsthereSpace())
                    {
                        studentfirs.stdudentinfo.ClassIgot1 = a.tag;
                        studentfirs.ClassSit = a.GetComponent<ClasroomScip>().AvalableSit();
                        //Debug.Log(StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1);
                    }
                }
            }
            if (StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 == "nada")
            {
                foreach (GameObject F in manager.Clasesbogth)
                {
                    if (StudentsInLine[0].GetComponent<StudentMono>().stdudentinfo.ClassIgot1 == "nada")
                    {
                        if (F.GetComponent<ClasroomScip>().IsthereSpace())
                        {
                            studentfirs.stdudentinfo.ClassIgot1 = F.tag;
                            GameObject sit=F.GetComponent<ClasroomScip>().AvalableSit();
                            studentfirs.ClassSit = sit;
                            //sit.GetComponent<SitUsed>().Ocupied = true;
                           Debug.Log(studentfirs.stdudentinfo.ClassIgot1);
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
            if (StudentsInLine[0].GetComponent<StudentMono>().ClassSit != null)
            {
                
                StudentsInLine[0].tag = "RegisteredStudent";
                StudentShow.instance.CreateStudPan(StudentsInLine[0].GetComponent<StudentMono>());
                //GameObject.FindGameObjectsWithTag("ChillingPlace").Length
                StudentsInLine[0].GetComponent<StudentMono>().GetPlaceoncafeteria();


                StudentsInLine[0].GetComponent<StudentMono>().Schedule();
                manager.Allregisteredstudents.Add(StudentsInLine[0]);
                StudentsInLine.RemoveAt(0);
                lineup--;
                
                    Organice();
                
            }
        }
    }


    private void Organice()
    {

        for (int i=0;i<StudentsInLine.Count;i++) { 

            NavMeshAgent studentNavAgent = StudentsInLine[i].GetComponent<NavMeshAgent>();
        //student.transform.rotation.y = 0;

        //student.GetComponentInChildren<Animator>().SetBool("isWalking", true);//No use
        studentNavAgent.SetDestination(waitingspaces.ArrayOfWaitingposs[i]);

                }
       
    }
}

    //private IEnumerator RegisterStudent()
    //{
        
    //}

