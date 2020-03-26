using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Administration : MonoBehaviour
{
    #region Instance
    public static Administration instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            // Destroy(gameObject);
        }
    }
    #endregion

    public GameManager gameManager;

    Teachermanager teacherManager;

    SecretaryMono adminstaff;

    [SerializeField] private Transform[] waypontgameobject;
    private Vector3[] wayponts;
    public List<GameObject> studentstopay = new List<GameObject>();
    public bool Isthereasecretary=false;

    //private GameObject secretary;
    //private float efficiency = 5;       //this will be inside of secretary 

    void Start()
    {
        transformwaiponts();
        gameManager = GameManager.instance;
        teacherManager = Teachermanager.instance;
    }

    
    void Update()
    {
        
    }
   
    public IEnumerator Payfees()
    {
        if (Isthereasecretary == true)
        {

            yield return new WaitForSeconds(10.0f);
            for (int i = 0; i < studentstopay.Count; i++)
            {
                yield return new WaitForSeconds(adminstaff.Efficiency);
                studentstopay[0].GetComponent<StudentMono>().Paid = true;
                studentstopay.RemoveAt(0);
                GameManager.instance.AddMoney(25);
                organiseline();
            }


        }
    }
    public void organiseline()
    {
        for (int i = 0; i < studentstopay.Count; i++)
        {

            NavMeshAgent studentNavAgent = studentstopay[i].GetComponent<NavMeshAgent>();
            
            studentNavAgent.SetDestination(wayponts[i]);

        }

    }
    private void transformwaiponts()
    {
        wayponts = new Vector3[waypontgameobject.Length];

        for (int i = 0; i < waypontgameobject.Length; i++)
        {

            wayponts[i].x = waypontgameobject[i].position.x;
            wayponts[i].y = waypontgameobject[i].position.y;
            wayponts[i].z = waypontgameobject[i].position.z;

        }
    }


}
