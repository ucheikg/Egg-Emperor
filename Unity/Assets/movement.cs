using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamesAcademy.SerialPackage;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Playercamera;
    [SerializeField] private GameObject Player;

    private float rotationSpeed = 50f;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //if the arduino send over 1 then the player should turn to the left
        if (SerialComManager.instance.GetDataFromArduino("s") == "1")
        {
            Playercamera.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        //if the arduino send over 1 then the player should turn to the right
        if (SerialComManager.instance.GetDataFromArduino("d") == "1")
        {
            Playercamera.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        
        
        //if the arduino send over 1 then the player should move foward according to the speed set
        // the speed is decided by which boolean is true in the aurdino code as each if statee=ment only applies to its respective boolean that dont exist at the same time;
        if (SerialComManager.instance.GetDataFromArduino("h") == "1")
        {
            Player.transform.Translate(Vector3.forward * 15f * Time.deltaTime);
        }
        
        if (SerialComManager.instance.GetDataFromArduino("n") == "1")
        {
            Player.transform.Translate(Vector3.forward * 25f * Time.deltaTime);
        }
        
        if (SerialComManager.instance.GetDataFromArduino("f") == "1")
        {
            Player.transform.Translate(Vector3.forward * 50f * Time.deltaTime);
        }
    }
}
