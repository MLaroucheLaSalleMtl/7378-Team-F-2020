using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{

    private float MoveSpeed =30f;
    private bool Locked=false;
    private float scrollSpeed=5f;
    private float miny = 10f;
    private float maxy = 80f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y"))
            Locked = !Locked;
        if (!Locked)
            return;
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.World);
        }
        float scrollig = Input.GetAxis("Mouse ScrollWheel");
        Vector3 Poss = transform.position;
        Poss.y -= scrollig * 1000 * scrollSpeed * Time.deltaTime;
        Poss.y = Mathf.Clamp(Poss.y, miny, maxy);

        transform.position = Poss;
    }
}
