﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void MudardeCena(int cena_id){
		SceneManager.LoadScene(cena_id);
	}
}
