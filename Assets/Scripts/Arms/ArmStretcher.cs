using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmStretcher : MonoBehaviour
{
    [SerializeField] private Arm _armR;
    [SerializeField] private Arm _armL;
    [SerializeField] private float _speedStrecth;
    [SerializeField] private float _speedMove;
    [SerializeField] private float _maxScale = 10;

    private bool _right = true;
    private bool _stretchAccess = true;

    private void Update()
    {
        if (_stretchAccess)
        {
            if (_right)
                StretchArm(_armR);
            else
                StretchArm(_armL);
        }
    }

    private void StretchArm(Arm arm)
    {
        if (Input.GetMouseButton(0) && arm.transform.localScale.z <= _maxScale)
        {
            arm.transform.localScale = new Vector3(arm.transform.localScale.x + _speedStrecth / 10 * Time.deltaTime,
                arm.transform.localScale.y + _speedStrecth / 10 * Time.deltaTime, arm.transform.localScale.z + _speedStrecth * Time.deltaTime);

            arm.transform.position += arm.transform.forward * _speedMove * Time.deltaTime;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _armL.transform.localScale = _armL.StartSize;
            _armL.transform.position = _armL.StartPos.position;

            _armR.transform.localScale = _armR.StartSize;
            _armR.transform.position = _armR.StartPos.position;

            if (_right)
                _right = false;
            else
                _right = true;
        }
    }

    public void RewriteAccess(bool access)
    {
        _stretchAccess = access;
    }
}
