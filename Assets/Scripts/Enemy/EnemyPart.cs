using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPart : MonoBehaviour
{
    [SerializeField] private EnemyLife _mainBody;
    [SerializeField] private GameObject _fatherObj;

    private void OnTriggerEnter(Collider other)
    {
        _mainBody.CollisionEnter(other, _fatherObj);
    }
}
