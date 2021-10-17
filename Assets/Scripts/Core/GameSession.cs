using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSession
{
    public static Collection Collection { get; private set; }

    public static int Cash { get; private set; }

    public static int Bet { get; private set; }

    public static UnityAction OnCashChange;

    public static void Init()
    {
        Bet = 1;
        if (!PlayerPrefs.HasKey("Cash"))
        {
            PlayerPrefs.SetInt("Cash", 1000); //default value
        }
        Cash = PlayerPrefs.GetInt("Cash");
    }

    public static void SetCash(int value)
    {
        Cash = value;
        OnCashChange?.Invoke();
        PlayerPrefs.SetInt("Cash", Cash);
    }

    public static void SetBet(int value)
    {
        Bet = value;
    }

    public static void AddCash(int value)
    {
        Cash += value;
        OnCashChange?.Invoke();
        PlayerPrefs.SetInt("Cash", Cash);
    }

    public static void SetCollection(Collection collection)
    {
        Collection = collection;
    }
}
