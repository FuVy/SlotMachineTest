using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CollectionHolder : MonoBehaviour
{
    [SerializeField]
    private Collection _collection;
    [SerializeField]
    private Image _image;

    private void Start()
    {
        _image.sprite = _collection.Icon;
    }

    public void PickCollection()
    {
        GameSession.SetCollection(_collection);
        SceneManager.LoadScene(1);

    }
}
