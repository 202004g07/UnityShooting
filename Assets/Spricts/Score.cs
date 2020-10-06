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
        score.text = $"Score: {point:000}";
    }
    public void AddScore()
    {
        point++;
    }
}
