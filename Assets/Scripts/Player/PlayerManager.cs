using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("ded");
            return;
        }
    }

    public void TakeDamage(float damage)
    {
        if (health >= damage) { health -= damage; }
        else { health = 0; }
    }
}
