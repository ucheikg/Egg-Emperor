using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamesAcademy.SerialPackage;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    private float rotationSpeed = 50f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SerialComManager.instance.GetDataFromArduino("s") == "1")
        {
            Player.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (SerialComManager.instance.GetDataFromArduino("d") == "1")
        {
            Player.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
}
