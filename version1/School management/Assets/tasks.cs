using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tasks : MonoBehaviour
{
    public static GameManager gameManager;


    [SerializeField] private GameObject[] taskPanels;
    [SerializeField] private GameObject[] taskBTNS;

    //coinGoals
    [Header("Objectives 2")]
    public int coinGoal = 500; //player must make this much money to complete Objective 2


    [Header("Objectives 1")]
    public int classRoom = 1; //player must have this many classes built to complete Objective 1

  

    public void classRoomGoals()
    {
        if (GameManager.gameManager.ClassRCount >= classRoom)
        {
            if (taskPanels[1] != null)
            {
                taskPanels[1].SetActive(false);
            }

            Destroy(taskBTNS[1].gameObject);

            taskPanels[0].SetActive(true);
            taskBTNS[0].SetActive(true);

        }

        else
        {
            taskPanels[1].SetActive(true);
        }
    }

    public void coinGoals()
    {
        if (GameManager.gameManager.Money >= coinGoal)
        {
            if (taskPanels[0] != null)
            {
                taskPanels[0].SetActive(false);

            }

            Destroy(taskBTNS[0].gameObject);
        }

        else
        {
            taskPanels[0].SetActive(true);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        taskPanels[0].SetActive(false);
        taskBTNS[0].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
