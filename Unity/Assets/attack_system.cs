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
        laser.SetActive(true);
        readyToFire = false;

        yield return new WaitForSeconds(laserduration);

        laser.SetActive(false);

        yield return new WaitForSeconds(cooldown);

        readyToFire = true;

    }
    IEnumerator Punch()
    {
        punchSpring.transform.position = Vector3.MoveTowards(punchSpring.transform.position, punchExtension.transform.position, speed);
        readyToPunch = false;

        yield return new WaitForSeconds(punchDuration);

        punchSpring.transform.position = Vector3.MoveTowards(punchSpring.transform.position, punchorigin.transform.position, speed);

        yield return new WaitForSeconds(punchCD);
        
        readyToPunch = true;

    }
}
