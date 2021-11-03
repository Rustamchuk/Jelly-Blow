using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallMaker : MonoBehaviour
{
    [SerializeField] private GameObject _hall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Arm arm))
        {
            var hall = Instantiate(_hall);
            hall.transform.position = arm.transform.position;
        }
    }
}
