using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBall : MonoBehaviour
{

    private Rigidbody2D myRigidbody2D;
    private bool isFalling = false;
    private Transform centerPoint;
    private Transform target;
    private GameObject playerGameObject;

	// Use this for initialization
	public void InitBall (Transform centerPoint, Transform target, GameObject playerGameObject)
    {
        this.centerPoint = centerPoint;
        this.target = target;
        this.playerGameObject = playerGameObject;

        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.AddForce(new Vector2(0.0f, 500f));
	}
	
	// Update is called once per frame
	public void updateBall ()
    {

        if (isFalling)
        {

            Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(centerPoint.position.x, centerPoint.position.y), 0.15f * transform.localScale.x);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject == playerGameObject)
                {
                    Debug.Log("Hit! You sunk my battleship");
                    playerGameObject.GetComponent<Player>().getHit(transform.localScale.x); 
                    Destroy(this.gameObject);
                }
                
            }

            if (transform.position.y < -10f)
                Destroy(this.gameObject);
        }
        else if (transform.position.y > 10.0f)
        {
            
            transform.localScale *= Random.Range(2f, 5f);
            transform.position = new Vector3(Random.Range(target.position.x -15f, target.position.x + 15f), 7f, transform.position.y);
            myRigidbody2D.gravityScale = 1;
            isFalling = true;
        }
	}
    public void destroy()
    {
        Destroy(this.gameObject);
    }
}
