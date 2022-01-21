using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierRenderer : MonoBehaviour
{
    [SerializeField] private Bezier _bezier;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform _guidePoint1;
    [SerializeField] private Transform _guidePoint2;
    [SerializeField] private Transform _endPoint;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        int sigmentsNumber = 20;
        Vector3 preveousePoint = _startPoint.position;

        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float paremeter = (float)i / sigmentsNumber;
            Vector3 point = _bezier.GetPoint(_startPoint.position, _guidePoint1.position, _guidePoint2.position, _endPoint.position, paremeter);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }
}
