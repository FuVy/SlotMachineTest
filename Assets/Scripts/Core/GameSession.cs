using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession
{
    public static Collection Collection { get; private set; }

    public static void SetCollection(Collection collection)
    {
        Collection = collection;
    }
}
