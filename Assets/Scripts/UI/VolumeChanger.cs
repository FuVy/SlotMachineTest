using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField]
    private string _mixerParameter;

    [SerializeField]
    private AudioMixer _mixer;

    [SerializeField]
    private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(HandleToggle);
    }

    private void Start()
    {
        ChangeVolume(PlayerPrefs.GetFloat(_mixerParameter));
    }

    private void HandleToggle()
    {
        _mixer.GetFloat(_mixerParameter, out float value);
        if (value != 0)
        {
            ChangeVolume(0f);
        }
        else
        {
            ChangeVolume(-80f);
        }
    }

    private void ChangeVolume(float value)
    {
        _mixer.SetFloat(_mixerParameter, value);
        print(value);
        PlayerPrefs.SetFloat(_mixerParameter, value);
    }
}
