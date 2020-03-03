using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        
    }
    private Lobby lob;
    private void Awake()
    {
        
    }
    //public IEnumerator callForInscription(float waitTime)
    ////{
    ////    while (true)
    ////    {
    ////        if (lob.StudentsInLine.Count > 0)
    ////        {

                
    ////            yield return new WaitForSeconds(waitTime);
    ////            lob.Register();

    ////        }
            
    ////    }
    //}
    //IEnumerator Start()
    //{
    //    lob = Lobby.instance;

    //    yield return StartCoroutine(callForInscription(10f));
        
    //}

    // suspend execution for waitTime seconds
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
       
    }

}

