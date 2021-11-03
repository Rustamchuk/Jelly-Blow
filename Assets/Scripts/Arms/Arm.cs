using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [SerializeField] private Transform _startPos;

    private Vector3 _startSize;

    public Vector3 StartSize => _startSize;
    public Transform StartPos => _startPos;

    private void Start()
    {
        _startSize = transform.localScale;
    }
}
