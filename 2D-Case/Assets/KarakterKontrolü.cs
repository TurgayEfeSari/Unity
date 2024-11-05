using System;
using UnityEngine;

public class KarakterKontrolü : MonoBehaviour
{
    Rigidbody2D rigidbody2;
    Vector3 velocity;
    public Animator animator;
    float speedamount = 4f;
    float jumpamount = 5f;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }
        
    // Update is called once per frame
    void Update()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedamount * Time.deltaTime;
        animator.SetFloat("Speed 0", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetButtonDown("Jump") && Mathf.Approximately(rigidbody2.linearVelocity.y, 0))
        {
            rigidbody2.AddForce(Vector3.up * jumpamount, ForceMode2D.Impulse);
            animator.SetBool("Zıplama", true);

        }
        if (animator.GetBool("Zıplama") && Mathf.Approximately(rigidbody2.linearVelocity.y, 0))
        {
            animator.SetBool("Zıplama", false);
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
