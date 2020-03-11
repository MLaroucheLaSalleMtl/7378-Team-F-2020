using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buying : MonoBehaviour
{
    public GameObject Buyingmenu;

    public static bool buyingMenuUI = false;

    Buildingmanager buildmanager;
    void Start()
    {
        buildmanager = Buildingmanager.instance;
        //Buyingmenu = GameObject.Find("BuyingPanel");
    }
    public void BuyMagicClass()
    {
        buildmanager.SetClass(buildmanager.ClassesPrefavs[0]);
        Buyingmenu.SetActive(false);

    }
    public void BuyAxeThrowingClass()
    {
        buildmanager.SetClass(buildmanager.ClassesPrefavs[1]);
        Buyingmenu.SetActive(false);
    }
    public void BuyShurfClass()
    {
        buildmanager.SetClass(buildmanager.ClassesPrefavs[2]);
        Buyingmenu.SetActive(false);
    }
    public void BuyHakingClass()
    {
        buildmanager.SetClass(buildmanager.ClassesPrefavs[3]);
        Buyingmenu.SetActive(false);
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

}
