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

      bool layerCheckLevel = Lib2D.LayerMaskIntMatch(World2D.world2D.level, c.gameObject.layer);
      
      if (layerCheckLevel) { 
        string collisionDirection2D = Lib2D.CollisionDirection2D(c);
        switch (collisionDirection2D) {
          case "left":  facingLeft = true;  break;
          case "right": facingLeft = false; break;
          default:break;
        }
      }
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