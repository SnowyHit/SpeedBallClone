using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpHandler : MonoBehaviour
{
  movementHandler playerScript ;
  GameObject go ;
  void Start()
  {
    go = GameObject.Find("player");
    playerScript = go.GetComponent<movementHandler>();
  }
  private void OnTriggerEnter(Collider other)
   {
     playerScript.jump = true ; 
   }
}
