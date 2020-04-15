using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class publicity : MonoBehaviour
{
    #region Singleton 
    public static publicity instance = null;
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
    #endregion

    [SerializeField]private GameObject publicityPanel;

    GameManager gamemanager;
    PlayerLog eventLog;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.instance;
        eventLog = GetComponent<PlayerLog>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void openPublicityPanel()
    {
        publicityPanel.SetActive(true);
    }
    public void closePanel()
    {
        publicityPanel.SetActive(false);

    }

    public void newspaper()
    {
        if (gamemanager.Playerpublicity == 100)
        {
            eventLog.AddEvent("You've reached the max Publicity");
            Debug.Log("You've reached the max Publicity");
            return;
        }
        else
        {
            if (gamemanager.Money < 100)
            {
                eventLog.AddEvent("Not enough Gold to unlock");
                Debug.Log("Not enough Gold to unlock");
                return;
            }
            else
            {
                gamemanager.ReduceMoney(100);
                gamemanager.addPub(10);
            }
        }
    }

    public void TV()
    {
        if (gamemanager.Playerpublicity == 100)
        {
            eventLog.AddEvent("You've reached the max Publicity");
            Debug.Log("You've reached the max Publicity");
            return;
        }
        else
        {
            if (gamemanager.Money < 160)
            {
                eventLog.AddEvent("Not enough Gold to unlock");
                Debug.Log("Not enough Gold to unlock");
                return;
            }
            else
            {
                gamemanager.ReduceMoney(160);
                gamemanager.addPub(15);
            }
        }
    }

    public void online()
    {
        if (gamemanager.Playerpublicity == 100)
        {
            eventLog.AddEvent("You've reached the max Publicity");
            Debug.Log("You've reached the max Publicity");
            return;
        }
        else
        {
            if (gamemanager.Money < 220)
            {
                eventLog.AddEvent("Not enough Gold to unlock");
                Debug.Log("Not enough Gold to unlock");
                return;
            }
            else
            {
                gamemanager.ReduceMoney(220);
                gamemanager.addPub(20);
            }
        }
    }



}
