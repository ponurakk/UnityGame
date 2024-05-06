using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject playerObject;
    public float attackDamage;
    public float attackSpeed;

    [SerializeField]
    private float timer;

    void Start()
    {
        timer = attackSpeed;
    }

    void Update()
    {
        timer += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerObject.GetComponent<PlayerManager>().TakeDamage(attackDamage);
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (timer >= attackSpeed)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                playerObject.GetComponent<PlayerManager>().TakeDamage(attackDamage);
            }
            timer = 0f;
        }
    }

    void OnTriggerLeave2D(Collider2D collider)
    {
        timer = attackSpeed;
    }
}
