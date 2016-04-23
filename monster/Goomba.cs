using UnityEngine;
using System.Collections;
using BunnyGun;

namespace BunnyGun {

  public class Goomba : MonsterCode2D {

    Rigidbody2D rb2d;
    bool facingLeft;

    void Awake() {
      rb2d = GetComponent<Rigidbody2D>();
      gameObject.layer = World2D.world2D.layerMonster;

    }

    void OnCollisionEnter2D(Collision2D c) {

      bool layerCheckLevel   = World2D.world2D.layerLevel == c.gameObject.layer;
      bool checkMonsterLayer = World2D.world2D.layerMonster == c.gameObject.layer;
      
      if (layerCheckLevel || checkMonsterLayer){ 
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
        new Vector2(1 * 2, rb2dy) :
        new Vector2(-1 * 2, rb2dy);
    }
    public override void DestroyMonster() {
      base.DestroyMonster();
    }
  }
}