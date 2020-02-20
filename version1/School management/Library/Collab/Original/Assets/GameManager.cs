using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [SerializeField] private float money;
    public Text moneyText;

    private int StudentCount;
    Text StudentCountText;//"StudentCount"
    Vector3 LocationOfSpawn=new Vector3(6,1,2);
    public static GameManager instance = null;

    string[] Clasesbogth;

    //Percy wtf is Haking? like stealing paswoords type of shit

    string[] AvalableClases= {"Magic","Surfing","Hacking","Axe Trowing"};

    

    List<string> Clases;

    [Header("Student Prefab Toinstanciate")]
    [SerializeField]private GameObject Student;


  

    

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

    void Start()
    {
        gameManager = this; //only one
        UpdateUI();

        StudentCountText =GameObject.FindGameObjectWithTag("StudentCount").GetComponent<Text>();
        
    }

    
    void Update()
    {
        RefreshTextOnUI();
        UpdateUI();
    }

    /// money
    public void AddMoney(float amount)
    {
        money += amount;
        UpdateUI();
    }

    public void ReduceMoney(float amount)
    {
        money -= amount;
        UpdateUI();
    }

    public bool RequestMoney(float amount)
    {
        if (amount <= money)
        {
            return true;
        }
        return false;
    }

    void UpdateUI()
    {
        moneyText.text = "$ " + money.ToString("N0");
    }



    /// student
    public void AddStudent()
    {
        StudentCount++;

    }

    public void RefreshTextOnUI()
    {
        StudentCountText.text = "Students: "+StudentCount;
    }

    public void Spawn(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(Student, LocationOfSpawn, Quaternion.identity);
        }
    }
}
