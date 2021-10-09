using UnityEngine;
using UnityEngine.Events;

public class PrefsChanger
{
    public static UnityAction OnChange;

    public static void Set(string key, object value)
    {
        var valueType = value.GetType();
        if (valueType == typeof(int))
        {
            PlayerPrefs.SetInt(key, (int)value);
        }
        else if (valueType == typeof(float))
        {
            PlayerPrefs.SetFloat(key, (float)value);
        }
        else if (valueType == typeof(string))
        {
            PlayerPrefs.SetString(key, (string)value);
        }

        OnChange?.Invoke();
    }
}
