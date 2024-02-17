using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] AudioClip healthPickSFX;
    [SerializeField] float clipVolume = 0.25f;
    [SerializeField] int addHealth = 1;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToHealth(addHealth);
            AudioSource.PlayClipAtPoint(healthPickSFX, Camera.main.transform.position,clipVolume);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }    
    }
}

