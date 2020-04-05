using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraControl : MonoBehaviour
{

    private float MoveSpeed =30f;
    private bool Locked=false;
    private float scrollSpeed=5f;
    private float miny = 8f;
    private float maxy = 65f;
    private float RotationSpeed = 1;
    private Vector3 CamRotY=new Vector3(0f,2f,0f) ;
    [SerializeField] private float xRotationup = 10f;
    [SerializeField] private float xRotationdown = 90f;
    [SerializeField] private float leftLimit = -31f;
    [SerializeField] private float rightLimit = 31f;
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

        //if (Input.GetKey("left ctrl")){
        //    transform.Rotate(CamRotY, RotationSpeed * Time.deltaTime, Space.World);
        //}

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

        if (transform.position.y > xRotationup && transform.position.y < xRotationdown)
            transform.rotation = Quaternion.Euler(transform.position.y, transform.rotation.y, transform.rotation.z);

        Poss.y = Mathf.Clamp(Poss.y, miny, maxy);
        Poss.x = Mathf.Clamp(Poss.x, leftLimit, rightLimit);

        //rotate around Y axis
        if (Input.GetKey("e"))
        {
            transform.RotateAround(transform.position, Vector3.up, (250 * RotationSpeed * Time.deltaTime));
        }

        if (Input.GetKey("q"))
        {
            transform.RotateAround(transform.position, Vector3.up, -(250 * RotationSpeed * Time.deltaTime));
        }

        transform.position = Poss;
    }
}
