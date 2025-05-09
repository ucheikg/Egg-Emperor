using GamesAcademy.SerialPackage;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Playercamera;
    bool right;
    bool left;

    private float rotationSpeed = 50f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the arduino character s send over 1 then the player should turn to the left
        if (SerialComManager.instance.GetDataFromArduino("s") == "1")
        {
            right = true;

            while (right)
            {
                Playercamera.Rotate(0, rotationSpeed * Time.deltaTime, 0);

                if (SerialComManager.instance.GetDataFromArduino("s") == "0")
                {
                    break;
                }
                break;
            }
            right = false;
        }
        //if the arduino character d sends over 1 then the player should turn to the right
        if (SerialComManager.instance.GetDataFromArduino("d") == "1")
        {
            left = true;
            while (left)
            {
                Playercamera.Rotate(0, -rotationSpeed * Time.deltaTime, 0);

                if (SerialComManager.instance.GetDataFromArduino("d") == "0")
                {
                    break;
                }
                break;
            }
            left = false;
        }
    }
}
