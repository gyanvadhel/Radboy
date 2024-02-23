using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] AudioClip enemyDieSFX;
    [SerializeField] AudioClip objectSFX;
    [SerializeField] float clipVolume = 0.25f;
    
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(xSpeed,0f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(enemyDieSFX,Camera.main.transform.position,clipVolume);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(objectSFX,Camera.main.transform.position,clipVolume);
        Destroy(gameObject);   
    }
}