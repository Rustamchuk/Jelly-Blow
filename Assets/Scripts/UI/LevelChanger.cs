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
    public int CurrentScene => (int)_currentScene;

    private bool _gameStarted = false;
    private int _lastScene;

    private void Start()
    {
        StartCoroutine(WaitActivate());

        _lastScene = SceneManager.GetActiveScene().buildIndex;

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
        switch ((int)_nextLevelName)
        {
            case 0:
                Pieces_1.Load((int)_currentScene);
                break;
            case 1:
                Pieces_2.Load((int)_currentScene);
                break;
            case 2:
                Pieces_3.Load((int)_currentScene);
                break;
            case 3:
                Pieces_4.Load((int)_currentScene);
                break;
            case 4:
                Pieces_5.Load((int)_currentScene);
                break;
            case 5:
                Pieces_6.Load((int)_currentScene);
                break;
            case 6:
                Pieces_7.Load((int)_currentScene);
                break;
            case 7:
                Pieces_8.Load((int)_currentScene);
                break;
            case 8:
                Pieces_9.Load((int)_currentScene);
                break;
            case 9:
                Pieces_10.Load((int)_currentScene);
                break;
        }
    }

    public void ChangeStartedGame() { _gameStarted = true; }

    public void SetLast(int i) { _lastScene = i; }

    private IEnumerator WaitActivate()
    {
        yield return new WaitForSeconds(2);

        if (!_gameStarted)
            StartedGame.Invoke();

        StartedLevel.Invoke();
    }
}
