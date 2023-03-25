using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public GameObject car;
    public Vector3 offset;


    void Start()
    {
        car = GameObject.Find("Sedan");
        offset = this.transform.position - car.transform.position;
    }

    void Update()
    {
        this.transform.position= car.transform.position + offset;
    }

}
