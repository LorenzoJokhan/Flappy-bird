using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float upForce = 200f;
    public bool isDead;

    private Animator anim;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Flap");
                body.velocity = Vector2.zero;
                body.AddForce(Vector2.up * upForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Die");
        isDead = true;
    }
}
