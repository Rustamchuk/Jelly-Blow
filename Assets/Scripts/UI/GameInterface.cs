using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ResultMaker))]
public class GameInterface : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    
    private ResultMaker _resultMaker;

    private void Awake()
    {
        _resultMaker = GetComponent<ResultMaker>();
        Close();
    }

    private void OnEnable()
    {
        _resultMaker.WonLevel += OnWonLevel;
        _resultMaker.FailLevel += OnFailLevel;
        _resultMaker.Clicked += OnClicked;
    }

    private void OnDisable()
    {
        _resultMaker.WonLevel -= OnWonLevel;
        _resultMaker.FailLevel -= OnFailLevel;
        _resultMaker.Clicked -= OnClicked;
    }

    private void OnWonLevel() => Close();

    private void OnFailLevel() => Close();

    private void OnClicked() => Open();

    private void Open()
    {
        _canvasGroup.alpha = 1;
    }

    private void Close()
    {
        _canvasGroup.alpha = 0;
    }
}
