using GamesAcademy.SerialPackage;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;

public class change : MonoBehaviour
{
    float cooldown = 10f;
    float punchCD = 3f;
    float laserduration = 15f;
    float punchDuration = 4f;
    bool readyToFire = true;
    bool readyToPunch = true;
    float speed = 15f;
    // attacks
    [SerializeField] private GameObject laser;
    [SerializeField] private GameObject punchSpring;
    [SerializeField] private GameObject punchorigin;
    [SerializeField] private GameObject punchExtension;
    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        // if unity recives a one from the arduino meaning that the bool there is true then it should start the coroutine
        if (readyToFire && SerialComManager.instance.GetDataFromArduino("b") == "1")
        {
            StartCoroutine(LaserAttack());
        }
        if (readyToPunch && SerialComManager.instance.GetDataFromArduino("q") == "0")
        {
            StartCoroutine(Punch());
        }
    } 

    IEnumerator LaserAttack()
    {
        // activate laser and makes it inactive
        laser.SetActive(true);
        readyToFire = false;
        // how long the laser lasts;
        yield return new WaitForSeconds(laserduration);
        //laser turns off
        laser.SetActive(false);
        // cooldown starts 
        yield return new WaitForSeconds(cooldown);
        // cooldown is over and laser can be fired again
        readyToFire = true;

    }
    IEnumerator Punch()
    {
        // punching spring moves foward toward and empty game object and makes punch spring inactive
        punchSpring.transform.position = Vector3.MoveTowards(punchSpring.transform.position, punchExtension.transform.position, speed);
        readyToPunch = false;
        // how long the ounch will be there before it retracts
        
        yield return new WaitForSeconds(punchDuration);
        
        // punch spring retracts to origin
        punchSpring.transform.position = Vector3.MoveTowards(punchSpring.transform.position, punchorigin.transform.position, speed);
        // cooldown becomes active
        
        yield return new WaitForSeconds(punchCD);
        // cooldown is done and player can now punch again
        readyToPunch = true;

    }
}
