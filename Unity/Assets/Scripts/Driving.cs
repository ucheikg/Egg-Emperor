using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamesAcademy.SerialPackage;

public class Driving : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private GameObject Player;

    void Start()
    {
        StopCoroutine(Slow());
        StopCoroutine(Breaks());
        StopCoroutine(Medium());
        StopCoroutine(Fast());
    }

    // Update is called once per frame
    void Update()
    {
        //if the arduino send over 1 then the player should move foward according to the speed set
        // the speed is decided by which boolean is true in the aurdino code as each if statee=ment only applies to its respective boolean that dont exist at the same time;

        if (SerialComManager.instance.GetDataFromArduino("o") == "1")
        {
            StartCoroutine(Breaks());
        }

        if (SerialComManager.instance.GetDataFromArduino("h") == "1")
        {
            StartCoroutine(Slow());
        }

        else if (SerialComManager.instance.GetDataFromArduino("n") == "1")
        {
            StartCoroutine(Medium());
        }

        else if (SerialComManager.instance.GetDataFromArduino("f") == "1")
        {
            StartCoroutine(Fast());
        }
    }

    IEnumerator Breaks()
    {
        Player.transform.Translate(Vector3.forward * 0f * Time.deltaTime);
        if (SerialComManager.instance.GetDataFromArduino("o") == "0")
        {
            yield break;
        }
    }

    IEnumerator Slow()
    {
        Player.transform.Translate(Vector3.forward * 25f * Time.deltaTime);
        if (SerialComManager.instance.GetDataFromArduino("h") == "0")
        {
            yield break;
        }
    }

    IEnumerator Medium()
    {
        Player.transform.Translate(Vector3.forward * 50f * Time.deltaTime);
        if (SerialComManager.instance.GetDataFromArduino("n") == "0")
        {
            yield break;
        }
    }

    IEnumerator Fast()
    {
        Player.transform.Translate(Vector3.forward * 100f * Time.deltaTime);
        if (SerialComManager.instance.GetDataFromArduino("f") == "0")
        {
            yield break;
        }
    }
}
