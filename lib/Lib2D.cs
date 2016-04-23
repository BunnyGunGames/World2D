using UnityEngine;
using System.Collections;

namespace BunnyGun {


  public class Lib2D : MonoBehaviour {

    public static bool LayerMaskIntMatch(LayerMask layerMask, int i) {
      return layerMask >> i == 1 ? true : false;
    }

    public static bool TriggerDirectionLeft2D(GameObject g, Collider2D c) {
      //returns a bool evaluating if the object hit from the left or not
      float colliderCenter = c.bounds.center.x;
      float gameObjectCenter = g.transform.position.x;
      return colliderCenter > gameObjectCenter;
      
    }

    public static string CollisionDirection2D(Collision2D c) {
      //returns a string for 1 of 4 possible directions
      Vector3 normal = c.contacts[0].normal;

      if (normal == Vector3.right)
        return "left";
      if (normal == Vector3.left)
        return "right";
      if (normal == Vector3.up)
        return "bottom";
      if (normal == Vector3.down)
        return "top";

      return "unknown";

    }

  }
}