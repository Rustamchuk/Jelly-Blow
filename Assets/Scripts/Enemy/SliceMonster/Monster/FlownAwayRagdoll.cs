using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlownAwayRagdoll : DeadBodyRagdoll
{
    private void Start()
    {
        OnKilled(false);
    }
}
