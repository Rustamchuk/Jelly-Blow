using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private string _levelNumber;
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private Transform _endLocation;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private Slider _progressBar;

    private bool _isMoving = false;
    private float _currentValue;
    private float _endValue;

    private void Awake()
    {
        _levelNumberText.text = _levelNumber;
        _endValue = _progressBar.maxValue = Vector3.Distance(_player.transform.position, _endLocation.position);
    }

    private void OnEnable()
    {
        _player.Moving += OnMoving;
        _player.StopMoving += OnStopMoving;
    }

    private void OnDisable()
    {
        _player.Moving -= OnMoving;
        _player.StopMoving -= OnStopMoving;
    }

    private void OnMoving() => _isMoving = true;


    private void OnStopMoving() => _isMoving = false;

    private void Update()
    {
        if (_isMoving == true)
        {
            _currentValue = _endValue - Vector3.Distance(_player.transform.position, _endLocation.position);
            _progressBar.value = _currentValue;
        }
    }
}
