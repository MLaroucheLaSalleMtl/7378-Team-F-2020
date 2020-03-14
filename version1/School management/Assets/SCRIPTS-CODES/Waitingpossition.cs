using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waitingpossition : MonoBehaviour
{
    #region SingletonDeclaration
    public static Waitingpossition instance = null;



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

        
    }
    #endregion
    public Vector3[] ArrayOfWaitingposs;

    void Start()
    {
        ArrayOfWaitingposs = new Vector3[this.transform.childCount];

       for (int i=0;i< this.transform.childCount;i++)
        {
            Transform temp = gameObject.transform.GetChild(i);
            ArrayOfWaitingposs[i].x=temp.position.x;
            ArrayOfWaitingposs[i].y=temp.position.y;
            ArrayOfWaitingposs[i].z=temp.position.z;
            
        } 
    }

    
    void Update()
    {
        
    }
}
