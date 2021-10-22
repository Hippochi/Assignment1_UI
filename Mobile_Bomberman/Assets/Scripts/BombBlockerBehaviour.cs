//BombBlockerBehaviour by Alex Dine
//101264627 on Sept 26th
//Helps BombBehaviour with explosion placement
//v1.0

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBlockerBehaviour : MonoBehaviour
{
    public bool isBlocked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlockedTile")
        {
            isBlocked = true;
        }
    }

    public bool getBlocked()
    {
        return isBlocked;
    }
}
