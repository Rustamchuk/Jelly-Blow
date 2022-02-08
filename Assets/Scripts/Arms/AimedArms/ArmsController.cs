using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmsController : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private BoxArm[] _boxArms;
    [SerializeField] private float _hitDistance;
    
    private bool _canAttack;
    private bool _stopFight = false;
    private int _activeArmIndex = 0;

    private void OnEnable()
    {
        _playerMover.Moving += OnMoving;
        _playerMover.StopMoving += OnStopMoving;
        _playerMover.Finished += StopAttack;
    }

    private void OnDisable()
    {
        _playerMover.Moving -= OnMoving;
        _playerMover.StopMoving -= OnStopMoving;
        _playerMover.Finished -= StopAttack;
    }

    private void Update()
    {
        if (_stopFight)
            return;

        if (_canAttack == false)
            return;

        if (Input.GetMouseButtonDown(0) && _boxArms[_activeArmIndex].InAction == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 target;

            if(Physics.Raycast(ray, out RaycastHit raycastHit) && Vector3.Distance(_boxArms[_activeArmIndex].transform.position, raycastHit.point) <= _hitDistance)
                target = raycastHit.point;
            else
                target = ray.GetPoint(_hitDistance);

            //Hit(transform.InverseTransformPoint(target), _boxArms[_activeArmIndex]);
            Hit(target, _boxArms[_activeArmIndex]);

            if (_activeArmIndex == 0)
                _activeArmIndex++;
            else
                _activeArmIndex = 0;
        }
    }

    private void Hit(Vector3 target, BoxArm boxArm)
    {
        boxArm.Hit(target);
    }

    private void OnMoving() => _canAttack = false;

    private void OnStopMoving() => _canAttack = true;

    private void StopAttack() => _stopFight = true;
}
