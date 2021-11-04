using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private Transform _startPos;

    private Vector3 _startSize;
    private bool _attacking = false;

    public Vector3 StartSize => _startSize;
    public Transform StartPos => _startPos;
    public bool Attacking => _attacking;

    private void Start()
    {
        _startSize = transform.localScale;
    }

    public void RewriteAttacking(bool state) { _attacking = state; }
}
