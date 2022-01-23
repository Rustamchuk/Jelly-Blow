using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ArmStretcher _arms;

    private bool _moving = false;

    public bool Moving => _moving;
    public event Action StopMove;

    public void ChangeMovingState(bool state) 
    {
        _moving = state;

        if (_moving == false)
            StopMove.Invoke();
    }

    public IEnumerator Move(CameraPointSpeeder[] point)
    {
        int index = 0;
        _moving = true;
        while (_moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, point[index].transform.position, Time.deltaTime * point[index].Speed);

            _arms.ReturnPos(_arms.ArmL);
            _arms.ReturnPos(_arms.ArmR);

            yield return null;

            if (transform.position == point[index].transform.position)
            {
                if (index == point.Length - 1)
                    _moving = false;
                else
                    index++;
            }
        }

        StopMove.Invoke();
    }

    public void RewriteMoving(bool state) { _moving = state; }
}
