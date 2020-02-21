using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class mainMenuBTN : MonoBehaviour
{
    //ON & OFF
    public static bool mainMenu = false;

    /// Buttons 
    public GameObject btnStaff;
    public GameObject btnStudent;
    public GameObject btnFacility;
    public GameObject btnPublicity;
    public GameObject halfCircle;



    public void DoMainMenu()
    {
        if (mainMenu)
        {
            OffMainMenu();
            Debug.Log("main menu OFF");
        }
        else
        {
            OnMainMenu();
            Debug.Log("main menu ON");
        }
    }

    public void OnMainMenu()
    {
        btnStaff.SetActive(true);
        btnStudent.SetActive(true);
        btnFacility.SetActive(true);
        btnPublicity.SetActive(true);
        halfCircle.SetActive(true);
        mainMenu = true;
}

    public void OffMainMenu()
    {
        btnStaff.SetActive(false);
        btnStudent.SetActive(false);
        btnFacility.SetActive(false);
        btnPublicity.SetActive(false);
        halfCircle.SetActive(false);
        mainMenu = false;
}

    // Start is called before the first frame update
    void Start()
    {
        btnStaff.SetActive(false);
        btnStudent.SetActive(false);
        btnFacility.SetActive(false);
        btnPublicity.SetActive(false);
        halfCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
