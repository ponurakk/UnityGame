using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{

    public int playerLevel;
    public int playerExp;
    [SerializeField]
    private double maxPlayerExp;

    public GameObject panel;

    public float playerSpeed;
    public float playerDamage;
    public float playerHealth;

    PlayerManager playerH;
    PlayerMovement playerS;

    void Start()
    {
        playerH = GetComponent<PlayerManager>();
        playerS = GetComponent<PlayerMovement>();

        panel.SetActive(false);
        
        playerLevel = 1;
        playerExp = 0;
        maxPlayerExp = 25;

        playerHealth = playerH.health;
        playerSpeed = playerS.moveSpeed;

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
            playerExp += 5;
            Destroy(collision.gameObject);
        }
    }

    public void DamageBoost()
    {
        playerDamage = playerDamage * 1.25f;
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void SpeedBoost()
    {
        playerSpeed = playerSpeed * 1.05f;
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void HealthBoost()
    {
        playerHealth = playerHealth * 1.05f;
        Time.timeScale = 1;
        panel.SetActive(false);
    }
}
