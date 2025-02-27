using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    // Start is called before the first frame update
    private MagnetPlayer player;
    void Start()
    {
        player = GetComponentInParent<MagnetPlayer>();
    }
    private void Update()
    {
        transform.position = player.transform.position;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("LoopableItem"))
        {
            player.AttractItem(collision.transform);
        }
    }
}
