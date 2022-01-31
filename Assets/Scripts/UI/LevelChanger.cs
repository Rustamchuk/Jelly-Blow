using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Scenes _nextLevelName;
    [SerializeField] private Scenes _currentScene;

    private enum Scenes { Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10 }

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
        /*
        switch ((int)_nextLevelName)
        {
            case 0:
                Level_1.Load((int)_currentScene);
                break;
            case 1:
                Level_2.Load((int)_currentScene);
                break;
            case 2:
                Level_3.Load((int)_currentScene);
                break;
            case 3:
                Level_4.Load((int)_currentScene);
                break;
            case 4:
                Level_5.Load((int)_currentScene);
                break;
            case 5:
                Level_6.Load((int)_currentScene);
                break;
            case 6:
                Level_7.Load((int)_currentScene);
                break;
            case 7:
                Level_8.Load((int)_currentScene);
                break;
            case 8:
                Level_9.Load((int)_currentScene);
                break;
            case 9:
                Level_10.Load((int)_currentScene);
                break;
        }*/
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
