using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private BodyPartName _bodyPartName;

    public event UnityAction<BodyPartName> Brokened;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Bullet bullet))
        {
            if(bullet.CanBrokeBodyPart == true)
            {
                Brokened?.Invoke(_bodyPartName);
                bullet.ChangeBrokedState();
                Destroy(bullet.gameObject);
            }
        }
    }
}

public enum BodyPartName
{
    Head,
    Breast,
    Belly,
    RightArm,
    LeftArm,
    RightLeg,
    LeftLeg
}
