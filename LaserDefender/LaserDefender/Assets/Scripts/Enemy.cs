using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 100;
    [SerializeField] private float shotCounter;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetShotCounter();
    }

    void ResetShotCounter()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            Fire();
            ResetShotCounter();
        }
    }
    void Fire()
    {
        GameObject laser_shoot = Instantiate(
            projectile, 
            gameObject.transform.position, 
            Quaternion.identity) as GameObject;
        laser_shoot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (damageDealer == null) return;
        
        ProcessHit(damageDealer);
        Destroy(other.gameObject);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.Damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
