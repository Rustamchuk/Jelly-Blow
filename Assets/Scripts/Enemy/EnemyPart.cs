using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private EnemyLife _mainBody;
    [SerializeField] private GameObject _fatherObj;
    [SerializeField] private Transform _holePoint;
    [SerializeField] private Transform _rightBorder;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _upBorder;
    [SerializeField] private Transform _downBorder;

    private bool _xChange = false;
    private bool _yChange = false;
    private bool _upNull = false;
    private bool _downNull = false;
    private bool _nullRL = false;

    private void Start()
    {
        if (_upBorder == null)
            _upNull = true;

        if (_downBorder == null)
            _downNull = true;

        if (_rightBorder == null || _leftBorder == null)
            _nullRL = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        _xChange = false;
        _yChange = false;

        if (!_nullRL)
        {
            if (other.transform.position.x > _rightBorder.position.x)
            {
                _holePoint.position = new Vector3(_rightBorder.position.x, _holePoint.position.y, _holePoint.position.z);
                _xChange = true;
            }
            else if (other.transform.position.x < _leftBorder.position.x)
            {
                _holePoint.position = new Vector3(_leftBorder.position.x, _holePoint.position.y, _holePoint.position.z);
                _xChange = true;
            }
        }

        if (!_upNull)
        {
            if (other.transform.position.y > _upBorder.position.y)
            {
                _holePoint.position = new Vector3(_holePoint.position.x, _upBorder.position.y, _holePoint.position.z);
                _yChange = true;
            }
        }

        if (!_downNull)
        {
            if (other.transform.position.y < _downBorder.position.y && !_downNull)
            {
                _holePoint.position = new Vector3(_holePoint.position.x, _downBorder.position.y, _holePoint.position.z);
                _yChange = true;
            }
        }

        _mainBody.CollisionEnter(other, _fatherObj, _holePoint, _xChange, _yChange);
    }
}
