using UnityEngine;
using TMPro;

public class TrackScore : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreTxtUI;

    public float Score
    {
        get { return score; }
        set
        {
            score = value;
            UpdateScoreText();
        }
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreTxtUI.text = $"Score: {score}";
    }

    public void IncreasePoint(float pointsToAdd)
    {
        Score += pointsToAdd;
    }
}
