using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraRotate : MonoBehaviour
{
    [SerializeField] private float _speed;

    private IEnumerator _coroutine;
    private bool _gameStarted = true;

    public bool RotateCoroutineIsActive { get; private set; } = false;

    public void StartRotate(Transform lookPoint)
    {
        _coroutine = Rotate(lookPoint);
        StartCoroutine(_coroutine);
    }

    public IEnumerator Rotate(Transform lookPoint)
    {
        RotateCoroutineIsActive = true;

        while (_gameStarted == true)
        {
            Vector3 direction = lookPoint.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * _speed);

            yield return null;
        }
    }

    public void StopRotate()
    {
        StopCoroutine(_coroutine);
        RotateCoroutineIsActive = false;
    }
}
