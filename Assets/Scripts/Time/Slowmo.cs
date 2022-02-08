using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowmo : MonoBehaviour
{
    [SerializeField] private MonsterStateChanger[] _monsterStateChanger;
    [SerializeField] private float _slowmoTime;
    [SerializeField, Range(0, 1)] private float _slowmoCoefficient;
    [SerializeField] private float _timeRecoveryRate;

    private float _lastSlowmoTime;
    private IEnumerator _coroutine;
    private bool _coroutineIsActive = false;

    private void Awake()
    {
        ResetSlowmoTime();
    }

    private void OnEnable()
    {
        foreach (var monster in _monsterStateChanger)
        {
            monster.Dead += OnDead;
        }
    }

    private void OnDisable()
    {
        foreach (var monster in _monsterStateChanger)
        {
            monster.Dead -= OnDead;
        }
    }

    private void OnDead(bool exploded)
    {
        _coroutine = StartNewCoroutine(SlowMotionTime());
        StartCoroutine(_coroutine);
    }

    private IEnumerator SlowMotionTime()
    {
        _coroutineIsActive = true;
        Time.timeScale = _slowmoCoefficient;

        while (_lastSlowmoTime > 0)
        {
            _lastSlowmoTime -= Time.deltaTime;

            yield return null;
        }

        _coroutineIsActive = false;
        _coroutine = StartNewCoroutine(RestoreFlowTime());
        StartCoroutine(_coroutine);
        ResetSlowmoTime();
    }

    private IEnumerator RestoreFlowTime()
    {
        _coroutineIsActive = true;

        while (Time.timeScale < 1)
        {
            Time.timeScale += Time.deltaTime * _timeRecoveryRate;

            yield return null;
        }

        Time.timeScale = 1;
        ResetSlowmoTime();
        _coroutineIsActive = false;
    }

    private void ResetSlowmoTime()
    {
        _lastSlowmoTime = _slowmoTime;
    }

    private IEnumerator StartNewCoroutine(IEnumerator coroutine)
    {
        if (_coroutineIsActive == true)
        {
            StopCoroutine(_coroutine);
            _coroutineIsActive = false;
        }

        return coroutine;
    }
}
