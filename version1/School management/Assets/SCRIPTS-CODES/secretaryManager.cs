using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class secretaryManager : MonoBehaviour
{
    public static secretaryManager instance = null;
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

    [Header("Secretary position")]
    [SerializeField] private Vector3 sPossitionOfcet;

    [Header("Randomize Number")]
    [SerializeField] public int[] randomNum;

    [Header("Secretary Name")]
    [SerializeField] public Text[] secretaryNametxt;

    [Header("Secretary Icons")]
    [SerializeField] public Image[] secretaryIcons;

    [Header("Secretary Pictures")]
    [SerializeField] public Sprite[] secretaryPortrait;

    [Header("Secretary Efficency txt")]
    [SerializeField] public Text[] efficencytxt;

    [Header("Efficency number")]
    [SerializeField] public string[] Efficency;

    [Header("Secretary Prefabs")]
    [SerializeField] public GameObject[] secretary;

    private GameObject SecretaryTohire;

    SecretaryMono adminMono;

    public void secretaryNames()
    {
        secretary[0].name = "Joe";                //2
        secretary[1].name = "Jill";               //2
        secretary[2].name = "Mark";               //3
        secretary[3].name = "Maurice";            //4       
        secretary[4].name = "Jack";               //5
        secretary[5].name = "Cherie";             //5
    }

    public void RandomGenNum()
    {
        randomNum[0] = Random.Range(0, secretary.Length);
        randomNum[1] = Random.Range(0, secretary.Length);
    }

    public void secretaryAvatar()
    {
        secretaryIcons[0].sprite = secretaryPortrait[randomNum[0]];
        secretaryIcons[1].sprite = secretaryPortrait[randomNum[1]];
    }

    public void secretaryUInames()
    {
        secretaryNametxt[0].text = secretary[randomNum[0]].ToString();
        secretaryNametxt[1].text = secretary[randomNum[1]].ToString();
    }

    public void efficencytxtUI()
    {
        efficencytxt[0].text = "Efficency: " + Efficency[randomNum[0]];
        efficencytxt[1].text = "Efficency: " + Efficency[randomNum[1]];
    }


    ///hire secretary 
    public void HireSecretaryOne()
    {
        Instantiate(secretary[randomNum[0]], sPossitionOfcet, Quaternion.identity);

    }

    public void HireSecretaryTwo()
    {
        Instantiate(secretary[randomNum[1]], sPossitionOfcet, Quaternion.identity);
    }



    public GameObject GetSecretaryTohire()
    {
        return SecretaryTohire;
    }

    public void SetSecretary(GameObject Sec)
    {
        SecretaryTohire = Sec;
    }

    public void GenerateRanNum()
    {
        RandomGenNum();
    }


    ///start

    void Start()
    {
        RandomGenNum();
    }

    
    void Update()
    {
        if (Input.GetButtonUp("R"))
        {
            RandomGenNum();
        }

        secretaryNames();
        secretaryUInames();
        secretaryAvatar();
        efficencytxtUI();
    }
}
