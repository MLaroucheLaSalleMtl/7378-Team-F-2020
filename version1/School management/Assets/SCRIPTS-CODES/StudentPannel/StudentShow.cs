using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentShow : MonoBehaviour
{
    #region Singleton 
    public static StudentShow instance = null;
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

    [SerializeField] private GameObject StudentPanel;
    [SerializeField] private Transform pannelholder;
    [SerializeField] private GameObject bace;
    [SerializeField] private Sprite[] pics;

    public List<GameObject> Allpannels;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openStudentPanel()
    {
        StudentPanel.SetActive(true);
    }
    public void closePanel()
    {
        StudentPanel.SetActive(false);

    }

    public void CreateStudPan(StudentMono Student)
    {
        GameObject pannel = Instantiate(bace, pannelholder);
        if (Student.stdudentinfo.Gender1 == "Male")
        {
            pannel.transform.GetChild(0).GetComponent<Image>().sprite = pics[0];
        }else if (Student.stdudentinfo.Gender1 == "Female")
        {
            pannel.transform.GetChild(0).GetComponent<Image>().sprite = pics[1];
        }

        pannel.transform.GetChild(1).GetComponent<Text>().text = Student.stdudentinfo.SName1;
        pannel.transform.GetChild(2).GetComponent<Text>().text = "Class Wanted: "+Student.stdudentinfo.ClassIwant1;
        pannel.transform.GetChild(3).GetComponent<Text>().text = "Class Assigned: "+Student.stdudentinfo.ClassIgot1;
        pannel.transform.GetChild(4).GetComponent<Text>().text = "Happines:"+ Student.stdudentinfo.Happines1.ToString();
        pannel.transform.GetChild(5).GetComponent<Text>().text = "Hobbie: "+Student.stdudentinfo.Hobbie1;
        pannel.GetComponent<PannelSINfo>().student=Student.gameObject;
        Allpannels.Add(pannel);

    }

    public void RefreshPannels()
    {
        foreach (GameObject pan in Allpannels)
        {
            pan.GetComponent<PannelSINfo>().student.GetComponent<StudentMono>().DetermineHappines();
            pan.transform.GetChild(4).GetComponent<Text>().text = "Happines:" + pan.GetComponent<PannelSINfo>().student.GetComponent<StudentMono>().stdudentinfo.Happines1.ToString();
        }
    }

}
