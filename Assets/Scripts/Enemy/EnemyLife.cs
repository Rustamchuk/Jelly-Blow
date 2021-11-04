using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _hall;

    private bool _alive = false;

    public bool Alive => _alive;
    public event Action Dead;

    public void StartLife()
    {
        _alive = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Arm arm) && _health == 1)
        {
            if (arm.Attacking == false)
                return;

            MakeHall(arm);

            _alive = false;
            Dead.Invoke();
        }

        _health--;
    }

    private void MakeHall(Arm arm)
    {
        var hall = Instantiate(_hall);
        hall.transform.position = arm.transform.position;
        hall.transform.parent = gameObject.transform;
    }
}
