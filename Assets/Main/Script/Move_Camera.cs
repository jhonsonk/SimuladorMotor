/* Jhonson de Souza Rodrigues.
 * Data: 05/10/2015.
 * Classe: Move_Camera.
 * Entradas: Botao direito do mouse.
 * Saida: Movimento da camera.
 * Objetivo: Tratar os movimentos da camera.
 * Objetos externos: Nenhum.
 * Variaveis externas: Nenhuma.
 * Descriçao: O movimento da camera eh travado na posiçoes dos objetos,
 * com isso a camera se move da posicao inicial para posicao do objeto
 * selecionado,as posiçoes dos objetos sao pre-definidas, bem como a 
 * posicao inicial, para voltar para a posicao inicial basta selecionar
 * novamente o mesmo objeto, para selecionar o objeto basta clicar com
 * o botao direito no objeto.
 */

using UnityEngine;
using System.Collections;
//using UnityEditor;
using System;

public class Move_Camera : MonoBehaviour {

	//Posiçoes das cameras
	private Vector3 Pos_Inicial;
	private Vector3 Posicao;
	private Vector3 Pos_Motor;
	private Vector3 Pos_Carga;
	private Vector3 Pos_Reostato;
	private Vector3 Pos_Acionamento;
	private Vector3 Pos_Medidor_1;
	private Vector3 Pos_Medidor_2;
	private Vector3 Pos_Medidor_3;
	private Vector3 Pos_Sassi;
	private Vector3 Pos_Variador_1;
	private Vector3 Pos_Variador_2;
	private Vector3 Pos_Emergencia;
	private Vector3 Pos_Motor_alvo;
	private Vector3 Pos_Motor_set;
	
	private float speed;
	private bool zoom_motor;
	private bool zoom_objeto;

	private float rotZ;
	private string Objeto_Clicado;


	void Start(){
		//Posicao das cameras nos objetos  
		Pos_Inicial.Set (-1.323f,2.1f,-0.1f);
		Posicao.Set (-1.323f,2.1f,-0.1f);
		Pos_Motor.Set (-4.968f,2.824f,-0.1f);
		Pos_Motor_alvo.Set (-5.4107f, 1.0971f, -0.1f);
		Pos_Motor_set.Set (-4.37f, 5.18f, -0.1f);

		Pos_Carga.Set (-3.587f,1.505f,0.487f);
		Pos_Reostato.Set (-3.981f,1.463f,-0.678f);
		Pos_Acionamento.Set (-4.288f,2.064f,-0.77f);
		Pos_Medidor_1.Set (-4.288f,2.064f,-0.571f);
		Pos_Medidor_2.Set (-4.288f,2.064f,-0.386f);
		Pos_Medidor_3.Set (-4.288f,2.064f,-0.199f);
		Pos_Sassi.Set (-4.288f,2.064f,-0.003f);
		Pos_Variador_1.Set (-4.288f,2.064f,0.183f);
		Pos_Variador_2.Set (-4.288f,2.064f,0.37f);
		Pos_Emergencia.Set (-4.288f,2.064f,0.563f);

		rotZ = 0;
		speed = 2;
		zoom_motor = false;
		zoom_objeto = true;
	}
	
	/* NAO podera haver movimento da camera para outros pontos,
	 * durante o movimento do motor, qualquer outro movimento
	 * entre o motor e qualquer outra parte soh eh permitido quando 
	 * a camera estiver no ponto inicial.
	 * Eh permitido movimento entre as outras partes sem a nescessidade
	 * de retorno ao ponto incial.
	 * Essa proibicao eh devido ao movimento de rotacao.
	 */

