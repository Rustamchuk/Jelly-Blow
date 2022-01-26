using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmTrajectoryStretch : MonoBehaviour
{
    [SerializeField] private Arm _armR;
    [SerializeField] private Arm _armL;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private float _stretchSpeed;
    [SerializeField] private float _returnSpeed;
    [SerializeField] private float _delayBeforeMovement;

    private bool _right = true;
    private bool _stretchingIsActive = false;
    private bool _touched = false;
    private int _waitShot = 0;

    public Arm ArmR => _armR;
    public Arm ArmL => _armL;

    private void Awake()
    {
        _armL.Touched += TouchedEnemy;
        _armR.Touched += TouchedEnemy;
    }

    private void Update()
    {
        if (_playerMover.CanMove == true || _cameraMover.Moving)
        {
            _waitShot = 0;
            return;
        }

        if (Input.GetMouseButtonUp(0) && !_stretchingIsActive || _waitShot != 0)
        {
            if (_waitShot++ < 3)
                return;

            if (_right)
            {
                StartCoroutine(StretchArm(_armR));
                _right = false;
            }
            else
            {
                StartCoroutine(StretchArm(_armL));
                _right = true;
            }

            _waitShot = 0;
        }
    }

    private IEnumerator StretchArm(Arm arm)
    {
        _stretchingIsActive = true;
        yield return new WaitForSeconds(_delayBeforeMovement);

        arm.RewriteAttacking(true);

        int i = 0;

        while (!_touched && i != 10)
        {
            i++;
            yield return new WaitForSeconds(0.02f);
        }

        _stretchingIsActive = false;
        _touched = false;
        arm.RewriteAttacking(false);
    }

    public void ReturnPos(Arm arm)
    {
        arm.ArmObject.transform.localScale = arm.StartSize;
        arm.transform.position = arm.StartPos.position;
        arm.transform.rotation = arm.StartPos.rotation;
    }

    private void TouchedEnemy() { _touched = true; }
}