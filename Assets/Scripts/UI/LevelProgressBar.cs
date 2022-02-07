using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelNumberText;
    [SerializeField] private Transform _endLocation;
    [SerializeField] private PlayerMover _player;
    [SerializeField] private LevelChanger _levelChanger;
    [SerializeField] private Slider _progressBar;

    private bool _isMoving = false;
    private float _currentValue;
    private float _endValue;
    private int _levelNumber;

    private void Start()
    {
        StartCoroutine(ActivateNumber());
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

    private IEnumerator ActivateNumber()
    {
        yield return new WaitForSeconds(0.2f);
        _levelNumber = SceneManager.GetActiveScene().buildIndex + 1 + _levelChanger.CircleNumber;
        _levelNumberText.text = _levelNumber.ToString();
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
