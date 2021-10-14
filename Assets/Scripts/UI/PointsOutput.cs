using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsOutput : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _current, _record;

    [SerializeField]
    private OldGameSession _session;

    private void Awake()
    {
        _current.text = _session.Current.ToString();
        _record.text = _session.Record.ToString();

        _session.OnPointsChange += OutputCurrentPoints;
        _session.OnRecordChange += OutputRecord;
    }

    private void OutputCurrentPoints()
    {
        _current.text = _session.Current.ToString();
    }

    private void OutputRecord()
    {
        _record.text = _session.Record.ToString();
    }

    private void OnDestroy()
    {
        _session.OnPointsChange -= OutputCurrentPoints;
        _session.OnRecordChange -= OutputRecord;
    }
}
