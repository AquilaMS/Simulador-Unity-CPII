using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gravidade : MonoBehaviour {
	public GameObject VAZIO;
	public Texture[] chao_texturas;
	public Renderer render;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		mudar_gravidade();
	}
	void mudar_gravidade(){
		if(Input.GetKey(KeyCode.Z)){
			Physics.gravity = new Vector3 (0, -9.81f, 0);
			render.material.mainTexture = chao_texturas[0];
		}
		if(Input.GetKey(KeyCode.X)){
			Physics.gravity = new Vector3 (0, -1.61f, 0);
			render.material.mainTexture = chao_texturas[1];
		}
		if(Input.GetKey(KeyCode.C)){
			Physics.gravity = new Vector3 (0, -3.81f, 0);
			render.material.mainTexture = chao_texturas[2];
		}
		if(Input.GetKey(KeyCode.E)){
			SceneManager.LoadScene(0);
		}
	}
}
