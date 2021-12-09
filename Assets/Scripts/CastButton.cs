using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastButton : MonoBehaviour
{
    public void CastWord()
    {
        if (GameManager.gm.CanCastWord())
        {
            GameManager.gm.CastWord();
        }
    }
}
