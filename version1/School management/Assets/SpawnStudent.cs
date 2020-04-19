using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnStudent : MonoBehaviour
{

    public Vector3 LocationOfSpawn = new Vector3(-7.98f, 0f, -72f);
    [SerializeField] private GameObject stud,Clockposs;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(stud, transform.position, Quaternion.identity, Clockposs.transform);
        }
    }
}
