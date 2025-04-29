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
    [SerializeField] private GameObject Loading;

    void Start()
    {
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {
        if (SerialComManager.instance.GetDataFromArduino("s") == "1")
        {
            Playercamera.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }

        if (SerialComManager.instance.GetDataFromArduino("d") == "1")
        {
            Playercamera.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
        
        
        
        if (SerialComManager.instance.GetDataFromArduino("h") == "1")
        {
            Player.transform.position = Vector3.forward(Player.transform * 10f * )   
        }
        
        if (SerialComManager.instance.GetDataFromArduino("n") == "1")
        {

        }
        
        if (SerialComManager.instance.GetDataFromArduino("f") == "1")
        {

        }
    }

    IEnumerator Delay()
    {
        Loading.SetActive(true);

        yield return new WaitForSeconds(30f);
        
        Loading.SetActive(false);
    }
}
