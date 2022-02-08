using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;

public class LevelEntry : MonoBehaviour, ISceneLoadHandler<List<int>>
{
    [SerializeField] private LevelChanger _levelChanger;

    public void OnSceneLoaded(List<int> argument)
    {
        //_levelChanger.SetLast(argument[0]);
        _levelChanger.ChangeStartedGame();

        if (argument[0] == 9 && SceneManager.GetActiveScene().buildIndex == 0)
            argument[1] += 10;

        _levelChanger.AddCircle(argument[1]);
        Time.timeScale = 1;
    }
}
