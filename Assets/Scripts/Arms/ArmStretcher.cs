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
    private bool _stretchAccess = false;
    private bool _startForCheck = false;
    private bool _startForStretch = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _stretchAccess = true;
        }
        else if (Input.GetMouseButton(0))
        {
            if (!_startForCheck)
                StartCoroutine(WaitToCheckTap());
        }
        else if (Input.GetMouseButtonUp(0) && _stretchAccess)
        {
            if (_startForStretch)
                return;

            if (_right)
                StartCoroutine(StretchArm(_armR));
            else
                StartCoroutine(StretchArm(_armL));
        }
    }

    private IEnumerator StretchArm(Arm arm)
    {
        _startForStretch = true;
        arm.RewriteAttacking(true);

        while (_startForStretch)
        {
            if (arm.transform.localScale.z <= _maxScale)
            {
                arm.transform.localScale = new Vector3(arm.transform.localScale.x + _speedStrecth / 10 * Time.deltaTime,
                    arm.transform.localScale.y + _speedStrecth / 10 * Time.deltaTime, arm.transform.localScale.z + _speedStrecth * Time.deltaTime);

                arm.transform.position += arm.transform.forward * _speedMove * Time.deltaTime;
            }
            else
            {
                _armL.transform.localScale = _armL.StartSize;
                _armL.transform.position = _armL.StartPos.position;

                _armR.transform.localScale = _armR.StartSize;
                _armR.transform.position = _armR.StartPos.position;

                if (_right)
                    _right = false;
                else
                    _right = true;

                _startForStretch = false;
                arm.RewriteAttacking(false);
            }

            yield return null;
        }
    }

    private IEnumerator WaitToCheckTap()
    {
        _startForCheck = true;

        yield return new WaitForSeconds(0.2f);

        if (Input.GetMouseButton(0))
        {
            _stretchAccess = false;
        }

        _startForCheck = false;
    }

    public void RewriteAccess(bool access)
    {
        _stretchAccess = access;
    }
}
