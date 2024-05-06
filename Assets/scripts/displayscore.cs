using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class displayscore : MonoBehaviour
{
    [SerializeField] private TrackScore checkScore;
    public TextMeshProUGUI gameOverTxt;
    
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        score = checkScore.Score;
        if(score > 100 )
        gameOverTxt.text = $"you Scored: {score} Are you a hacker?";
        else if (score > 70)
            gameOverTxt.text = $"you Scored: {score} how did you do it?";
        else if (score > 50)
            gameOverTxt.text = $"you Scored: {score} this is good";
        else if (score > 30)
            gameOverTxt.text = $"you Scored: {score} you are catching up";
        else if (score > 20)
            gameOverTxt.text = $"you Scored: {score} a child could score better than you";
        else if (score > 15)
            gameOverTxt.text = $"you Scored: {score} are you sure you are playing?";
        else if (score > 7)
            gameOverTxt.text = $"you Scored: {score} couldn't be worse";
        else gameOverTxt.text = $"you Scored: {score} playing games is not for kids";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
