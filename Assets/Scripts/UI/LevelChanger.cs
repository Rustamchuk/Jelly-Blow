using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Scenes _nextLevelName;
    [SerializeField] private Scenes _currentScene;

    private enum Scenes { Pieces_1, Pieces_2, Pieces_3, Pieces_4, Pieces_5, Pieces_6, Pieces_7, Pieces_8, Pieces_9, Pieces_10 }

    public event Action StartedGame;
    public event Action StartedLevel;
    public event Action RestartedLevel;

    public int LastScene => _lastScene;
    public int CircleNumber => _circleNumber;
    public int CurrentScene => (int)_currentScene + 1;

    private bool _gameStarted = false;
    private int _lastScene;

    private const string SAVED_SCENEID = "SceneID";
    private const string SAVED_CIRCLE = "Circle";

    private int _sceneNumber
    {
        get { return PlayerPrefs.GetInt(SAVED_SCENEID, 0); }
        set { PlayerPrefs.SetInt(SAVED_SCENEID, value); }
    }

    private int _circleNumber
    {
        get { return PlayerPrefs.GetInt(SAVED_CIRCLE, 0); }
        set { PlayerPrefs.SetInt(SAVED_CIRCLE, value); }
    }

    private void Awake()
    {
        _lastScene = SceneManager.GetActiveScene().buildIndex;

        if (_lastScene != _sceneNumber)
            SceneManager.LoadScene(_sceneNumber);
        else
            _sceneNumber = _lastScene;
    }

    private void Start()
    {
        StartCoroutine(WaitActivate());

        if (_lastScene == 0)
            _lastScene = 10;
    }

    public void Restart()
    {
        RestartedLevel.Invoke();

        if (_nextLevelName == 0)
            _nextLevelName += 9;
        else
            _nextLevelName--;

        ChooseNextScene();
    }

    public void ChooseNextScene()
    {
        List<int> arguments = new List<int> { (int)_currentScene, _circleNumber};
        _sceneNumber = (int)_nextLevelName;

        switch ((int)_nextLevelName)
        {
            case 0:
                Pieces_1.Load(arguments);
                break;
            case 1:
                Pieces_2.Load(arguments);
                break;
            case 2:
                Pieces_3.Load(arguments);
                break;
            case 3:
                Pieces_4.Load(arguments);
                break;
            case 4:
                Pieces_5.Load(arguments);
                break;
            case 5:
                Pieces_6.Load(arguments);
                break;
            case 6:
                Pieces_7.Load(arguments);
                break;
            case 7:
                Pieces_8.Load(arguments);
                break;
            case 8:
                Pieces_9.Load(arguments);
                break;
            case 9:
                Pieces_10.Load(arguments);
                break;
        }
    }

    public void ChangeStartedGame() { _gameStarted = true; }

    public void SetLast(int i) { _lastScene = i; }

    public void AddCircle(int value) { _circleNumber = value; }

    private IEnumerator WaitActivate()
    {
        yield return new WaitForSeconds(2);

        if (!_gameStarted)
            StartedGame.Invoke();

        StartedLevel.Invoke();
    }
}
