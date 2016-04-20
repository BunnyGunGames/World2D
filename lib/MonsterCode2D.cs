using UnityEngine;
using System.Collections;

public class MonsterCode2D : MonoBehaviour {

  public float hp;


  void OnTriggerEnter2D(Collider2D c){
    print("fired on monster code");
    if (c.gameObject.layer == LayerMask.NameToLayer("PlayerDamage")){
      float wepDamage = c.gameObject.GetComponent<WeaponCode2D>().GetDamage();
      float wepForce = c.gameObject.GetComponent<WeaponCode2D>().GetForce();

      //refactor this out and use the direction testing from goomba.cs
      float wepForceDirection = c.gameObject.transform.parent.gameObject.GetComponent<PlayerCode2D>().m_FacingRight;
    
      TakeDamage(wepDamage, wepForce, wepForceDirection);
    }
  }

  void TakeDamage(float damage, float force, float forceDirection) {
    hp = hp - damage;
    //need to get the collision direction to direct force...
    GetComponent<Rigidbody2D>().AddForce(Vector2.right * force * forceDirection);
    if(hp < 1) {
      DestroyMonster();
    }  
  }

  public virtual void DestroyMonster() {
   print("destroyed from MonsterCode2D");
    Destroy(gameObject);
    
  }
}
