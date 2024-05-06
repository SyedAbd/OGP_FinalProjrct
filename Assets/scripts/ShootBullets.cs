using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    [SerializeField] BulletsPool bullets;
    public Transform fireFrom;
    private float bulletActiveDuration = 2.0f;
    [SerializeField] protected float fireRate;
    [SerializeField] protected bool auto;
    [SerializeField] protected float bulletSpeed = 50f;
    [SerializeField] protected int bulletCount = 40;
    [SerializeField] protected float reloadingDuration = 10.0f;
    [SerializeField] public GameObject reloadingText;
    [SerializeField] private int bulletCount2;
    private bool reloading = false;
    void Start()
    {
         bulletCount2  = bulletCount;
        //bullets = new BulletsPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected IEnumerator Shoot()
    {
        if (bulletCount <= 0 || reloading) yield break;
        bulletCount--;
        if (bulletCount <= 0)
        {
            Debug.LogWarning("Reloading");
            reloadingText.SetActive(true);
            reloading = true;

            yield return StartCoroutine(WaitForReloading(reloadingDuration));
            reloading = false;
            reloadingText.SetActive(false);
            bulletCount = bulletCount2;
        }

        GameObject bullet = bullets.GetUnusedBullets();
        if (bullet != null)
        {
            bullet.SetActive(true);
            bullet.transform.position = fireFrom.position;
            bullet.transform.rotation = fireFrom.rotation;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
            

            StartCoroutine(DeactivateBulletAfterDuration(bullet, bulletActiveDuration));
        }
        else
        {
            Debug.LogWarning("No unused bullets in the pool!");
        }
    }

    IEnumerator WaitForReloading(float reloadingDuration)
    {

        yield return new WaitForSeconds(reloadingDuration);
    }
    IEnumerator DeactivateBulletAfterDuration(GameObject bullet, float duration)
    {
       
        yield return new WaitForSeconds(duration);

       
        bullet.SetActive(false);
    }
}
