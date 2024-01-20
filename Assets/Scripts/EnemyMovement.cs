using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{ 
    public float yForce;
    public float xForce;
    public float xDirection;
    public float yDirection;



    private Rigidbody2D enemyRigidbody;
    public float speed;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (transform.position.x <= -8)
        {
            speed = speed * -1;
            xDirection = 1;
            enemyRigidbody.AddForce(Vector2.right * xForce);
        }
        if (transform.position.x >= 8)
        {
            speed = speed * -1;
            xDirection = -1;
            enemyRigidbody.AddForce(Vector2.left * xForce);
        }
        if (transform.position.y <= -8)
        {
            speed = speed * -1;
            yDirection = 1;
            enemyRigidbody.AddForce(Vector2.right * yForce);
        }
    }


       
    //{
    //    if (transform.position.x <= -8)
    //    {
    //        speed = speed * -1;
    //    }
    //    if (transform.position.x >= 8)
    //    {
    //        speed = speed * -1;
    //    }
    //    float newXPosition = transform.position.x + speed * Time.deltaTime;
    //    float newYPosition = transform.position.y;
    //    Vector2 newPosition = new Vector2(newXPosition, newYPosition);
    //    transform.position = newPosition; 
    //}

    // Update is called once per frame
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Vector2 jumpForce = new Vector2(xForce * xDirection, yForce);
            enemyRigidbody.AddForce(jumpForce);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            speed = speed * -1;

            Vector2 jumpForce = new Vector2(xForce * -xDirection, yForce);
            enemyRigidbody.AddForce(jumpForce);
        }
    }
}
