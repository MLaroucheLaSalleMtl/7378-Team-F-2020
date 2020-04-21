using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daycicle : MonoBehaviour
{
    private Transform start;
    void Start()
    {
        start = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.RotateAround(Vector3.zero, new Vector3(0,0,1), 1.4f * Time.deltaTime);
        gameObject.transform.LookAt(Vector3.zero);
    }

    public void Restartvalues()
    {
        gameObject.transform.position = start.position;
    }
}
