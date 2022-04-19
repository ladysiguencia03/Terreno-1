using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPasos : MonoBehaviour {

 public AudioSource Pie;

 // Use this for initialization
 void OnTriggerEnter (Collider other) 
 {
  if (other.gameObject.tag == "Terrain") 
  {
   Pie.Play();
  }
 }
}