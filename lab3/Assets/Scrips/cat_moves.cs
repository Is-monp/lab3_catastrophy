using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
public class cat_moves : MonoBehaviourPunCallbacks
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpspeed;
    public Rigidbody2D mybody;
    public Animator myAnimator;
    public BoxCollider2D mycollider;
    public GameObject PlayerCamera;
    public TextMeshProUGUI PlayerName;
    public SpriteRenderer sr;

    private void Awake()
    {   
        mybody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mycollider=GetComponent<BoxCollider2D>();

        if (photonView.IsMine)
        {
            PlayerCamera.SetActive(true);
            PlayerName.text = PhotonNetwork.NickName;
        }
        else
        {
            PlayerName.text = photonView.Owner.NickName;
            PlayerName.color = Color.red;
            DisablePhysics();
            //mybody.gravityScale = 0f;
        }
        

    }
    private void checkInput()
    {
        var move = new Vector3(Input.GetAxisRaw("Horizontal"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            photonView.RPC("FlipTrue", RpcTarget.AllBuffered);
        }

        if (Input.GetKey(KeyCode.D))
        {
            photonView.RPC("FlipFalse", RpcTarget.AllBuffered);
        }

        if (Input.GetKey("w") && checkinGround.isGrounded)
        {
            photonView.RPC("Jump", RpcTarget.AllBuffered, jumpspeed);
        }

        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.D))
        {
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }

    }
    private void Update()
    {
        if(photonView.IsMine)
        {
            checkInput();
        }
    }



    [PunRPC]
    private void FlipTrue()
    {
        sr.flipX = true;

    }
    [PunRPC]
    private void FlipFalse()
    {
        sr.flipX = false;
    }

    [PunRPC]
    private void Jump(float jumpspeed)
    {
        mybody.velocity = new Vector2(mybody.velocity.x, jumpspeed);
    }

    private void DisablePhysics()
    {
        // Desactivar el Rigidbody2D
        if (mybody != null)
        {
            mybody.simulated = false;
        }

        // Desactivar todos los colliders en el objeto
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (var collider in colliders)
        {
            collider.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!photonView.IsMine)
        {
            if (mycollider != null)
            {
                mycollider.isTrigger = true;
            }
        }
    }

}
