using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomMaker : MonoBehaviour
{
    [SerializeField] private float _duration = 0.2f;
    [SerializeField] private float _inaccuracyY;

    public void Boom(Vector3 pos)
    {
        transform.position = pos + Vector3.up * _inaccuracyY;
        StartCoroutine(BoomWait());
    }

    private IEnumerator BoomWait()
    {
        Time.timeScale = 0.05f;
        yield return new WaitForSeconds(_duration);

        Destroy(gameObject);
        Time.timeScale = 1;
    }
}
