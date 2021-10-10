using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private GameSession _session;
    [SerializeField]
    private GameObject _menu;

    private void Start()
    {
        _menu.SetActive(false);
    }

    public void HandleOutput()
    {
        _menu.SetActive(!_menu.activeInHierarchy);
    }
    
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        _session.ResetSession();
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
