using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorUI : MonoBehaviour
{
    [SerializeField] public GameObject[] floorTxt;

    int indexer = 0;

    public void firstFloor()
    {
        floorTxt[0].SetActive(true);
        floorTxt[1].SetActive(false);
        floorTxt[2].SetActive(false);
    }
    public void secondFloor()
    {
        floorTxt[0].SetActive(false);
        floorTxt[1].SetActive(true);
        floorTxt[2].SetActive(false);
    }
    public void thirdFloor()
    {
        floorTxt[0].SetActive(false);
        floorTxt[1].SetActive(false);
        floorTxt[2].SetActive(true);
    }

    public void clickNext()
    {

        if (indexer > 3)
        {
            indexer = default;
        }

        else
        {
            indexer++;
        }

    }

    public void clickPrev()
    {

        if (indexer == 0)
        {
            indexer = 2;
        }

        else
        {
            indexer--;
        }

    }


    void Start()
    {
        
    }

    
    void Update()
    {
        switch (indexer)
        {
            case 1: { secondFloor(); } break;
            case 2: { thirdFloor(); } break;

            default:
                { firstFloor(); }
                break;
        }

    }

    
}

