using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villiger : MonoBehaviour {

    private float triggerRange = 4f;
    
    private float fleeSpeed = 3f;

    private Transform playerTransform;

    private float eatRange = 0.6f;

    private Rigidbody2D myRigidbody2D;
    private Animator myAnimator;
    private bool fleeMode = false;
    private bool facingRight = true;

    public void InitVillager(Transform playerTransform)
    {
        this.playerTransform = playerTransform;
        myRigidbody2D = transform.GetComponent<Rigidbody2D>();
        myAnimator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    public bool updateVillager()
    {
        if (fleeMode)
        {
            if (transform.position.x - playerTransform.position.x < 0.0f && facingRight || transform.position.x - playerTransform.position.x > 0.0f && !facingRight)
            {
                facingRight = !facingRight;
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, 1);
            }

            if (facingRight)
            {
                myRigidbody2D.velocity = new Vector2(fleeSpeed, myRigidbody2D.velocity.y);
            }
            else
            {
                myRigidbody2D.velocity = new Vector2(-fleeSpeed, myRigidbody2D.velocity.y);
            }

            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), eatRange);
            for(int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].gameObject == playerTransform.gameObject)
                {
                    playerTransform.GetComponent<Player>().eatVilliger();
                    return true;
                }
            }
        }
        else
        {
            if (Mathf.Abs(transform.position.x - playerTransform.position.x) < triggerRange)
            {
                fleeMode = true;
            }
        }
        
        myAnimator.SetFloat("Speed", Mathf.Abs(myRigidbody2D.velocity.x));
        return false;
    }
    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
