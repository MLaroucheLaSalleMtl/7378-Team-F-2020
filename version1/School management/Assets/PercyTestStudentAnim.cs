using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PercyTestStudentAnim : MonoBehaviour
{
    private NavMeshAgent nav;
    private Animator anim;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speedOfcharacter = nav.velocity.magnitude / nav.speed;
        anim.SetFloat("Speed",speedOfcharacter,1f,Time.deltaTime);
    }
}
