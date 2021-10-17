using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceOutput : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    private void Start()
    {
        Output();
        GameSession.OnCashChange += Output;
    }

    private void Output()
    {
        _text.text = GameSession.Cash.ToString();
    }

    private void OnDestroy()
    {
        GameSession.OnCashChange -= Output;
    }
}
