using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour {

    public float startSpeed = 10f;
    [HideInInspector]
    public float speed; 
	public float starHealth = 100;
    private float health;

	public int worth = 50;
    
    public GameObject deathEffect;
    [Header("UnityStuff")]
    public Image healthBar;

    private void Start()
    {
        speed = startSpeed;
        health = starHealth;
    }
    public void TakeDamage(float amount)
    {
        starHealth -= amount;

        healthBar.fillAmount = health / starHealth;
        if (starHealth <= 0)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }

    void Die()
	{
        PlayerStats.Money += worth;
        GameObject Effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(Effect, 5f);
        
		Destroy (gameObject);
	}
}
