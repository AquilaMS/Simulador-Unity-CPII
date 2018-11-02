using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Principal : MonoBehaviour {
	//
	public float altura_b1, velocidade_b1, tempo_b1;
	public float altura_b2, velocidade_b2, tempo_b2;
	public float gravidade;
	//
	public GameObject txt_altura_b1, txt_altura_b2, txt_vel_b1, txt_vel_b2; //Como o objeto q vai ser exibido o texto e um 3D Text, criar uma variavel Text n vai funcionar
	public Dropdown drop;
	public Slider slide_bola1, slide_bola2;
	public Button btn_bola1, btn_bola2, btn_ambas;
	//
	public GameObject GO_b1, GO_b2;
	//
	public bool bola1_colidiu = false, bola2_colidiu = false;
	//
	Vector3 bola1_pos_inicial, bola2_pos_inicial;
	//
	public Texture[] chao_texturas;
	public Renderer render;
	//
	void Start () {
		iniciar();
	    
	}
	void Update () {
		gravidade_drop();
		sliders();
		textos();
		checar_planeta();
		checar_btn();
		botao_reiniciar();
	}
	
	public void iniciar_bola1(){
		Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
		rb_bola1.isKinematic = false;
		
	}
	public void iniciar_bola2(){
	
		Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();
		rb_bola2.isKinematic = false;
	}
	public void ativar_ambas(){
		Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
		Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();

		rb_bola1.isKinematic = false;
		rb_bola2.isKinematic = false;
	}
	void checar_planeta(){
		Renderer render_component = render.GetComponent<Renderer>();
		if(drop.value == 0){
			render.material.mainTexture = chao_texturas[0];
		}else if (drop.value == 1){
			render.material.mainTexture = chao_texturas[1];
		}else if(drop.value == 2){
			render.material.mainTexture = chao_texturas[2];
		}
	}
	void textos(){
		Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
		Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();

	  	bool col_b1,col_b2;
		col_b1 = rb_bola1.isKinematic;
		col_b2 = rb_bola1.isKinematic;
		if(bola2_colidiu == false && rb_bola2.isKinematic == false){
			print("teste");
			tempo_b2 = Time.deltaTime + tempo_b2;
			altura_b2 = (gravidade * (tempo_b2 * tempo_b2))/2;
			velocidade_b2 = gravidade * tempo_b2;

			txt_altura_b2.GetComponent<TextMesh>().text = altura_b2.ToString("#.00") + " = (" + gravidade.ToString("#.00") + " * " + tempo_b2.ToString("#.00") +"²)/2";
			txt_vel_b2.GetComponent<TextMesh>().text = velocidade_b2.ToString("#.00") + " = " + gravidade.ToString("#.00") + " * " + tempo_b2.ToString("#.00");
		}

		if(bola1_colidiu == false && rb_bola1.isKinematic == false){
			tempo_b1 = Time.deltaTime + tempo_b1;
			altura_b1 = (gravidade * (tempo_b1 * tempo_b1))/2;
			velocidade_b1 = gravidade * tempo_b1;

			txt_altura_b1.GetComponent<TextMesh>().text = altura_b1.ToString("#.00") + " = (" + gravidade.ToString("#.00") + " * " + tempo_b1.ToString("#.00") +"²)/2";
			txt_vel_b1.GetComponent<TextMesh>().text = velocidade_b1.ToString("#.00") + " = " + gravidade.ToString("#.00") + " * " + tempo_b1.ToString("#.00");
		}
		
		
	}
	
	void checar_btn(){
		btn_bola1.onClick.AddListener(iniciar_bola1);
		btn_bola2.onClick.AddListener(iniciar_bola2);
		btn_ambas.onClick.AddListener(ativar_ambas);
	}
	void resetar(){
		GO_b1.transform.position = bola1_pos_inicial;
		GO_b2.transform.position = bola2_pos_inicial;

		altura_b1 = velocidade_b1 = tempo_b1 = 0;
		altura_b2 = velocidade_b2 = tempo_b2 = 0;

		Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
		Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();

		rb_bola1.isKinematic = rb_bola2.isKinematic = true;

		txt_altura_b1.GetComponent<TextMesh>().text = "altura = (gravidade * tempo²)/2";
		txt_vel_b1.GetComponent<TextMesh>().text = "velocidade = gravidade * tempo";

		txt_altura_b2.GetComponent<TextMesh>().text = "altura = (gravidade * tempo²)/2";
		txt_vel_b2.GetComponent<TextMesh>().text = "velocidade = gravidade * tempo";

		bola1_colidiu = bola2_colidiu = false;
	}
	void sliders(){
		
		Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
		Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();
		bool col_b1,col_b2;

		col_b1 = rb_bola1.isKinematic;
		col_b2 = rb_bola1.isKinematic;

		if(rb_bola1.isKinematic){
			GO_b1.transform.position = new Vector3(-1.3f, slide_bola1.value, -7f);
		}
		if(rb_bola2.isKinematic == true){
			GO_b2.transform.position = new Vector3(1.14f, slide_bola2.value, -7f);
		}
	}
	void iniciar(){
		bola1_pos_inicial = GO_b1.transform.position;
		bola2_pos_inicial = GO_b2.transform.position;
	}
	void gravidade_drop(){
		if(drop.value == 0){
			Physics.gravity = new Vector3 (0, -9.81f, 0);
			gravidade = 9.81f;
		}else if(drop.value == 2){
			Physics.gravity = new Vector3 (0, -3.81f, 0);
			gravidade = 3.71f;
		}else if(drop.value == 1){
			Physics.gravity = new Vector3 (0, -1.61f, 0);
			gravidade = 1.61f;
		}
	}
	void botao_reiniciar(){
		if(Input.GetKeyDown(KeyCode.R)){
			resetar();
		}
	}
}
