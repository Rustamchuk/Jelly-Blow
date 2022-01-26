using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SlicedEnemy))]
public class RemainingRagdoll : DeadBodyRagdoll
{
    private SlicedEnemy _slicedEnemy;

    private void Awake()
    {
        _slicedEnemy = GetComponent<SlicedEnemy>();
    }

    private void OnEnable()
    {
        _slicedEnemy.Killed += OnKilled;
    }

    private void OnDisable()
    {
        _slicedEnemy.Killed -= OnKilled;
    }
}
