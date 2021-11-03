using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimCamera : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _maxAngleX;
    [SerializeField] private float _maxAngleY;
    [SerializeField] private ArmStretcher _armStretcher;

    private bool _firstTouch = true;
    private float _rotationX;
    private float _rotationY;
    private bool _letRotateX = false;
    private bool _letRotateY = false;
    private bool _axisX = true;
    private bool _clicking = false;
    private List<float> _maxAnglesX = new List<float>();
    private List<float> _maxAnglesY = new List<float>();

    private void Awake()
    {
        _maxAnglesX.Add(-_maxAngleX);
        _maxAnglesX.Add(_maxAngleX);
        _maxAnglesY.Add(-_maxAngleY);
        _maxAnglesY.Add(_maxAngleY);
    }

    private void RewriteRot()
    {
        _rotationX = transform.rotation.eulerAngles.y;
        _rotationY = -transform.rotation.eulerAngles.x;

        if (_rotationX > 180)
            _rotationX -= 360;
        if (-_rotationY > 180)
            _rotationY -= 360;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            _clicking = true;
        else if (Input.GetMouseButtonUp(0))
            _clicking = false;

        Aim();
    }

    private void Aim()
    {
        if (_clicking)
        {
            if (_firstTouch)
            {
                _firstTouch = false;
                return;
            }

            RotateX();
            RotateY();


            if (_letRotateX && _letRotateY)
            {
                if (_axisX)
                    transform.rotation = Quaternion.Euler(-_rotationY, _rotationX, 0);
                else
                    transform.rotation = Quaternion.Euler(0, _rotationX, _rotationY);
            }
        }
        else
        {
            _firstTouch = true;
        }
    }

    private void RotateX()
    {
        float curRot = transform.rotation.eulerAngles.y;
        _rotationX += Input.GetAxis("Mouse X") * _rotateSpeed;

        if ((curRot < _maxAnglesX[1] || _rotationX < curRot) &&
            (curRot > _maxAnglesX[0] || _rotationX > curRot))
            _letRotateX = true;

        if (_rotationX < _maxAnglesX[0])
            _rotationX = _maxAnglesX[0] - 1;
        else if (_rotationX > _maxAnglesX[1])
            _rotationX = _maxAnglesX[1] + 1;
    }

    private void RotateY()
    {
        float curRot = transform.rotation.eulerAngles.x;
        _rotationY += Input.GetAxis("Mouse Y") * _rotateSpeed;

        if ((curRot < _maxAnglesY[1] || _rotationY < curRot) &&
            (curRot > _maxAnglesY[0] || _rotationY > curRot))
            _letRotateY = true;

        if (_rotationY < _maxAnglesY[0])
            _rotationY = _maxAnglesY[0] - 1;
        else if (_rotationY > _maxAnglesY[1])
            _rotationY = _maxAnglesY[1] + 1;
    }
}
