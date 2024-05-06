using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecifiedShooting : ShootBullets
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private float nextBulletTimer;
    // Update is called once per frame
    void Update()
    {

        if (auto)
        {
            if (Input.GetMouseButtonDown(0)&& Time.time >= nextBulletTimer)
            {
                Debug.Log("Gonna shoot some bullets");
                StartCoroutine(Shoot());
                nextBulletTimer= Time.time + 1f/fireRate;
            }

        }
        else
        {
            if (Input.GetMouseButton(0) && Time.time >= nextBulletTimer)
            {

                StartCoroutine(Shoot());
                nextBulletTimer = Time.time + 1f / fireRate;
            }

            

        }
    }
}
