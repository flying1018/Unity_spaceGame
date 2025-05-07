using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI starEvnet;
    public GameObject Star;

    public void ShowEvent(string tag)
    {
        switch (tag)
        {
            case "Star":
               // Star.starEvnet = false;
                break;
        }
    }
}
