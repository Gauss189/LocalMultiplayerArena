using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private int collisionCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++;
        if (collision.gameObject.tag == "Wall" && collisionCount > 1)
        {
            Destroy(gameObject);
        }
    }
}
