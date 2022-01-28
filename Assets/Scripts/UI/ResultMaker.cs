using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultMaker : MonoBehaviour
{
    [SerializeField] private SetChanger _setChanger;
    [SerializeField] private GameObject _victory;
    [SerializeField] private GameObject _fail;
    [SerializeField] private GameObject _click;
    //[SerializeField] private float _waitSeconds = 2;

    public event Action WonLevel;
    public event Action FailLevel;
    public event Action Clicked;

    public int SpentTime => _spentTime;

    private int _spentTime;
    private bool _won = false;
    private bool _lost = false;

    private void Awake()
    {
        _setChanger.FailLevel += Lose;
        _setChanger.WinLevel += Win;

        AskClick();
    }

    private void Win()
    {
        if (_won)
            return;

        _spentTime = (int)Time.timeSinceLevelLoad;

        WonLevel.Invoke();
        _won = true;

        _victory.SetActive(true);
        //StartCoroutine(SetActiveResult(_victory, _waitSeconds));
    }

    private void Lose()
    {
        if (_lost)
            return;

        _spentTime = (int)Time.timeSinceLevelLoad;

        FailLevel.Invoke();
        _lost = true;

        _fail.SetActive(true);
        //StartCoroutine(SetActiveResult(_fail, 0));
    }

    private IEnumerator SetActiveResult(GameObject result, float seconds)
    {
        yield return new WaitForSeconds(seconds);

        result.SetActive(true);
    }

    private void AskClick()
    {
        _click.SetActive(true);

        StartCoroutine(RemoveClick());
    }

    private IEnumerator RemoveClick()
    {
        while (!Input.GetMouseButtonDown(0)) { yield return null; }

        _click.SetActive(false);
        Clicked?.Invoke();

        _setChanger.ChangeSet();
    }
}
