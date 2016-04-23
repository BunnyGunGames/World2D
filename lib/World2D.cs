using UnityEngine;
using System.Collections;
using BunnyGun;

namespace BunnyGun {

  public class World2D : MonoBehaviour {

    public static World2D world2D;

    [Header("Layer settings")]
    public int layerLevel;
    public int layerPlayer;
    public int layerPlayerDamage;
    public int layerMonster;

    //[Space(20)]
    void Awake() {
      if (world2D == null){
        DontDestroyOnLoad(gameObject);
        world2D = this;
      } else if (world2D != this){
        Destroy(gameObject);
      }
    }
  

  }  
}