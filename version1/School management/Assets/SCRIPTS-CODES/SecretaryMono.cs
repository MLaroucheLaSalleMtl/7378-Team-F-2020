using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretaryMono : MonoBehaviour
{
    public static SecretaryMono instance = null;
    #region Instance
   
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

    GameManager gameManager;

    Administration administration;

    secretaryManager secManager;


    [SerializeField]
    private int hiringCost;

    [SerializeField]
    private float efficiency;

    public float Efficiency { get => efficiency; set => efficiency = value; }
    public int HiringCost { get => hiringCost; set => hiringCost = value; }

    void Start()
    {
        //administration.Isthereasecretary = true;

        gameManager = GameManager.instance;
        administration = Administration.instance;
        secManager = secretaryManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
