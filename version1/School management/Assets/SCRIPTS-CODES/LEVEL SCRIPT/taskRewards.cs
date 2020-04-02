using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class taskRewards : MonoBehaviour
{
    GameManager gamemanager;

    tasks Task; 

    public static taskRewards instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //Destroy(gameObject);
        }

    }

    [SerializeField] private int exp;
    [SerializeField] private int gold;

    public enum TypeOfRewards
    {
        none,
        small, 
        medium, 
        large
    }

    public TypeOfRewards reward;

    public int Exp { get => exp; set => exp = value; }
    public int Gold { get => gold; set => gold = value; }

    public void rewardSystem()
    {
        switch (reward)
        {
            case TypeOfRewards.small:
                Exp = 50;
                Gold = 25;
                gamemanager.addExp(Exp);
                gamemanager.AddMoney(Gold);
                break;
            case TypeOfRewards.medium:
                Exp = 100;
                Gold = 50;
                gamemanager.addExp(Exp);
                gamemanager.AddMoney(Gold);
                break;
            case TypeOfRewards.large:
                Exp = 150;
                Gold = 100;
                gamemanager.addExp(Exp);
                gamemanager.AddMoney(Gold);
                break;
            default:
                Debug.Log("None");
                break;

        }
    }

   public void showRewards()
    {
        switch (reward)
        {
            case TypeOfRewards.small:
                Exp = 50;
                Gold = 25;   
                break;
            case TypeOfRewards.medium:
                Exp = 100;
                Gold = 50;
                break;
            case TypeOfRewards.large:
                Exp = 150;
                Gold = 100;
                break;
            default:
                Debug.Log("None");
                break;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameManager.instance;
        Task = tasks.instance;

        showRewards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
