using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PercyTestStudentAnim : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    [SerializeField]private StudentMono info;
    void Start()
    {
        if (info.stdudentinfo.Gender1 == "Female")
        {
            nav = transform.parent.GetComponent<NavMeshAgent>();
        }
        else
        {
            nav = GetComponent<NavMeshAgent>();

        }
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        float speedOfcharacter = nav.velocity.magnitude / nav.speed;
        anim.SetFloat("Speed", speedOfcharacter, 1f, Time.deltaTime);
    }
    //private void LateUpdate()
    //{
    //    float speedOfcharacter = nav.velocity.magnitude / nav.speed;
    //    anim.SetFloat("Speed", speedOfcharacter, 1f, Time.deltaTime);
    //}

}
