using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScore : MonoBehaviour
{
    [SerializeField] public float score = 0f;
    [SerializeField] private TMPro.TMP_Text scoreTxtUI;
    public float Score
    {
        get { return score; }
        set { score = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreTxtUI.text = string.Format($"Score:{0}", score);
    }


    public void IncresePoint(float addIntoTheScore)
    {

        score += addIntoTheScore;
        

    }

    // Update is called once per frame
    void Update()
    {
         scoreTxtUI.text = $"Score: {score}";

    }
}
