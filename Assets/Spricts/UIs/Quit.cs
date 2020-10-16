using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [SerializeField] private Button QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        QuitButton.onClick.AddListener(AppQuit);
    }
    public void AppQuit()
    {
        Application.Quit();
    }
}
