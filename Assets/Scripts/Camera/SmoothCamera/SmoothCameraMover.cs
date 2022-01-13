using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmoothCameraMover : MonoBehaviour
{
    [SerializeField] private ArmStretcher _arms;

    private bool _moving = false;

    public bool Moving => _moving;
    public event UnityAction StopMoving;

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

        StopMoving?.Invoke();
    }

    public void ChangeMovingState(bool state)
    {
        _moving = state;
    }
}
