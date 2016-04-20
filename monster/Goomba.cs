using UnityEngine;
using System.Collections;
using BunnyGun;

namespace BunnyGun {

  public class Goomba : MonsterCode2D {

    Rigidbody2D rb2d;
    bool facingLeft;

    void Awake() {
      rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D c) {
    
      bool layerCheck = World2D.world2D.LayerMaskIntMatch(World2D.world2D.level, c.gameObject.layer);
      if (layerCheck) { 
        string collisionDirection2D = CollisionDirection2D(c);
        switch (collisionDirection2D) {
          case "left":  facingLeft = true;  break;
          case "right": facingLeft = false; break;
          default:break;
        }
      }
    }
    string CollisionDirection2D(Collision2D c) {
        Vector3 normal = c.contacts[0].normal;

        if (normal == Vector3.right)
          return "right";
        if (normal == Vector3.left)
          return "left";  
        if (normal == Vector3.up)
          return "bottom";
        if (normal == Vector3.down)
          return "top";

      return "unknown";
        
    }
    void FixedUpdate () {
      float rb2dy = rb2d.velocity.y;

      rb2d.velocity = facingLeft ?
        new Vector2(-1 * 2, rb2dy) :
        new Vector2(1 * 2, rb2dy);
    }
    public override void DestroyMonster() {
      base.DestroyMonster();
    }
  }
}