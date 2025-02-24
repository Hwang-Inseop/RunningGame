using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private bool isEquip = false;

    public void Equip()
    {
        if (!isEquip)
        {
            isEquip = true;

        }
    }
}
