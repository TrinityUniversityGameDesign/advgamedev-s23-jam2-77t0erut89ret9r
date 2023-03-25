using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private int speed = 5;
    public GameObject car;
    void Start()
    {
        car = GameObject.Find("Sedan");
    }


    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.W))
        {
            car.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        { 
            car.transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A)) { 
            car.transform.Rotate(0, -1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            car.transform.Rotate(0, 1, 0);
        }
        
    }
}
