using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{

    private Text levelText;
    private Image expBarimg;

    [SerializeField] private GameObject confetti;
    

    private LevelSystem levelSystem;

    public void Awake()
    {
        levelText = transform.Find("LvlUI").Find("Text").GetComponent<Text>();
        expBarimg = transform.Find("LvlUI").Find("lvlBar").GetComponent<Image>();
    }


    private void setExpBarSize(float expNormalized)
    {
        expBarimg.fillAmount = expNormalized;
    }

    private void setLvlNum(int lvlNum)
    {
        levelText.text = "LEVEL " + (lvlNum + 1);
        confetti.SetActive(false);
    }

    public void setLvlSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        //update restart values
        
        setLvlNum(levelSystem.GetLvLNum());
        setExpBarSize(levelSystem.GetExpNormalized());


        levelSystem.onExpChange += LevelSystem_onExpchange;
        levelSystem.onLvlChange += LevelSystem_onLvlChange;
    }

    private void LevelSystem_onExpchange(object sender, System.EventArgs e)
    {
        //Exp changed, updated UI
        setExpBarSize(levelSystem.GetExpNormalized());
    }

    private void LevelSystem_onLvlChange(object sender, System.EventArgs e)
    {
        //level changed, updated UI
        setLvlNum(levelSystem.GetLvLNum());
        confetti.SetActive(true);
        

    }

    /////BUTTON TESTING
    public void Onexp5()
    {
        
        levelSystem.addExp(5);
    }

    public void Onexp50()
    {
        
        levelSystem.addExp(50);
    }

  

    void Start()
    {
       // levelSystem = LevelSystem.instance;
    }

    private void Update()
    {
        
    }

}
