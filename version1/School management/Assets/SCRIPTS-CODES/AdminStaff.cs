using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminStaff : MonoBehaviour
{
    GameManager gameManager;

    Administration administration;

    #region Instance
    public static AdminStaff instance = null;
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
 

    [SerializeField]
    private float efficiency;

    public float Efficiency { get => efficiency; set => efficiency = value; }

    void Start()
    {
        //administration.Isthereasecretary = true;

        gameManager = GameManager.instance;
        administration = Administration.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
