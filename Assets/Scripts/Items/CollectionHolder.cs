using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollectionHolder : MonoBehaviour
{
    [SerializeField]
    private Collection _collection;

    public void PickCollection()
    {
        GameSession.SetCollection(_collection);
        SceneManager.LoadScene(1);

    }
}
