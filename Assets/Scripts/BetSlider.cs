using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BetSlider : MonoBehaviour
{
    [SerializeField]
    private int[] _bets = 
    {   
        1,
        2,
        5,
        10,
        25,
        50,
        100,
        200,
        500,
        1000
    };

    [SerializeField]
    private AudioClip[] _sounds;

    [SerializeField]
    private AudioSource _audio;
    [SerializeField]
    private TMP_Text _text;
    [SerializeField]
    private Slider _slider;

    private int _currentBet = 1;
    public int CurrentBet => _currentBet;

    private void Start()
    {
        SetBet(0);
        _slider.maxValue = _bets.Length - 1;
    }

    public void SetBet(float index)
    {
        var newBet = _bets[(int)index];
        if (_currentBet != newBet)
        {
            _currentBet = _bets[(int)index];
            _text.text = _currentBet.ToString();
            _audio.clip = _sounds[(int)index];
            _audio.Play();
            GameSession.SetBet(_currentBet);
        }
    }

    public void SetInteractivityStatus(bool interactable)
    {
        _slider.interactable = interactable;
    }
}
