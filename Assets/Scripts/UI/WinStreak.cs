using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinStreak : MonoBehaviour
{
    [SerializeField]
    private Gradient _gradient;

    [SerializeField]
    private Image _image;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private GameSession _session;

    private void Awake()
    {
        _session.OnStreakChange += Output;
    }

    private void Output()
    {
        _slider.value = _session.CurrentStreak / 4f;
    }

    public void SetGradient(float value)
    {
        _image.color = _gradient.Evaluate(value);
    }
}
