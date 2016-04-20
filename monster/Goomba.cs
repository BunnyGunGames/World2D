using UnityEngine;
using System.Collections;

public class Goomba : MonoBehaviour {

  public int levelLayerNumber;

  Rigidbody2D rb2d;
  bool facingLeft;


  // Use this for initialization
  void Awake() {
    rb2d = GetComponent<Rigidbody2D>();
  }

  void OnCollisionEnter2D(Collision2D c) {
    if(c.gameObject.layer == levelLayerNumber) {
      Vector3 normal = c.contacts[0].normal;

      if (normal == Vector3.right)
        facingLeft = false;
      if (normal == Vector3.left)
        facingLeft = true;
      if (normal == Vector3.up)
        print("hit from bottom");
      if (normal == Vector3.down)
        print("hit from top");

    }
  }

  void FixedUpdate () {
    float rb2dy = rb2d.velocity.y;

    rb2d.velocity = facingLeft ?
      new Vector2(-1 * 2, rb2dy) :
      new Vector2(1 * 2, rb2dy);
  }
}