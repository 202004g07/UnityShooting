using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text score;
    float point;
    private void Start()
    {
        point = 0;
    }
    void Update()
    {
        score.text = $"SCORE: {point:000}";
    }
    public void AddScore()
    {
        point++;
    }
    public void AddScore(int num)
    {
        for (int i = 0; i < num; i++)
        {
            point++;
        }
    }
    public string GetScore()
    {
        return score.text;
    }
}
