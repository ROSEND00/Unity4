using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    // Update is called once per frame
    void Update()
    {
        currentScoreText.text = "Score  " + GameManager.singleton.currentScore;
        bestScoreText.text = "Best  " + GameManager.singleton.bestscore;
    }
}
