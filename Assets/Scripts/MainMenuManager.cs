using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SOPoints _SOPoints;
    [SerializeField] TextMeshProUGUI _maxPointsText;
    void Start()
    {
        _maxPointsText.text = "Max Score:" + _SOPoints.CurrentPoints.ToString();
    }

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
