using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _hall;

    private bool _alive = true;

    public bool Alive => _alive;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Arm arm) && _health == 1)
        {
            if (arm.Attacking == false)
                return;

            var hall = Instantiate(_hall);
            hall.transform.position = arm.transform.position;
            hall.transform.parent = gameObject.transform;

            _alive = false;
        }

        _health--;
    }
}
