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
    [SerializeField] private bool _lag;

    private bool _xChange = false;
    private bool _yChange = false;
    private bool _upNull = false;
    private bool _downNull = false;
    private bool _nullR = false;
    private bool _nullL = false;
    private Vector3 _positionToHall = new Vector3(0, 0, 0);

    public bool IsLag => _lag;

    private void Start()
    {
        if (_upBorder == null)
            _upNull = true;

        if (_downBorder == null)
            _downNull = true;

        if (_rightBorder == null)
            _nullR = true;

        if (_leftBorder == null)
            _nullL = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        _xChange = false;
        _yChange = false;

        if (other.transform.position.x > _rightBorder.position.x && !_nullR)
        {
            _positionToHall = new Vector3(_rightBorder.position.x, _positionToHall.y, _positionToHall.z);
            _xChange = true;
        }

        if (other.transform.position.x < _leftBorder.position.x && !_nullL)
        {
            _positionToHall = new Vector3(_leftBorder.position.x, _positionToHall.y, _positionToHall.z);
            _xChange = true;
        }

        if (!_upNull)
        {
            if (other.transform.position.y > _upBorder.position.y)
            {
                _positionToHall = new Vector3(_positionToHall.x, _upBorder.position.y, _positionToHall.z);
                _yChange = true;
            }
        }

        if (!_downNull)
        {
            if (other.transform.position.y < _downBorder.position.y )
            {
                _positionToHall = new Vector3(_positionToHall.x, _downBorder.position.y, _positionToHall.z);
                _yChange = true;
            }
        }

        _positionToHall = new Vector3(_positionToHall.x, _positionToHall.y, _holePoint.position.z);

        _mainBody.CollisionEnter(other, _fatherObj, _positionToHall, _xChange, _yChange);

        if (_lag)
            _mainBody.ChangeIsLag();
    }
}
