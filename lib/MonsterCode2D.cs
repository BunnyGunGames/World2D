using UnityEngine;
using System.Collections;
using BunnyGun;

namespace BunnyGun {

  public class MonsterCode2D : MonoBehaviour {

    public float hp;


    void OnTriggerEnter2D(Collider2D c){

      bool layerCheck = Lib2D.LayerMaskIntMatch(World2D.world2D.playerDamage, c.gameObject.layer);
      if (layerCheck){
        float wepDamage = c.gameObject.GetComponent<WeaponCode2D>().GetDamage();
        float wepForce = c.gameObject.GetComponent<WeaponCode2D>().GetForce();

        float wepForceDirection = Lib2D.TriggerDirectionLeft2D(gameObject, c) ? -1 : 1;
        
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
      Destroy(gameObject);
    
    }
  }
}