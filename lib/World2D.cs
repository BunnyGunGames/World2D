using UnityEngine;
using System.Collections;
using BunnyGun;

namespace BunnyGun {

  public class World2D : MonoBehaviour {

    public static World2D world2D;

    [Header("Layer settings")]
    [SerializeField] public LayerMask level;
    [SerializeField] public LayerMask player;
    [SerializeField] public LayerMask playerDamage;

    //[Space(20)]

    void Awake() {
      if (world2D == null)
      {
        DontDestroyOnLoad(gameObject);
        world2D = this;
      } else if (world2D != this){
        Destroy(gameObject);
      }
    }
    public bool LayerMaskIntMatch(LayerMask layerMask, int i) {
      return layerMask >> i == 1 ? true : false;
    }
    public void Foo() {
      print("fired fpoo");
    }

  }  
}