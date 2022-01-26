using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodyPart : MonoBehaviour
{
    [SerializeField] private BodyPartName _bodyPartName;

    public event UnityAction<BodyPartName> Brokened;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            if (bullet.CanBrokeBodyPart == true)
            {
                Brokened?.Invoke(_bodyPartName);
                bullet.ChangeBrokedState();
            }
        }

        if (other.TryGetComponent(out Arm arm))
        {
            arm.TouchedTrigger();
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
