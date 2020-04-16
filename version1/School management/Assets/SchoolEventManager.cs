using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SchoolEventManager : MonoBehaviour
{
    #region Singleton 
    public static SchoolEventManager instance = null;
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

    [Header("Text and Image")]
    public Text Title;
    public Text desc;
    public Text outcome;
    public Image displayImg;

    public GameObject panel;

    public int randomNum;
    public int randomImg;

    bool etriggered = false;

    public int happiness = 0;


    [Header("Event Header")]
    [SerializeField] public string[] eventHeader;

    [Header("Event Description")]
    [SerializeField] public string[] eventDescription;

    [Header("Event Outcome")]
    [SerializeField] public string[] eventOutcome;

    [Header("Event Img")]
    [SerializeField] public Sprite[] eventImage;

   
    
  

    public void randomGen()
    {
        randomNum = Random.Range(0, eventHeader.Length);
        randomImg = Random.Range(0, eventImage.Length);
    }
    public void callEventUI()
    {
        Title.text = eventHeader[randomNum];
        desc.text = eventDescription[randomNum];
        outcome.text = "Event Outcome: " + eventOutcome[randomNum];
        displayImg.sprite = eventImage[randomImg];

        happiness = Mathf.Clamp(happiness, 1, 10);
    }

   

    public void eventTriggered()
    {
        etriggered = true;
        panel.SetActive(true);
        randomGen();
        happinessEvent();

    }

    public void OkBTN()
    {
        panel.SetActive(false);
        etriggered = false;
    }

    public void happinessEvent()
    {
        if(eventOutcome.Equals("Possitive"))
        {
            happiness = 10;
        }
        else
        {
            happiness = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(etriggered == true)
        {
            callEventUI();
        }
        
    }

    //////// Possitive Events 
    ///  
    /// Food Fight
    /// A food fight has started at the cafeteria
    /// 
    /// Long Weekend
    /// All students are excited with this long weekend
    /// 
    /// Bonfire 
    /// Roast Mrshmallows, have camping games and sing songs.
    /// 
    /// Movie Night 
    /// Watch a football game on the football field or watch "Jaws" in the swimming pool.
    /// 
    /// Sumo Wrestling 
    /// An axe throwing teacher decided to rent the huge sumo outfits and hold a wrestling competition at the school.
    ///
    //////// Negative Events
    /// 
    /// Boom! 
    /// An explosion was heard from a magic class, experiement gone wrong.
    /// 
    /// Flu Season
    /// Both students and teachers are scared so they keep a distance from each other 
    /// 
    /// False Fire Alarm 
    /// students had to stay outside in the rain for an hour so now they're upset.
    /// 
    /// Exam Week 
    /// It's that time of the school year where almost all students are sleep deprived.
    /// 
    /// Power Outtage
    /// All the eletricity went out, all students are frightened.
}
