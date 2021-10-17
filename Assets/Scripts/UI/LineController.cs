using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _renderer;
    private Transform[] _points;

    public void SetLinePoints(Transform[] points)
    {
        _renderer.positionCount = points.Length;
        _points = points;
        for (int i = 0; i < _points.Length; i++)
        {
            Vector3 position = _points[i].position;
            position.z = 0;
            _renderer.SetPosition(i, position);
        }
    }

    public void SetLineColor(Gradient gradient)
    {
        _renderer.colorGradient = gradient;
    }

    private void OnEnable()
    {
        _renderer.enabled = true;
    }

    private void OnDisable()
    {
        _renderer.enabled = false;
    }
}
