using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.numTomatoSeeds += 1;
            Destroy(this.gameObject);
        }
    }
}

public enum CollectibleType
{
    NONE,
    TOMATO_SEED
}
