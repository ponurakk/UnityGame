using UnityEngine;


using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health;
    public float attackStrength;
    
    public Slider healthSlider;
    public GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        health = 20f;
        attackStrength = 1f;

        healthSlider.value = health;
        healthSlider.maxValue = health;
        
        Time.timeScale = 1;
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        healthSlider.value = health;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "heart")
        {
            health += 2.5f;
            Destroy(collision.gameObject);
        }
    }
}
