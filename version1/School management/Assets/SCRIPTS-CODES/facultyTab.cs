using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facultyTab : MonoBehaviour
{
    [SerializeField] public GameObject[] Tabs;

    public void OpenTeachersTab()
    {
        Tabs[0].SetActive(true);
        Tabs[1].SetActive(false);
        Tabs[2].SetActive(false);
    }

    public void OpenAdminTab()
    {
        Tabs[0].SetActive(false);
        Tabs[1].SetActive(true);
        Tabs[2].SetActive(false);
    }

    public void OpenCJTab()
    {
        Tabs[0].SetActive(false);
        Tabs[1].SetActive(false);
        Tabs[2].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Tabs[0].SetActive(true);
        Tabs[1].SetActive(false);
        Tabs[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
