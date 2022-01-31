using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelEntry : MonoBehaviour, ISceneLoadHandler<int>
{
    [SerializeField] private LevelChanger _levelChanger;

    public void OnSceneLoaded(int argument)
    {
        _levelChanger.SetLast(argument);
        _levelChanger.ChangeStartedGame();

        Time.timeScale = 1;
    }
}
