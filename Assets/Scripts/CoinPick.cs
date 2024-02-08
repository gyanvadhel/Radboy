using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPick : MonoBehaviour
{
    [SerializeField] AudioClip coinPickSFX;
    [SerializeField] float clipVolume = 0.25f;
    [SerializeField] int pointsForCoinPickup = 15;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(coinPickSFX, Camera.main.transform.position,clipVolume);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }    
    }
}
