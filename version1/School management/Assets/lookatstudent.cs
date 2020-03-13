using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class lookatstudent : MonoBehaviour
{
    public GameObject target;
    private float smoothspeed = 0.25f;
    private Vector3 ofset;

    private void Update()
    {
        
    }


    private void FixedUpdate()
    {

        if (target.tag=="PotentialStudent"||target.tag=="RegisteredStudent")
        {
            Vector3 wantedpos = target.transform.position + ofset;
            transform.position = wantedpos;
            transform.LookAt(target.transform.position);
        }
    }
    public void Raycastt(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RaycastHit hit;
            
            Physics.Raycast(Input.mousePosition, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity);


                
           
        }
    }


}
