using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private Scenes _nextLevelName;
    [SerializeField] private Scenes _currentScene;

    private enum Scenes { JellyTest, BoxGloves }

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
            _nextLevelName += 1;
        else
            _nextLevelName--;

        ChooseNextScene();
    }

    public void ChooseNextScene()
    {
        switch ((int)_nextLevelName)
        {
            case 0:
                Pieces_1_JellyTest.Load((int)_currentScene);
                break;
            case 1:
                Pieces_1_BoxGloves.Load((int)_currentScene);
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
