using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private EnemyLife _mainBody;
    [SerializeField] private GameObject _fatherObj;
    [SerializeField] private Transform _holePoint;

    private void OnTriggerEnter(Collider other)
    {
        _mainBody.CollisionEnter(other, _fatherObj, _holePoint);
    }
}
