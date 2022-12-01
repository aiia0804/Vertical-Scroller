using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Coroutine firingCorouting;

    // configuration paramters
    [Header("Plaer Movement")]
    [SerializeField] float GameSpped = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int HP = 300;

    [Header("Projectile")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float fireSpeed = 10f;
    [SerializeField] float fireFrquency = 1;
    [SerializeField] AudioClip FireBallAudio;
    [SerializeField] float FireBallAudioVolume = 5f;

    [Header("Others")]
    [SerializeField] TextMeshProUGUI HPText;
    [SerializeField] AudioClip DeathVFX;
    [SerializeField] float deathVFXVolume = .5f;
    [SerializeField] GameObject bloodVFX;


    void Start()
    {
        SetUpMoveBoundries();
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
        GameObject explosion = Instantiate(bloodVFX, gameObject.transform.position, Quaternion.identity);
        damageDelear.hit();
        if (HP <= 0)
        {
            AudioSource.PlayClipAtPoint(DeathVFX, Camera.main.transform.position, deathVFXVolume);
            Destroy(gameObject);
            FindObjectOfType<Level>().LoadLoseScene();
        }
    }
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            firingCorouting = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCorouting);
        }

    }

    IEnumerator FireContinuously()
    {
        GameObject fireBall = Instantiate
                        (laserPrefab,
                        gameObject.transform.position,
                        Quaternion.Euler(0, 0, 90.748f)) as GameObject;

        fireBall.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireSpeed);
        Destroy(fireBall, 1.5f);

        AudioSource.PlayClipAtPoint(FireBallAudio, Camera.main.transform.position, FireBallAudioVolume);

        yield return new WaitForSeconds(fireFrquency);
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * GameSpped;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * GameSpped;
        var newXPos = Mathf.Clamp((transform.position.x + deltaX), xMin, xMax);
        var newYPos = Mathf.Clamp((transform.position.y + deltaY), yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }
    private void SetUpMoveBoundries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    public int GetHP()
    {
        return HP;
    }

}
