using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _rotationAccelerationCoefficient;

    private float _lastRotationSpeed = 0;
    private IEnumerator _coroutine;
    private bool _gameStarted = true;

    public bool RotateCoroutineIsActive { get; private set; } = false;

    public void StartRotate(Transform lookPoint)
    {
        _lastRotationSpeed = 0;

        if (RotateCoroutineIsActive == true)
            StopRotate();

        _coroutine = Rotate(lookPoint);
        StartCoroutine(_coroutine);
    }

    public IEnumerator Rotate(Transform lookPoint)
    {
        RotateCoroutineIsActive = true;

        while (_gameStarted == true)
        {
            if (_lastRotationSpeed < _rotationSpeed)
                _lastRotationSpeed += Time.deltaTime * _rotationAccelerationCoefficient;

            Vector3 direction = lookPoint.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _lastRotationSpeed);

            yield return null;
        }

        RotateCoroutineIsActive = false;
    }

    public void StopRotate()
    {
        StopCoroutine(_coroutine);
        RotateCoroutineIsActive = false;
    }
}
