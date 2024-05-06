using System.Collections;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private TrackScore forScore;
    private float score;
    public TextMeshProUGUI timerText;
    private float countdownTime = 60f;

    void Start()
    {
        score = forScore.Score;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while (countdownTime >= 0)
        {
            UpdateTimerDisplay();
            yield return new WaitForSeconds(1f);
            countdownTime -= 1f;
        }

        EndGame();
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(countdownTime / 60f);
        int seconds = Mathf.FloorToInt(countdownTime % 60f);

       
        timerText.SetText(string.Format("{0:00}:{1:00}", minutes, seconds));
    }

    void EndGame()
    {
        gameOver.SetActive(true);
        
    }
}
