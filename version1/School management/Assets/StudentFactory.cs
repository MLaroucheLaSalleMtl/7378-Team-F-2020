using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentFactory : MonoBehaviour
{
    #region Singleton
    public static StudentFactory instance = null;
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

    #region Students Name

    private string PathGirlNames = "Assets/Resources/test.txt";
    private string PathBoyNames = "Assets/Resources/test.txt";
    private string PathLastNames = "Assets/Resources/test.txt";



    #endregion
    //private Student GetStudent()
    //{

    //}


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
