using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class cat_moves : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D mybody;
    private Animator myAnimator;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        mybody.velocity = new Vector2(horizontalInput * speed, mybody.velocity.y);
        myAnimator.SetFloat("Horizontal", Mathf.Abs(horizontalInput));

        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        if (Input.GetKey("w")&& checkinGround.isGrounded)
        {
            mybody.velocity=new Vector2(mybody.velocity.x, speed);
        }
    }
}
