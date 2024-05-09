using System;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public AudioSource seffect;
    public int playerLevel;
    public int playerExp;
    [SerializeField]
    private double maxPlayerExp;

    public GameObject panel;

    void Start()
    {

        panel.SetActive(false);

        playerLevel = 1;
        playerExp = 0;
        maxPlayerExp = 25;

        //Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerExp >= maxPlayerExp)
        {
            playerLevel++;
            playerExp = 0;
            maxPlayerExp = Math.Round(maxPlayerExp * 1.25, 0);
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Exp")
        {
            seffect.Play();
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
