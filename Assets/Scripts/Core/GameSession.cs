using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSession : MonoBehaviour
{
    private int _record;
    public int Record => _record;

    private int _current = 0;
    public int Current => _current;

    private int _currentStreak = 0;
    public int CurrentStreak => _currentStreak;

    public UnityAction OnPointsChange;
    public UnityAction OnRecordChange;
    public UnityAction OnStreakChange;

    private void Awake()
    {
        _record = PlayerPrefs.GetInt("Record");
        _current = 0;
    }

    public void AddPoints(int value)
    {
        _current += value;
        if (_current > _record)
        {
            _record = _current;
            OnRecordChange?.Invoke();
            PlayerPrefs.SetInt("Record", _record);
        }
        OnStreakChange?.Invoke();
        OnPointsChange?.Invoke();
    }

    public void SetPoints(int value)
    {
        _current = value;
        _currentStreak = 0;
        OnPointsChange?.Invoke();
        OnStreakChange?.Invoke();
    }

    public void ResetPoints()
    {
        PlayerPrefs.DeleteAll();
        OnPointsChange?.Invoke();
    }

    public void IncreaseStreak()
    {
        _currentStreak++;
        OnStreakChange?.Invoke();
    }

    private void OnDestroy()
    {
        PlayerPrefs.Save();
    }
}
