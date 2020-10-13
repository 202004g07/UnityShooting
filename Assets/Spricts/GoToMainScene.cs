using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainScene : MonoBehaviour
{
    private void Start()
    {
        Screen.SetResolution(580, 1028, false, 60);
    }
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
