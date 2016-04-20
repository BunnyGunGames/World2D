using UnityEngine;
using System.Collections;

public class PlayerCode2D : MonoBehaviour {
  public float walkSpeed, jumpPower;
  public bool SpriteFlipMode;

  bool spriteForward;
  public float m_FacingRight;

  Animator animator;
  Rigidbody2D rb2d;

  [SerializeField]
  private LayerMask m_WhatIsGround;   // A mask determining what is ground to the character

  private Transform m_GroundCheck;
  const float k_GroundedRadius = .2f;
  private bool m_Grounded;

  void Awake(){
    
    animator = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
    m_GroundCheck = transform.Find("GroundCheck");
    

  }
  void Update () {
    CheckIfGrounded();
    HandlePlayerMovement();  

  }

  void CheckIfGrounded() {
    m_Grounded = false;

    Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
    for (int i = 0; i < colliders.Length; i++)
    {
      if (colliders[i].gameObject != gameObject)
        m_Grounded = true;
    }
    animator.SetBool("Grounded", m_Grounded);

  }

  void HandlePlayerMovement(){
    if (Input.GetButtonDown("Fire1")){
      JumpPlayer();
    }
    
    if (Input.GetButtonDown("Fire2")){
      ChopPlayer();
    }
    //if the player is idle...
    if(Input.GetAxisRaw("Horizontal") == 0){      
      IdlePlayer(); //update animation
    }

    //if the player is hitting the stick
    if(Input.GetAxisRaw("Horizontal") != 0){
      MovePlayerX(); //move player on x axis
      SpriteFlip();  //handle x axis flip
    }

  }
  void ChopStop() {
        transform.Find("Weapon_hands").gameObject.SetActive(false);
  }
  void ChopPlayer(){
    if(m_Grounded) {
      transform.Find("Weapon_hands").gameObject.SetActive(true);
      animator.SetTrigger("Chopping");
    }
  }
  void JumpPlayer(){
   
    if (m_Grounded){
      rb2d.AddForce(new Vector2(0f, jumpPower));
    }

  }
  void IdlePlayer(){
    animator.SetBool("Walking", false);
  }
  void MovePlayerX(){
    animator.SetBool("Walking", true);
    rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * walkSpeed, rb2d.velocity.y);

  }
  void SpriteFlip(){
    if(SpriteFlipMode) {
      //sprite only flip mode
      GetComponent<SpriteRenderer>().flipX = Input.GetAxis("Horizontal") < 0 ? true : false;
    } else {
      //transform flip mode
      Vector3 flipVector3 = transform.localScale;
      flipVector3.x = Input.GetAxisRaw("Horizontal") > 0 ? 1f : -1f;
      m_FacingRight = flipVector3.x;
      if (transform.localScale.x != flipVector3.x) {
        transform.localScale = flipVector3;
      }
    }
  }
}