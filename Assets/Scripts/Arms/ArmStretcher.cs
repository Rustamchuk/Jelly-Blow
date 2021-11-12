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
    [SerializeField] private CameraMover _cameraMover;

    private bool _right = true;
    private bool _stretchAccess = false;
    private bool _startForCheck = false;
    private bool _startForStretch = false;
    private bool _touched = false;

    private void Awake()
    {
        _armL.Touched += ArmTouched;
        _armR.Touched += ArmTouched;
    }

    private void Update()
    {
        if (_cameraMover.Moving)
            return;

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
            if (arm.ArmObject.transform.localScale.z <= _maxScale && !_touched)
            {
                //arm.transform.localScale = new Vector3(arm.transform.localScale.x + _speedStrecth / 10 * Time.deltaTime,
                //arm.transform.localScale.y + _speedStrecth / 10 * Time.deltaTime, arm.transform.localScale.z + _speedStrecth * Time.deltaTime);

                arm.ArmObject.transform.localScale = new Vector3(arm.ArmObject.transform.localScale.x, arm.ArmObject.transform.localScale.y,
                    arm.ArmObject.transform.localScale.z + _speedStrecth * Time.deltaTime);

                arm.transform.position += arm.transform.forward * _speedMove * Time.deltaTime;
            }
            else
            {
                ReturnPos(_armL);
                ReturnPos(_armR);

                if (_right)
                    _right = false;
                else
                    _right = true;

                _startForStretch = false;
                _touched = false;
                arm.RewriteAttacking(false);
            }

            yield return null;
        }
    }

    private void ReturnPos(Arm arm)
    {
        arm.ArmObject.transform.localScale = arm.StartSize;
        arm.transform.position = arm.StartPos.position;
        arm.transform.rotation = arm.StartPos.rotation;
    }

    private void ArmTouched() { StartCoroutine(StopStretch()); }

    private IEnumerator StopStretch()
    {
        yield return new WaitForSeconds(0);

        _touched = true;
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
