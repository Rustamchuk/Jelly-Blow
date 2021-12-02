using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void Update()
    {
        if (transform.rotation.eulerAngles != new Vector3(-90, 0, 0))
        {
            gameObject.transform.eulerAngles = new Vector3(-90, 0, 0);
        }
    }
}
