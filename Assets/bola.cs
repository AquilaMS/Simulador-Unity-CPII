using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour {

	public int ID;
	public GameObject VAZIO;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnCollisionEnter(Collision col){

		if(col.gameObject.tag == "chao"){
			Rigidbody rb = GetComponent<Rigidbody>();
			if(ID == 1){
				Principal principal1 = VAZIO.GetComponent<Principal>();
				principal1.bola1_colidiu = true;
				
			}
			if(ID == 2){
				Principal principal2 = VAZIO.GetComponent<Principal>();
				principal2.bola2_colidiu = true;
				
			}
		}
	}
}
