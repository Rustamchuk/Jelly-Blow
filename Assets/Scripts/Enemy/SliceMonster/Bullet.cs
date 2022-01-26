using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool CanBrokeBodyPart { get; private set; } = true;

    public void ChangeBrokedState()
    {
        CanBrokeBodyPart = false;

        StartCoroutine(ActivateBrokable());
    }

    private IEnumerator ActivateBrokable()
    {
        yield return new WaitForSeconds(1f);
        CanBrokeBodyPart = true;
    }
}
