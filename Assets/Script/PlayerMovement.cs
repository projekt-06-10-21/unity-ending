using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float MovementSpeed = 2;
    public float JumpForce = 1;
    private Rigidbody2D _rigidbody;
    public GameObject Bullet;

    Vector3 lastDirection;
    float shootInterval, lastShoot;
     void Start()
    {
        lastDirection = Vector3.down;
        shootInterval = 0.5f;
        lastShoot = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }

        
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.X))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(lastShoot <=0)
        {
            GameObject p = Instantiate(Bullet, transform.position, Quaternion.identity);
            p.GetComponent<Rigidbody2D>().AddForce(lastDirection * 1000);
            Destroy(p, 3);
            lastShoot = shootInterval;
        }
        else
        {
            lastShoot -= Time.deltaTime;
        }
    }

}


