using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Student : MonoBehaviour
{
    private string SName;
    private string Scourse;
    private int Happines;
    //private int 
    [SerializeField]private NavMeshAgent myNavAgent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnSpawn();
        
    }

    public void OnSpawn()
    {
        
            if (GameObject.Find("Lobby"))
            {
                GameObject lobby = GameObject.Find("Lobby");
                myNavAgent.SetDestination(lobby.transform.position);
            }
            else
            {

            StartCoroutine(Waaiter());
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
          
            myNavAgent.SetDestination(RandomNavmeshLocation(8f));
            yield return new WaitForSeconds(6f);
        //} while (!GameObject.Find("Lobby")) ;
    }
}
