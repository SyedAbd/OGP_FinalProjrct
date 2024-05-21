using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.EventSystems;

public class WeaponSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] guns;
    private int currentGun = 0;
    Vector3 dropOff = Vector3.zero;

    Vector3 OnScreen = Vector3.zero;
    void Start()
    {
       // guns[0].SetActive(true);
    }
    public void NextGun()
    {
       // guns[currentGun].gameObject.GetComponent<>().
        guns[currentGun].SetActive(false);
        currentGun++;
        if (currentGun >= guns.Length)
            currentGun = 0;
        guns[currentGun].SetActive(true);

        //guns[currentGun].gun.;
        //Destroy(guns[currentGun].gun);
        //currentGun++;
        //if (currentGun >= guns.Length)
        //    currentGun = 0;
        //GameObject.Instantiate(guns[currentGun].gun, transform.position, transform.rotation * Quaternion.Euler(180f, 0f, 0f));
        //guns[currentGun].transform.position = dropOff
        //      currentGun++;
        //guns[currentGun].transform.position = OnScreen
    }
    public void PreviousGun()
    {
        guns[currentGun].SetActive(false);
        currentGun--;
        if (currentGun < 0)
            currentGun = guns.Length - 1;
        guns[currentGun].SetActive(true);
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("CHANGING GUN");
            NextGun();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            PreviousGun();
        }
    }
}
