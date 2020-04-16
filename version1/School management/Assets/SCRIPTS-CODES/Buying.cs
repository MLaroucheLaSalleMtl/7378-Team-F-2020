using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buying : MonoBehaviour
{
    GameManager gamemanager;

    public GameObject Buyingmenu;

    private PlayerLog eventLog;

    public static bool buyingMenuUI = false;

    Buildingmanager buildmanager;

    [Header("Unlock pannels in the Facility menu")]
    [SerializeField] public GameObject[] Pannel;

    void Start()
    {
        buildmanager = Buildingmanager.instance;
        eventLog = GetComponent<PlayerLog>();
        gamemanager = GameManager.instance;
        
        unlockPannels();
    }

     void Update()
    {
        unlockPannels();
    }

    public void BuyMagicClass()
    {

        buildmanager.SetClass(buildmanager.ClassesPrefavs[0]);
        Buyingmenu.SetActive(false);
        eventLog.AddEvent("Bought a Magic Classroom!");

    }
    public void BuyAxeThrowingClass()
    {

        buildmanager.SetClass(buildmanager.ClassesPrefavs[1]);
        Buyingmenu.SetActive(false);
        eventLog.AddEvent("Bought a Axe Throwing Classroom!");
    }
    public void BuyShurfClass()
    {

        buildmanager.SetClass(buildmanager.ClassesPrefavs[2]);
        Buyingmenu.SetActive(false);
        eventLog.AddEvent("Bought a Surfing Classroom!");
    }
    public void BuyHakingClass()
    {

        buildmanager.SetClass(buildmanager.ClassesPrefavs[3]);
        Buyingmenu.SetActive(false);
        eventLog.AddEvent("Bought a Hacking Classroom!");
    }
    public void BuyChillingPlace()
    {

        buildmanager.SetClass(buildmanager.ClassesPrefavs[4]);
        Buyingmenu.SetActive(false);
        eventLog.AddEvent("Bought a Chilling PLace!");
    }
    public void BuyBathroomPlace()
    {

        buildmanager.SetClass(buildmanager.ClassesPrefavs[5]);
        Buyingmenu.SetActive(false);
        eventLog.AddEvent("Bought a Bathroom!");
    }
    public void DisplayBuyingMenu()
    {
        Buyingmenu.SetActive(true);
        buyingMenuUI = true;
    }

    public void ExitBuyingMenu()
    {
        Buyingmenu.SetActive(false);
        buyingMenuUI = false;
    }

    public void DoFacilityMenu()
    {
        if (buyingMenuUI)
        {
            ExitBuyingMenu();
            Debug.Log("facility menu OFF");
        }
        else
        {
            DisplayBuyingMenu();
            Debug.Log("facility menu ON");

        }
    }
    

    public void unlockPannels()
    {
        //hacking
        if (gamemanager.PlayerLevel == 5)
        {
            Destroy(Pannel[0]);
        }

        //surfing
        if (gamemanager.PlayerLevel == 10)
        {
            Destroy(Pannel[1]);
        }

        //axe throwing
        if (gamemanager.PlayerLevel == 15)
        {
            Destroy(Pannel[2]);
        }

    }

}
