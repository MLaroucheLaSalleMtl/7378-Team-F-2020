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

    [Header("Text and Image")]
    public Text weather;
    public Text outcome;
    public Image displayImg;

    public int happiness = 0;

    public int randomNum;

    [Header("weather type")]
    [SerializeField] public string[] WeatherStatus;

    [Header("weather Anim")]
    [SerializeField] public GameObject[] weatherAnim;

    [Header("Weather Icons")]
    [SerializeField] public Sprite[] weatherImgs;

    [Header("weather Outcome")]
    [SerializeField] public int[] happinessOutcome;

    public void randomGen()
    {
        randomNum = Random.Range(0, weatherImgs.Length);
    }

    public void callWeatherUI()
    {
        weather.text = WeatherStatus[randomNum];
        displayImg.sprite = weatherImgs[randomNum];
        happiness = happinessOutcome[randomNum];
        weatherAnim[randomNum].SetActive(true);

        happiness = Mathf.Clamp(happiness, 1, 5);
    }

    public void RandomWeather()
    {
        clearWeatherEffects();
        randomGen();
    }

    public void clearWeatherEffects()
    {
        weatherAnim[randomNum].SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //RandomWeather();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonUp("R"))
        {
            RandomWeather();
        }


        callWeatherUI();
    }
}
