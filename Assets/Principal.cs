using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Principal : MonoBehaviour {
	public GameObject canvas;
	//teste git 2 de novo
	public float altura_b1, velocidade_b1, tempo_b1;
	public float altura_b2, velocidade_b2, tempo_b2;
	public float gravidade;
	public InputField altura_input_b1;
	public InputField gravidade_input;
	public InputField altura_input_b2;

	

	
	
	//
	public GameObject txt_altura_b1, txt_altura_b2, txt_vel_b1, txt_vel_b2, txt_queda_b1, txt_queda_b2; //Como o objeto q vai ser exibido o texto e um 3D Text, criar uma variavel Text n vai funcionar
	public Dropdown drop;
	public Slider slide_bola1, slide_bola2;
	public Button btn_bola1, btn_bola2, btn_ambas, btn_reiniciar;
    public GameObject luaterreno, terraterreno, marteterreno, neutroterreno;
    
	//
	public GameObject GO_b1, GO_b2;
	//
	public bool bola1_colidiu = false, bola2_colidiu = false;
	//
	Vector3 bola1_pos_inicial, bola2_pos_inicial;
    //

    public Material[] skies;
	//public Renderer render;
	//

	public int target = 30;
      
      void Awake()
      {
          QualitySettings.vSyncCount = 0;
          Application.targetFrameRate = target;
      }

	void Start () {
		iniciar();
        altura_input_b1.text = "5";
        altura_input_b2.text = "5";
	}
	void FixedUpdate () {
		checar_input();
		gravidade_drop();
		sliders();
		textos();
		checar_planeta();
		checar_btn();
		botao_reiniciar();
		checar_btn_mudar_cena();

		if(Application.targetFrameRate != target){
              Application.targetFrameRate = target;
		}
		
	}

	  
      
     
	
	public void iniciar_bola1(){
		if(altura_input_b1.text != ""){
			resetar_bola1();
			float bolay = float.Parse(altura_input_b1.text);
			GO_b1.transform.position = new Vector3(GO_b1.transform.position.x, bolay, GO_b1.transform.position.z);
			Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
			rb_bola1.isKinematic = false;

			

			
		}
	}
	public void iniciar_bola2(){
		if(altura_input_b2.text != ""){
 			resetar_bola2();
			float bolay = float.Parse(altura_input_b2.text);
			GO_b2.transform.position = new Vector3(GO_b2.transform.position.x, bolay, GO_b2.transform.position.z);
			Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();
			rb_bola2.isKinematic = false;
			
		}  
	}
	public void ativar_ambas(){
		resetar();

		if(altura_input_b1.text != "" && altura_input_b2.text != ""){

			float bola1y = float.Parse(altura_input_b1.text);
			float bola2y = float.Parse(altura_input_b2.text);
			GO_b1.transform.position = new Vector3(GO_b1.transform.position.x, bola1y, GO_b1.transform.position.z);

			
			GO_b2.transform.position = new Vector3(GO_b2.transform.position.x, bola2y, GO_b2.transform.position.z);

			Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
			Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();
	
			rb_bola1.isKinematic = false;
			rb_bola2.isKinematic = false;

			
		}
	}
	public void checar_planeta(){
		//Renderer render_component = render.GetComponent<Renderer>();
		if(drop.value == 0){
			/*luaterreno.transform.position = new Vector3(-240,0,-30);
            marteterreno.transform.position = new Vector3(-2000, 0, 0);
            terraterreno.transform.position = new Vector3(2000, 0, 0);*/
		}else if (drop.value == 1){
            /*marteterreno.transform.position = new Vector3(-240, 0, -30);
            luaterreno.transform.position = new Vector3(-2000, 0, 0);
            terraterreno.transform.position = new Vector3(2000, 0, 0);*/
		}else if(drop.value == 2){
         /*   terraterreno.transform.position = new Vector3(-240, 0, -30);
            luaterreno.transform.position = new Vector3(-2000, 0, 0);
            marteterreno.transform.position = new Vector3(2000, 0, 0);*/
		}
	}
	void textos(){
		Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();
		Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();

	  	bool col_b1,col_b2;
		col_b1 = rb_bola1.isKinematic;
		col_b2 = rb_bola1.isKinematic;
		

		if(bola1_colidiu == false && rb_bola1.isKinematic == false){
			tempo_b1 = Time.deltaTime + tempo_b1;
			altura_b1 = (gravidade * (tempo_b1 * tempo_b1))/2;
			velocidade_b1 = gravidade * tempo_b1;

			txt_altura_b1.GetComponent<TextMesh>().text = "Altura = " + altura_input_b1.text;
			txt_vel_b1.GetComponent<TextMesh>().text = "Velocidade = " + velocidade_b1.ToString();
			txt_queda_b1.GetComponent<TextMesh>().text = "Tempo de queda = " + tempo_b1.ToString();
		}

		if(bola2_colidiu == false && rb_bola2.isKinematic == false){
			print("teste");
			tempo_b2 = Time.deltaTime + tempo_b2;
			altura_b2 = (gravidade * (tempo_b2 * tempo_b2))/2;
			velocidade_b2 = gravidade * tempo_b2;

			txt_altura_b2.GetComponent<TextMesh>().text = "Altura = " + altura_input_b2.text;
			txt_vel_b2.GetComponent<TextMesh>().text = "Velocidade = " + velocidade_b2.ToString();
			txt_queda_b2.GetComponent<TextMesh>().text = "Tempo de queda = " + tempo_b2.ToString();
		}
		
		
	}
	
	void checar_btn(){
		btn_bola1.onClick.AddListener(iniciar_bola1);
		btn_bola2.onClick.AddListener(iniciar_bola2);
		btn_ambas.onClick.AddListener(ativar_ambas);
		btn_reiniciar.onClick.AddListener(resetar);
	}
	public void resetar(){
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
			GO_b2.transform.position = new Vector3(8.56f, slide_bola2.value, -7f);
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
			luaterreno.SetActive(false);
			marteterreno.SetActive(false);
			neutroterreno.SetActive(false);
			terraterreno.SetActive(true);

            RenderSettings.skybox = skies[0];
			gravidade_input.text = gravidade.ToString();
        }
        else if(drop.value == 2){
			Physics.gravity = new Vector3 (0, -3.81f, 0);
			gravidade = 3.71f;
			luaterreno.SetActive(false);
			terraterreno.SetActive(false);
			neutroterreno.SetActive(false);
			marteterreno.SetActive(true);

            RenderSettings.skybox = skies[2];
			gravidade_input.text = gravidade.ToString();
        }
        else if(drop.value == 1){
			Physics.gravity = new Vector3 (0, -1.61f, 0);
			gravidade = 1.61f;
			marteterreno.SetActive(false);
			terraterreno.SetActive(false);
			neutroterreno.SetActive(false);
            luaterreno.SetActive(true);

            RenderSettings.skybox = skies[1];
			gravidade_input.text = gravidade.ToString();
        } else if(drop.value == 3){
			marteterreno.SetActive(false);
			terraterreno.SetActive(false);
			neutroterreno.SetActive(true);
			luaterreno.SetActive(false);

			RenderSettings.skybox = skies[3];

			float grav = float.Parse(gravidade_input.text);
			Physics.gravity = new Vector3(0, grav * -1, 0);
		}
	}
	public void botao_reiniciar(){
		if(Input.GetKeyDown(KeyCode.R)){
			resetar();
		}
	}

	public void checar_btn_mudar_cena(){
		if(Input.GetKeyDown(KeyCode.E)){
			SceneManager.LoadScene(0);
		}
	}

	public void mudar_cena(){
		SceneManager.LoadScene(0);
	}

    public void resetar_bola1() {



        GO_b1.transform.position = bola1_pos_inicial;
        altura_b1 = velocidade_b1 = tempo_b1 = 0;
        Rigidbody rb_bola1 = GO_b1.GetComponent<Rigidbody>();

        rb_bola1.isKinematic =  true;

        txt_altura_b1.GetComponent<TextMesh>().text = "altura = (gravidade * tempo²)/2";
        txt_vel_b1.GetComponent<TextMesh>().text = "velocidade = gravidade * tempo";

       

        bola1_colidiu = false;
    }

    public void resetar_bola2() {
        Rigidbody rb_bola2 = GO_b2.GetComponent<Rigidbody>();
        rb_bola2.isKinematic = true;

       

        txt_altura_b2.GetComponent<TextMesh>().text = "altura = (gravidade * tempo²)/2";
        txt_vel_b2.GetComponent<TextMesh>().text = "velocidade = gravidade * tempo";

        bola2_colidiu = false;
    }

	/*public void input_valor_alterado(int int32){
		Debug.Log(int32);
		if (int32 == 0){
			gravidade_input_b1.text = "9.81";
			gravidade_input_b2.text = "9.81";
		}
		if (int32 == 1){
			gravidade_input_b1.text = "3.71";
			gravidade_input_b2.text = "3.71";
		}
		if (int32 == 2){
			gravidade_input_b1.text = "9.81";
			gravidade_input_b2.text = "9.81";
		}
	}*/

	public void checar_input(){
		if(gravidade_input.text == ""){
			gravidade_input.text = "0";
		}
	}
}
