using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI gameOver;
    public GameObject retryButton;
    public GameObject Star;

    static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
    }


    public void RetryButton()
    {
        SceneManager.LoadScene("MainScene");
    }
}
