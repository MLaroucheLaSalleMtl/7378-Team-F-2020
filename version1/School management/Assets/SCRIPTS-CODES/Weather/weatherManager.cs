using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class weatherManager : MonoBehaviour
{
    #region Singleton 
    public static weatherManager instance = null;
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

    GameTime timemanager;
    GameManager gamemanager;

    [Header("Text and Image")]
    public Text weather;
    public Text outcome;
    public Image displayImg;

    public int happiness = 0;

    public int randomNum;

    bool activate = false;

    [Header("weather type")]
    [SerializeField] public string[] WeatherStatus;

    [Header("weather Anim")]
    [SerializeField] public GameObject[] weatherAnim;

    [Header("Weather Icons")]
    [SerializeField] public Sprite[] weatherImgs;

    [Header("weather Outcome")]
    [SerializeField] public int[] happinessOutcome;

    public void randomWeatherSeason()
    {
        //summer
        if (timemanager.Month == 5 || timemanager.Month == 7 || timemanager.Month == 8 || timemanager.Month == 6) 
        {
            randomNum = Random.Range(0, 5);
        }

        //fall
        else if (timemanager.Month == 1 || timemanager.Month == 11 || timemanager.Month == 12)
        {
            randomNum = Random.Range(3, 6);
        }

        //winter
        else if (timemanager.Month == 9 || timemanager.Month == 10)
        {
            randomNum = Random.Range(0, 5);
        }
    }

    public void callWeatherUI()
    {
        weather.text = WeatherStatus[randomNum];
        displayImg.sprite = weatherImgs[randomNum];
        happiness = happinessOutcome[randomNum];
        //weatherAnim[randomNum].SetActive(true);

        happiness = Mathf.Clamp(happiness, 1, 5);
    }

    public void RandomWeather()
    {
        clearWeatherEffects();
        activate = true;
        randomWeatherSeason();
    }

    public void clearWeatherEffects()
    {
        //weatherAnim[randomNum].SetActive(false);
        activate = false;
    }

    // Start is called before the first frame update
    void Start()
    {

        gamemanager = GameManager.instance;
        timemanager = GameTime.instance;


        RandomWeather();

       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonUp("R"))
        {
            randomWeatherSeason();
        }

        if (activate == true)
        {
            callWeatherUI();
        }
        
    }
}
