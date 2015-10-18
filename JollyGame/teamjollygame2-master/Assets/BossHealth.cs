﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : MonoBehaviour {

    public int startingHealth = 1000;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject showOnDeath;
    public GameObject[] hideOnDeath;

    public GameObject healthSliderObj;
    public GameObject winObj;

    bool inDeath = false;
    float deathTime = -1;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update () {
        deathTime -= Time.deltaTime;
        if (inDeath && deathTime < 0)
            die();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "HeroShot")
        {
            takeDamage(10);
            Destroy(other.gameObject);
        }

        //play impact sound effect

        //impact particle effect

        
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0 && !inDeath)
        {
            showOnDeath.SetActive(true);
            winObj.SetActive(true);
            healthSliderObj.SetActive(false);
            inDeath = true;
            deathTime = 2.0f;
        }
    }

    void die()
    {
        for(int i = 0; i < hideOnDeath.Length; i++)
        {
            hideOnDeath[i].SetActive(false);
        }
        
    }
}
