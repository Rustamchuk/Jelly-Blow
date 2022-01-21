using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _lookPoint;

    public Transform LookPoint => _lookPoint;
    public event UnityAction Dead;
}
