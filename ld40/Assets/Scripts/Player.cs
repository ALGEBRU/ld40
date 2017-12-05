using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{

    private Rigidbody2D myRigidbody;

    [SerializeField]
    private bool shouldHop = false;

    [SerializeField]
    private bool hasHopped = false;

    private Animator myAnimator; 

    private bool facingRight = true;

    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private Transform cannonController;

    [SerializeField]
    private Transform[] groundpoints;

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private float health = 10.0f;

    [SerializeField]
    private int villagersEaten = 0;

    [SerializeField]
    private Transform healthBar;
 

    private bool isGrounded;

	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        groundRadius *= transform.localScale.x;

        isGrounded = IsGrounded(); 
        float horizontal = Input.GetAxis("Horizontal");

        handleMovement(horizontal);
        healthBar.GetChild(2).GetComponent<Text>().text = villagersEaten.ToString();
    }

    private void handleMovement(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
        }

        if (!isGrounded)
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }
        


        myAnimator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (shouldHop && !hasHopped)
        {
            myRigidbody.AddForce(new Vector3(0f, 4500f));
            hasHopped = true;
        }
        
    }

    private bool IsGrounded()
    {


        if(myRigidbody.velocity.y <= 0)
        {
            foreach (Transform point in groundpoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                        return true;
                }
            }
        }
        return false;
    }

    public void getHit(float size)
    {
        health -= (5.0f - size) * (villagersEaten / 50f);

        healthBar.GetComponent<Health>().ajustHealthBar(health / 10.0f);
        if (health <= 0.0f)
        {
            GameStates.score = villagersEaten;
            SceneManager.LoadScene(2);
        }

        transform.GetChild(3).GetComponent<AudioSource>().Play();
    }

    public void eatVilliger()
    {
        transform.GetComponent<AudioSource>().Play();
        villagersEaten++;
        Debug.Log("Villiger Eaten!!!");
        health += Random.Range(0.5f, 1.0f);
        healthBar.GetComponent<Health>().ajustHealthBar(health / 10.0f);
        if (health > 10.0f)
            health = 10.0f;
        if(villagersEaten < 321)
            if (facingRight)
            {
                transform.localScale = new Vector3(1.0f + (0.0125f * villagersEaten), 1.0f + (0.0125f * villagersEaten), 0.0f);
            }
            else
            {
                transform.localScale = new Vector3(-(1.0f + (0.0125f * villagersEaten)), 1.0f + (0.0125f * villagersEaten), 0.0f);
            }
        if(villagersEaten % 20 == 0)
        {
            cannonController.GetComponent<LightSoldierCannonController>().spawnCannon();
        }
    }
    public int getScore()
    {
        return villagersEaten; 
    }
}
