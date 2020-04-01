using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel : MonoBehaviour
{


    public GameObject Panel;
    public GameObject Task;
    

    //pop up message
    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);

            //Animation: Make task go to the actual place
            Animator animator = Task.GetComponent<Animator>();
            animator.SetBool("Move", true);

        }

      
        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
