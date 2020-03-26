using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireSecretary : MonoBehaviour
{
    private GameManager gameManager;

    private GameObject sStaff;

    private tasks Tasks;

    secretaryManager secretarymanager;

    SecretaryMono secretarymono;

    SpawnAdmin adminScript;

    Administration admin;

    private PlayerLog eventLog;

    private bool okayToHire = false;

    [Header("Secretary's Spawn point")]
    [SerializeField] private Vector3 secretaryPosition;

    [Header("Secretary is facing towards the counter")]
    [SerializeField] private Vector3 RotationOfcet;

    // put sparkle for objective once you are able to instantiate the secretary prefabs

    void Start()
    {
        gameManager = GameManager.instance;
        admin = Administration.instance;
        secretarymanager = secretaryManager.instance;
        secretarymono = SecretaryMono.instance;
        Tasks = tasks.instance;
        adminScript = SpawnAdmin.instance;

        eventLog = PlayerLog.instance;
    }


    void Update()
    {

    }

    private void OnMouseDown()
    {

        if (secretarymanager.GetSecretaryTohire() == null)
        {
            eventLog.AddEvent("Hire a Secretary from the Administration Tab!");
            Debug.Log("Hire a Secretary from the Administration Tab!");
            return;
        }
        
        if (gameManager.Money < secretarymanager.GetSecretaryTohire().GetComponent<SecretaryMono>().HiringCost)
        {
            eventLog.AddEvent("Not enough money to hire this secretary!");
            Debug.Log("Not enough money to hire this secretary!");
            return;
        }

        
        
            okayToHire = true;

            admin.Isthereasecretary = true;

            GameObject SecretaryTohire = secretarymanager.GetSecretaryTohire();
            sStaff = Instantiate(SecretaryTohire, secretaryPosition, transform.rotation * Quaternion.Euler(RotationOfcet));

            //how much the secretary cost to hire
            gameManager.ReduceMoney(SecretaryTohire.GetComponent<SecretaryMono>().HiringCost);

            //salary 


            //secretary wont be duplicated
            secretarymanager.SetSecretary(null);

        


        // put task here 
        Destroy(gameObject);
        // no tool tips for now


    }

}
