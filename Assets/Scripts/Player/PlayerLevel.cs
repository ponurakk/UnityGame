using System;
using UnityEngine;


using UnityEngine.UI;
public class PlayerLevel : MonoBehaviour
{

    public int playerLevel;
    public int playerExp;
    [SerializeField]
    private float maxPlayerExp;

    public GameObject panel;

    public Slider expSlider;

    void Start()
    {

        panel.SetActive(false);

        playerLevel = 1;
        playerExp = 0;
        maxPlayerExp = 25f;

        expSlider.value = playerExp;
        expSlider.maxValue = maxPlayerExp;

        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        expSlider.value = playerExp;
        if (playerExp >= maxPlayerExp)
        {
            playerLevel++;
            playerExp = 0;
            maxPlayerExp = (float)Math.Round(maxPlayerExp * 1.25f, 0);
            Time.timeScale = 0;
            panel.SetActive(true);
            expSlider.maxValue = maxPlayerExp;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exp")
        {
            playerExp += 5;
            Destroy(collision.gameObject);
        }
    }

    public void DamageBoost()
    {
        GetComponent<PlayerManager>().attackStrength = GetComponent<PlayerManager>().attackStrength * 1.25f;
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void SpeedBoost()
    {
        GetComponent<PlayerMovement>().moveSpeed = GetComponent<PlayerMovement>().moveSpeed * 1.05f;
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void HealthBoost()
    {
        GetComponent<PlayerManager>().health = GetComponent<PlayerManager>().health * 1.05f;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
