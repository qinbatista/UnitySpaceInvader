using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> _lifeList;
    [SerializeField] GameObject _settingPanel;
    [SerializeField] SOPoints _SOPoints;
    [SerializeField] TextMeshProUGUI _pointsText;
    [SerializeField] TextMeshProUGUI _gameLevelText;
    [SerializeField] int _gameLevel = 1;
    int _life = 3;

    public int GameLevel { get => _gameLevel; }

    void Start()
    {
        _settingPanel.SetActive(false);
        _SOPoints.ResetPoints();
        _pointsText.text = "Score:0";
        _gameLevelText.text = "Level:1";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.transform != null && raycastHit.transform.tag == "Enemey")
                {
                    //Our custom method.
                    raycastHit.transform.GetComponent<RoleRunner>().OnHit();
                    _SOPoints.AddPoints();
                    _pointsText.text = "Score:" + _SOPoints.CurrentPoints.ToString();
                }
            }
        }
    }
    public void ReducedLife()
    {
        _life--;
        if (_life > 0) _lifeList[_life].SetActive(false);
        if (_life == 0)
        {
            Time.timeScale = 0;
            _settingPanel.SetActive(true);
        }
    }
    public void Restart()
    {
        Time.timeScale = 1;
        _life = 3;
        foreach (GameObject life in _lifeList)
        {
            _SOPoints.ResetPoints();
            _pointsText.text = "Score:" + _SOPoints.CurrentPoints.ToString();
            life.SetActive(true);
            _settingPanel.SetActive(false);
        }
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }
    public void IncreaseGameLevel()
    {
        _gameLevel++;
        _gameLevelText.text = "Level:" + _gameLevel.ToString();
    }

}
