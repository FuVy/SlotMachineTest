using UnityEngine;

public class Settings : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void HandleOutput()
    {
        gameObject.SetActive(!isActiveAndEnabled);
    }
    
    public void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
