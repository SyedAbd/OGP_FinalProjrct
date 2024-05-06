using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    [SerializeField] private int poolSize = 40;
    


    [SerializeField] private List<GameObject> poolOfBullets;
    void Start()
    {
        LetsInitializeBullets();
       
    }
    private void LetsInitializeBullets()
    {
        poolOfBullets = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            poolOfBullets.Add(bullet);
        }
        Debug.Log("Bullets initialized: " + poolOfBullets.Count);

    }
    public GameObject GetUnusedBullets()
    {
        for (int i = 0;i < poolSize; i++)
        {
            if (!poolOfBullets[i].activeInHierarchy)
            {
                
                return poolOfBullets[i];
                
            }

        }
        Debug.Log("Bullet not returned");
        return null;



    }
    
    void Update()
    {
        
    }
}
