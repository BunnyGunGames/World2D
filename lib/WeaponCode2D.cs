using UnityEngine;
using System.Collections;

public class WeaponCode2D : MonoBehaviour {
  public float activeSeconds, wepDamage, wepForce;
	
  // Update is called once per frame
  void TurnOff() {
    gameObject.SetActive(false);
  }
  void OnEnable() {
     Invoke("TurnOff", activeSeconds);
  }
  public float GetDamage() {
      return wepDamage;
  }
  public float GetForce() {
      return wepForce;
  }

}