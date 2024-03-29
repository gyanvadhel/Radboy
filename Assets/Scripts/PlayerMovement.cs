using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip hurtSFX;
    [SerializeField] float clipVolume = 0.25f;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] AudioClip shootSFX;
   
    Vector2 moveInput;

    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;

    bool isAlive = true;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
    }

    void Update()
     {

        if(!isAlive)
        {
            return;
        }

        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }
    

    void OnMove(InputValue value)
    {
        if(!isAlive || PauseMenu.isPaused)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
    }

   /*void OnFire(InputValue value)
    {
        if(!isAlive)
        {
            return;
        }
        Instantiate(bullet,gun.position,transform.rotation);
        AudioSource.PlayClipAtPoint(shootSFX,Camera.main.transform.position,clipVolume);
    }*/

    void OnJump(InputValue value)
    {
        if(!isAlive || PauseMenu.isPaused)
        {
            return;
        }

        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) 
        {
           return;
        }
        
        if(value.isPressed) 
        {
            // do stuff
            AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position,clipVolume);
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
        
    }


    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
    void ClimbLadder()
    {
        
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing",false); 
            return;
        }

        Vector2 ClimbVelocity = new Vector2 (myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = ClimbVelocity;
        myRigidbody.gravityScale = 1.5f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing",playerHasVerticalSpeed);
    }

    void Die()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity += new Vector2 (1f,3f)/1.5f;
            AudioSource.PlayClipAtPoint(hurtSFX, Camera.main.transform.position,clipVolume);
            //myBodyCollider.enabled = false;
            //myFeetCollider.enabled = false;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }
}