	//funcao de atualizacao dos frames
	void Update() {

		float step = speed * Time.deltaTime;//calculo do passos dos deslocamento

		//movimento de camera nos objetos exeto no motor
		// Incia como TRUE, e se torna FALSE durante o movimento do motor, e retorna para TRUE.
		if (zoom_objeto==true){ 
			transform.position = Vector3.Lerp (transform.position, Posicao, 3.3f * step);
		}// fim do if de translacao

		// ZOOM IN. movimento de camera para o motor, primeiro rotaciona, depois translada
		if (zoom_motor == true) {//zoom_motor = true, ZOOM IN
			// Rotaciona a camera
			if (rotZ < 62) {
				rotZ= rotZ + 8;
				// rotaciona em volta de um alvo, no caso o motor
				this.transform.RotateAround (Pos_Motor_alvo, Vector3.forward, 8);
			}// fim do if de rotacao
			// Depois de rotacionar, translada 
			if (rotZ >= 61) {
				transform.position = Vector3.Lerp (transform.position, Pos_Motor, 3f * step);
			}// fim do if de translacao
		// ZOOM OUT. Movimento para voltar a possicao incial, Rotaciona e depois translada
		} else if (zoom_objeto==false){ // zoom_motor=false, ZOOM OUT
			//Rotaciona a camera
			if (rotZ > 0) {
				rotZ= rotZ - 8;
				// rotaciona em volta de um alvo, no caso o motor
				this.transform.RotateAround (Pos_Motor_alvo, Vector3.forward, -8);
			}// fim do if de rotacao 
			// depois de rotacionar, translada
			if (rotZ <= 0) {
				transform.position = Vector3.Lerp (transform.position, Pos_Inicial, 3f * step);
			}// fim do if translada
		}// fim do else

		// Verifica se esta na posicao Inicial. 
		if (transform.position.Equals(Pos_Inicial)){
			//Habilita o movimento para outros objetos.
			zoom_objeto=true;
		}// fim do if da posicao inicial


		//Trata os eventos do botao direito do mouse
		if (Input.GetMouseButtonUp(1)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);//Pega a posicao do mouse

			// Trata os possiveis erro de nao coliçao
			try {
				//Revifica se ouve colicao do mouse com um objeto
				if (Physics.Raycast (ray, out hit))
				{
					//Pega o nome do objeto da colicao
					Objeto_Clicado = hit.rigidbody.GetComponent<Rigidbody> ().tag;

					// Verifica qual o objeto foi selecionado
					if (Objeto_Clicado=="ACIONAMENTO"){
						//Verifica se ja esta com zoom
						if(Posicao.Equals(Pos_Acionamento)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Acionamento;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else

					} else if(Objeto_Clicado=="MEDIDOR_1"){
						//Verifica se ja esta com zoom
						if(Posicao.Equals(Pos_Medidor_1)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Medidor_1;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else

					} else if(Objeto_Clicado=="MEDIDOR_2"){
						//Verifica se ja esta com zoom
						if(Posicao.Equals(Pos_Medidor_2)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Medidor_2;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else
					
					} else if(Objeto_Clicado=="MEDIDOR_3"){
						//Verifica se ja esta com zoom
						if(Posicao.Equals(Pos_Medidor_3)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Medidor_3;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else
						
					} else if(Objeto_Clicado=="SASSI"){
						//Verifica se ja esta com zoom
						if(Posicao.Equals(Pos_Sassi)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Sassi;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else
						
					} else if(Objeto_Clicado=="VARIADOR_1"){
						//Verifica se ja esta com zoom
						if(Posicao.Equals(Pos_Variador_1)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Variador_1;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [3] = 1;
						}// fim do else
						
					} else if(Objeto_Clicado=="VARIADOR_2"){
						if(Posicao.Equals(Pos_Variador_2)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Variador_2;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [3] = 1;
						}// fim do else
						
					} else if(Objeto_Clicado=="EMERGENCIA"){
						if(Posicao.Equals(Pos_Emergencia)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Emergencia;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else

					} else if(Objeto_Clicado=="REOSTATO"){
						if(Posicao.Equals(Pos_Reostato)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Reostato;
							zoom_objeto=true;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else
						
					} else if(Objeto_Clicado=="MOTOR"){
						if(Posicao.Equals(Pos_Motor)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							zoom_motor=false;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
						} else { //caso sem o ZOOM
							Posicao=Pos_Motor;
							zoom_motor=true;
							zoom_objeto=false;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
						}// fim do else
						
					} else if(Objeto_Clicado=="CARGA"){
						if(Posicao.Equals(Pos_Carga)){//Caso ja esta com ZOOM
							Posicao=Pos_Inicial;
							GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [17] = 1;
							//GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [2] = 0;
						} else { //caso sem o ZOOM
							//print ("RESPEITE AS CONEXOES MOSTRADA NA CARGA! SOMENTE SERIE E PARELELO");
							//if (GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [2] != 2){
								//GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [18] = 1;
								GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [2] = 1;
								
							//}

							//print ("");
							Posicao=Pos_Carga;
							zoom_objeto=true;
						}// fim do else
					}// fim da carga
				}//fim do if do phisics
			}//Fim do try
			catch (Exception e) 
			{
			}// fim so catch
		}//fim do mouse
	}// fim do update
}// Fim da classe