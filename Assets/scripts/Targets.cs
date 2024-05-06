using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : BasicTargetFunctions
{
    private const string BulletTag = "Bullet";
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public enum PointCategory
    {
        outerRing,
        middleRing,
        innerRing
    }

    public PointCategory pointCategory;

    private int GetPointsForCategory(PointCategory category)
    {
        switch (category)
        {
            case PointCategory.outerRing:
                return 2;
            case PointCategory.middleRing:
                return 4;
            case PointCategory.innerRing:
                return 6;
            default:
                return 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log($" Yeeeeeeeeeeeee grapeeeeeeeeeee");

    //    if (other.CompareTag(BulletTag))
    //    {
    //        int points = GetPointsForCategory(pointCategory);
    //        if (points > 0)
    //        {
    //            Debug.Log($"{points} ponts!!!! Yeeeeeeeeeeeee grapeeeeeeeeeee");
    //            UpdateScore(points);

    //        }
    //    }




    //}
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Yeeeeeeeeeeeee grapeeeeeeeeeee");

        if (collision.collider.CompareTag(BulletTag))
        {
            int points = GetPointsForCategory(pointCategory);
            if (points > 0)
            {
                UpdateScore(points);
                Debug.Log($"Score updated by {points} points");
                if (points == 2)
                {
                    transform.gameObject.SetActive(false);
                }
                else
                {
                    transform.parent.gameObject.SetActive(false);
                }
                
            }
            
        }
    }



}
