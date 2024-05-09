using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float attackStrength;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = 20f;
        attackStrength = 1f;
        Time.timeScale = 1;
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
            deathScreen.SetActive(true);
        }
    }

    public void TakeDamage(float damage)
    {
        if (health >= damage) { health -= damage; }
        else { health = 0; }
    }
}
