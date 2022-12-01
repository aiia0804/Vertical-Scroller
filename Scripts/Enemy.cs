using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float HP;
    [SerializeField] float shootCounter;
    [SerializeField] float maxTimeBetweenShoot = 3f;
    [SerializeField] float minTimeBetweenShoot = 0.5f;
    [SerializeField] GameObject BulletPrefb;
    [SerializeField] float FireSpeed = 1f;
    [SerializeField] GameObject bloodVFX;
    [SerializeField] GameObject deadImage;
    [SerializeField] AudioClip DieAudio;
    [SerializeField] float DieaudioVolume = 5f;
    [SerializeField] AudioClip BowAudio;
    [SerializeField] float BowAudioVolume = 5f;
    [SerializeField] int DieingPoint = 80;

    // cached reference
    Level level;

    void Start()
    {
        shootCounter = Random.Range(minTimeBetweenShoot, maxTimeBetweenShoot);
        level = FindObjectOfType<Level>();

    }

    void Update()
    {
        shootCounter -= Time.deltaTime;
        if (shootCounter <= 0)
        {
            Fire();
            shootCounter = Random.Range(minTimeBetweenShoot, maxTimeBetweenShoot);
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(BulletPrefb, gameObject.transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(BowAudio, Camera.main.transform.position, BowAudioVolume);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -FireSpeed);
        Destroy(bullet, 4f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDelear damageDelear = collision.gameObject.GetComponent<DamageDelear>();
        if (!damageDelear) { return; }
        ProcessHit(damageDelear);
    }

    private void ProcessHit(DamageDelear damageDelear)
    {
        HP -= damageDelear.getDamage();
        damageDelear.hit();
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<Gameseesion>().AddScore(DieingPoint);
        Destroy(gameObject);
        GameObject explosion = Instantiate(bloodVFX, gameObject.transform.position, Quaternion.identity);
        GameObject deadAnmimation = Instantiate(deadImage, gameObject.transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        Destroy(deadAnmimation, 1f);
        AudioSource.PlayClipAtPoint(DieAudio, Camera.main.transform.position, DieaudioVolume);
    }

    // For test purose
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageDelear damageDelear = collision.gameObject.GetComponent<DamageDelear>();
        HP -= damageDelear.getDamage()
        //Destroy(collision.gameObject);


    }*/
}
