using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float attackStrength;

    // Start is called before the first frame update
    void Start()
    {
        health = 20f;
        attackStrength = 1f;
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
