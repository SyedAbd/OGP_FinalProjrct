using UnityEngine;

public class ScoreCheck : MonoBehaviour
{
    private const string BulletTag = "Bullet";

    public enum PointCategory
    {
        Points12,
        Points6,
        Points3
    }

    public PointCategory pointCategory;

    private int GetPointsForCategory(PointCategory category)
    {
        switch (category)
        {
            case PointCategory.Points12:
                return 12;
            case PointCategory.Points6:
                return 6;
            case PointCategory.Points3:
                return 3;
            default:
                return 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(BulletTag))
        {
            int points = GetPointsForCategory(pointCategory);
            if (points > 0)
            {
                Debug.Log($"{points} points! Yeeeeeeeeeeeee grapeeeeeeeeeee");
                // You can add your score-handling logic here
            
            }
        }
    }
}
