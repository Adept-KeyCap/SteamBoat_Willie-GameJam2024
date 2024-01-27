using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [SerializeField] private int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject player = other.gameObject;
        PlayerManager pm = player.GetComponent<PlayerManager>();
        //Robin playerController = player.GetComponent<Robin>();

        if (pm != null)
        {
            //pm.changeHealth(-0.5f);
            pm.TakeDamage(damage);
        }

    }
}
