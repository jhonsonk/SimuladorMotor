using UnityEngine;
using UnityEngine.UI;// usar o RawImage
using System.Collections;

public class Pratica_motor_shunt : MonoBehaviour {

	/* Esses objetos sao os bornes da cena */
	// Variador de tensao 1
	public GameObject B_DC_MAIS_1;     // 1
	public GameObject B_DC_MENOS_1;    // 2
	public GameObject B_AC1_1;         // 24
	public GameObject B_AC2_1;         // 25
	// Variador de tensao 2
	public GameObject B_DC_MAIS_2;     // 3
	public GameObject B_DC_MENOS_2;    // 4
	public GameObject B_AC1_2;         // 26
	public GameObject B_AC2_2;         // 27
	public GameObject B_24V_MAIS;      // 28
	public GameObject B_24V_MENOS;     // 29
	// Carga
	public GameObject B_CARGA_1;       // 18
	public GameObject B_CARGA_2;       // 19
	public GameObject B_CARGA_3;       // 20
	public GameObject B_CARGA_4;       // 21
	public GameObject B_CARGA_5;       // 22
	public GameObject B_CARGA_6;       // 23
	// Reostato
	public GameObject B_REO_1;         // 15
	public GameObject B_REO_2;         // 16
	public GameObject B_REO_3;         // 17
	// Motor
	public GameObject B_F1;            // 11
	public GameObject B_F2;            // 12
	public GameObject B_D1;            // 30
	public GameObject B_D2;            // 31
	public GameObject B_A1;            // 13
	public GameObject B_A2;            // 14
	public GameObject B_EXPLORATRIZ_1; // 32
	public GameObject B_EXPLORATRIZ_2; // 33
	// Medidores
	public GameObject B_5A_DC_MAIS;    // 9
	public GameObject B_5A_DC_MENOS;   // 10

	public GameObject B_5A_AC_MAIS;    // 34
	public GameObject B_5A_AC_MENOS;   // 35

	public GameObject B_1A_DC_MAIS;    // 7
	public GameObject B_1A_DC_MENOS;   // 8

	public GameObject B_1A_AC_MAIS;    // 36
	public GameObject B_1A_AC_MENOS;   // 37

	public GameObject B_250V_DC_MAIS;  // 5
	public GameObject B_250V_DC_MENOS; // 6

	public GameObject B_250V_AC_MAIS;  // 38
	public GameObject B_250V_AC_MENOS; // 39
	// Acionamento
	public GameObject B_R2;            // 40
	public GameObject B_S2;            // 41
	public GameObject B_T2;            // 42
	// Sassi
	public GameObject B_ENTRADA_R;     // 43
	public GameObject B_ENTRADA_S;     // 44
	public GameObject B_ENTRADA_T;     // 45
	public GameObject B_ENTRADA_N;     // 46
	public GameObject B_SAIDA_R;       // 47
	public GameObject B_SAIDA_S;       // 48
	public GameObject B_SAIDA_T;       // 49
	public GameObject B_SAIDA_N;       // 50
	public GameObject B_TERRA;         // 51

	/* Esse são objetos que iram fornecer informação */
	public GameObject VARIADOR_1;
	public GameObject VARIADOR_2;
	public GameObject REOSTATO;
	public GameObject CARGA_RESISTIVA;

//	public GameObject ACIONAMENTO_GERAL;

	/* Esse são objetos que iram ser modificados */
	public GameObject VOLTIMETRO_DC;     // OBJETO DO VOLTIMETRO QUE IRA SE MOVIMENTAR
	public GameObject AMPERIMETRO_DC_5A; // OBJETO DO AMPERIMETRO QUE IRA SE MOVIMENTAR
	public GameObject AMPERIMETRO_DC_1A; // OBJETO DO MILIAMPERIMETRO QUE IRA SE MOVIMENTAR
	public GameObject EIXO_MOTOR;        // OBEJTO QUE REALIZA A ROTACAO


	// VARIAVEIS DE CONTROLE DOS CABOS
	//private bool C_1_4   = false;
	private bool C_1_5   = false;
	private bool C_1_7   = false;
	private bool C_1_9   = false;
	private bool C_2_3   = false;
	private bool C_2_6   = false;
	private bool C_2_12  = false;
	private bool C_2_14  = false;
	//private bool C_3_6   = false;
	//private bool C_3_12  = false;
	//private bool C_3_14  = false;
	private bool C_4_6   = false;
	private bool C_4_12  = false;
	private bool C_4_14  = false;
	private bool C_5_7   = false;
	private bool C_5_9   = false;
	private bool C_6_12  = false;
	private bool C_6_14  = false;
	private bool C_7_9   = false;
	private bool C_8_15  = false;
	private bool C_8_16  = false;
	private bool C_8_17  = false;
	//private bool C_10_13 = false;
	private bool C_10_18 = false;
	private bool C_10_19 = false;
	private bool C_10_20 = false;
	private bool C_10_21 = false;
	private bool C_10_22 = false;
	private bool C_10_23 = false;
	private bool C_11_15 = false;
	private bool C_11_16 = false;
	private bool C_11_17 = false;
	private bool C_12_14 = false;
	private bool C_13_18 = false;
	private bool C_13_19 = false;
	private bool C_13_20 = false;
	private bool C_13_21 = false;
	private bool C_13_22 = false;
	private bool C_13_23 = false;
	private bool C_18_20 = false;
	private bool C_18_21 = false;
	private bool C_18_22 = false;
	private bool C_18_23 = false;
	private bool C_19_20 = false;
	private bool C_19_21 = false;
	private bool C_19_22 = false;
	private bool C_19_23 = false;
	private bool C_20_22 = false;
	private bool C_20_23 = false;
	private bool C_21_22 = false;
	private bool C_21_23 = false;

	//
	private int Conexao_1 = 0;
	private int Conexao_2 = 0;
	private int Tipo_Carga = 0; // 1 SERIE, 2 PARALELO, 3 INDIVIDUAL, 0 NAO HA CARGA
	private int Tipo_Reostato = 0; //0:ZERO, 1:CARGA MARCADA, 2:TOTAL
	private int valor_carga = 1; // recebe o valor da carga de acorda com a posicao da chave

	private bool volti_pos  = false; // caso que o voltimetro esteje conectado
	private bool amp_1A_pos = false; // caso que o 1A esteje conectado
	private bool amp_5A_pos = false; // caso que o 5A esteje conectado
	private bool fonte_pos  = false; // caso que algum caso esta conectado a fonte

	private int fonte_neg = 0; // 0=desligado 1= individual 2=serie
	private int volti_neg = 0; // 0=desligado 1= individual 2=serie
	private int motor_a2  = 0; // 0=desligado 1= individual 2=serie
	private int motor_f2  = 0; // 0=desligado 1= individual 2=serie

	private bool status_voltimetro     = false; //false = desligado, true = ligado
	private bool status_amperimetro_1a = false; //false = desligado, true = ligado
	private bool status_amperimetro_5a = false; //false = desligado, true = ligado
	private bool status_motor_campo    = false; //false = desligado, true = ligado
	private bool status_motor_armadura = false; //false = desligado, true = ligado

	public int[] mensagem = new int[30]; // 0 = não foi usado // 1 = ativo // 2 = usado e inativo

	// valores 
	public float corrente_1a = 0;
	public float corrente_5a = 0;
	public float tensao = 0;
	public float rotacao = 0;
	public float velocidade = 0;
	public float rfc = 1;
	public float rac = 1;

	// Constantes fixas
	private float resistencia_campo = 1;// ESSE VALOR DEVE SER METIDO NO MOTOR (RESISTENCIA DO CAMPO)
	private float resistencia_armadura = 1;// ESSE VALOR DEVE SER METIDO NO MOTOR (RESISTENCIA INTERNA DA BOBINA)
	private float torque = 0.2865f; // ESSE VALOR FOI PASSADO PELO PROFESSOR JUAN


	private GameObject cabo;// objeto do cabo para exibiçao

	// Use this for initialization
	void Start () {
		mensagem [5] = 2;
		mensagem [7] = 2;
		mensagem [9] = 2;
		mensagem [10] = 0;
		mensagem [17] = 1;

	}
	
	// Update is called once per frame
	void Update () {
		// VERIFICA O PAR DE CONEXAO
		if (Conexao_1 == 0) { //ESPERA A PRIMEIRA CONEXAO
			Conexao_1 = Conectar ();
		} else if (Conexao_2 == 0) {// APOS A PRIMEIRA CONEXAO ESPERA A SEGUNDA CONEXAO
			Conexao_2 = Conectar ();
		} else if (Conexao_1 != 0 && Conexao_2 != 0) {
			//Garante que vai preencher somente a diagonal superior da matriz
			if (Conexao_1 > Conexao_2) {
				int Temp = Conexao_1;
				Conexao_1 = Conexao_2;
				Conexao_2 = Temp;
			} // fim do if

			Exibir_Cabo (); // EXIBE o cabo
			Conexao_1 = 0;
			Conexao_2 = 0;
		}

		// verifica quais os cabos conectados
		Verificar_Cabos ();
		Verificar_Carga ();
		Verificar_Reostato ();
		Verificar_Fonte ();
		Verificar_Instrumentos ();
		Verificar_Motor ();
		Exibir_Mapa ();
		Calcular ();
		Acionar_Instrumentos ();
		Exibir_Relatorio ();
		// mensagens de erro e de notificaçoe

	}// fim do update

	void Exibir_Relatorio (){
		
		// [1] Conexão não permitida!
		// [2] Conecte as resistencias de forma individual, paralela ou serie
		// [3] Para conectar em serie as fonte, conecte o negativo do fonte 1 com o positivo da fonte 2
		// [4] Voltimetro conectado
		// [5] Voltimetro desconectado
		// [6] Amperimetro 1A conectado
		// [7] Amperimetro 1A desconectado
		// [8] Amperimetro 5A conectado
		// [9] Amperimetro 5A desconectado
		// [10] RAC Conectada de forma Individual
		// [11] RAC Conectada de forma Paralela
		// [12] RAC Conectada de forma Serie
		// [13] RFC Conectada com 1000 ohms
		// [14] RFC Conectada com valor
		// [15] Fonte Conectada - Serie / Individual
		// [16] Todos os equipamentos conectado
		// [17] Com o BOTÃO DIREITO clique sobre os objetos para aproximar ou afastar a camera
		// [18] Com o BOTÃO ESQUERDO clique em dois bornes para realizar a conexão entre eles // quando o sistema inicializar
		// [19] Clique com o BOTÃO ESQUERDO sobre o cabo para seleciona-lo  // quando exibir o primeiro cabo
		// [0] Aperte "DELETE" para deletar o cabo, ou "ESC" remover a seleção // quando o cabo for selecionado 

		//plugs

		if (mensagem [1] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Conexão não permitida!";
			mensagem [1] = 0;
		}
		if (mensagem [2] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Conecte as resistencias em serie, paralela ou individual";
			mensagem [2] = 2;
		}
		if (mensagem [3] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Para conectar as fonte em serie, conecte o NEGATIVO do fonte 1 com o POSITIVO da fonte 2";
			mensagem [3] = 0;
		}

		if (mensagem [4] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Voltimetro conectado";
			mensagem [4] = 2;
		}

		if (mensagem [5] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Voltimetro desconectado";
			mensagem [5] = 2;
		}

		if (mensagem [6] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Amperimetro 1A conectado";
			mensagem [6] = 2;
		}

		if (mensagem [7] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " Amperimetro 1A desconectado";
			mensagem [7] = 2;
		}

		if (mensagem [8] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Amperimetro 5A conectado";
			mensagem [8] = 2;
		}

		if (mensagem [9] == 1) {
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " Amperimetro 5A desconectado";
			mensagem [9] = 2;
		}

		if (Tipo_Carga == 3) {
			if (mensagem [10] == 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RAC Conectada - Individual";
				mensagem [10] = 2;
			}
		} else {
			if (mensagem [10] != 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RAC Desconectada";
			}
			mensagem [10] = 0;
		}// fim do else do tipo de carga 3 - individual

		if (Tipo_Carga == 2) {
			if (mensagem [11] == 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RAC Conectada - Parelalo";
				mensagem [11] = 2;
			}
		} else {
			if (mensagem [11] != 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RAC Desconectada";
				mensagem [11] = 0;
			}
		}// fim do else do tipo carga 2 - paralelo

		if (Tipo_Carga == 1) {
			if (mensagem [12] == 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RAC Conectada - Serie";
				mensagem [12] = 2;
			}
		} else {
			if (mensagem [12] != 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RAC Desconectada";
				mensagem [12] = 0;
			}
		}// fim do else do tipo carga 1 - serie
			
		if (Tipo_Reostato == 2) {
			if (mensagem [13] == 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RFC Conectada - 1000 Ohms";
				mensagem [13] = 2;
			}
		} else {
			if (mensagem [13] != 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RFC Desconectada";
				mensagem [13] = 0;
			}
		}// fim do else do tipo reostado - 1000ohms

		if (Tipo_Reostato == 1) {
			if (mensagem [14] == 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RFC Conectada - Valor ";
				mensagem [14] = 2;
			}
		} else {
			if (mensagem [14] != 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = " RFC Desconectada";
				mensagem [14] = 0;
			}
		}// fim do else do tipo reostado - 1000ohms

		// Mensagem sobre a fonte
		if (fonte_pos && fonte_neg == 1){
			if (mensagem[15]==0){
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Fonte Conectada - Individual";
				mensagem [15] = 2;
			}
		}

		if (fonte_pos && fonte_neg == 2){
			if (mensagem[15]==0){
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Fonte Conectada - Serie";
				mensagem [15] = 2;
			}
		}

		if (!fonte_pos || fonte_neg == 0){
			if (mensagem[15]==2){
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Fonte Desconectada";
				mensagem [15] = 0;
			}
		}

		// Todos os equipamentos conectados
		if (status_amperimetro_1a && status_amperimetro_5a && status_motor_armadura && status_motor_campo && status_voltimetro) {
			if (mensagem [16] == 0) {
				GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Todos Equipamentos Conectados";
				mensagem [16] = 2;
			}
		} else {
			mensagem [16] = 0;
		}

		//[17] Com o BOTÃO DIREITO clique sobre os objetos para aproximar ou afastar a camera
		if (mensagem[17]==1){
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Com o BOTÃO DIREITO clique sobre os objetos para aproximar ou afastar a camera";
			mensagem [17] = 2;
		}

		if (mensagem[18]==1){
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Com o BOTÃO ESQUERDO clique em dois bornes para realizar a conexão entre eles";
			mensagem [18] = 2;
		}

		if (mensagem[19]==1){
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Clique com o BOTÃO ESQUERDO sobre o cabo para seleciona-lo";
			mensagem [19] = 2;
			
		}

		if (mensagem[0]==1){
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Aperte DELETE para deletar o cabo, ou ESC remover a seleção";
			mensagem [0] = 2;

		}

		if (mensagem[0]==3){
			GameObject.FindGameObjectWithTag ("label").GetComponent<Text> ().text = "Cabo deletado com Sucesso";
			mensagem [0] = 2;

		}
		mensagem [20] = 1;
			

	} // fim da funcao que exibe os relatorios




	/* Funcao que aciona os instrumentos */
	void Acionar_Instrumentos (){
		// Status voltimetro
		if (status_voltimetro) {
			VOLTIMETRO_DC.GetComponent<Voltimetro> ().tensao = tensao;
			GameObject.FindGameObjectWithTag ("status_volt").GetComponent<Text> ().text = "Voltimetro: " + tensao + " V";
			if (mensagem [4] != 2){
				mensagem [4] = 1;
				mensagem [5] = 0;
			}
		} else {
			VOLTIMETRO_DC.GetComponent<Voltimetro> ().tensao = 0;
			GameObject.FindGameObjectWithTag ("status_volt").GetComponent<Text> ().text = "Voltimetro: " + 0 + " V";
			if(mensagem [5] !=2 ){
				mensagem [5] = 1;
				mensagem [4] = 0;
			}
		}

		// Amperimetro 1A
		if (status_amperimetro_1a) {
			AMPERIMETRO_DC_1A.GetComponent<Amperimetro> ().corrente = corrente_1a;
			GameObject.FindGameObjectWithTag ("status_1A").GetComponent<Text> ().text = "Amperimetro 1A: " + corrente_1a.ToString ("0.###") + " mA";
			if (mensagem [6] != 2){
				mensagem [6] = 1;
				mensagem [7] = 0;
			}

		} else {
			AMPERIMETRO_DC_1A.GetComponent<Amperimetro> ().corrente = corrente_1a;
			GameObject.FindGameObjectWithTag ("status_1A").GetComponent<Text> ().text = "Amperimetro 1A: " + 0 + " mA";
			if(mensagem [7] !=2 ){
				mensagem [7] = 1;
				mensagem [6] = 0;
			}
		}

		// Amperimetro 5A
		if (status_amperimetro_5a) {
			AMPERIMETRO_DC_5A.GetComponent<Amperimetro> ().corrente = corrente_5a;
			GameObject.FindGameObjectWithTag ("status_5A").GetComponent<Text>().text = "Amperimetro 5A: "+corrente_5a.ToString("0.###")+" A";
			if (mensagem [8] != 2){
				mensagem [8] = 1;
				mensagem [9] = 0;
			}

		} else {
			AMPERIMETRO_DC_5A.GetComponent<Amperimetro> ().corrente = 0;
			GameObject.FindGameObjectWithTag ("status_5A").GetComponent<Text>().text = "Amperimetro 5A: "+ 0 +" A";
			if (mensagem [9] != 2){
				mensagem [9] = 1;
				mensagem [8] = 0;
			}
		}
			
		// Velocidade
		if (status_amperimetro_1a && status_amperimetro_5a && tensao != 0 && corrente_1a != 0 && corrente_5a != 0) {
			EIXO_MOTOR.GetComponent<Transform> ().Rotate (0, 0, rotacao);
			GameObject.FindGameObjectWithTag ("status_velo").GetComponent<Text> ().text = "Velocidade: " + rotacao.ToString ("0.#") + " RPM";
		} else {
			EIXO_MOTOR.GetComponent<Transform> ().Rotate (0,0,0);
			GameObject.FindGameObjectWithTag ("status_velo").GetComponent<Text>().text = "Velocidade: "+ 0 +" RPM";
		}
		// RFC
		if (Tipo_Reostato != 0) {
			GameObject.FindGameObjectWithTag ("status_Rfc").GetComponent<Text> ().text = "RFC: " + rfc + " Ohms";
		} else {
			GameObject.FindGameObjectWithTag ("status_Rfc").GetComponent<Text> ().text = "RFC: " + 0 + " Ohms";		
		} 

		// RAC
		if (Tipo_Carga != 0) {
			GameObject.FindGameObjectWithTag ("status_Rac").GetComponent<Text> ().text = "RAC: " + rac + " Ohms";
		} else {
			GameObject.FindGameObjectWithTag ("status_Rac").GetComponent<Text> ().text = "RAC: " + 0 + " Ohms";		
		}
		
	}// fim da funcao que aciona os instrumentos

	/* Funcao que calcular a tensao, correntes e a rotacao */
	void Calcular (){
		
		// calcular rfc - utiliza o valor do reostato
		rfc = 1;
		if (Tipo_Reostato != 0) {
			if (Tipo_Reostato == 1) {
				rfc = REOSTATO.GetComponent<Variador_Reostato> ().Variador_Valor;		
			} else if (Tipo_Reostato == 2) {
				rfc = 1000;
			}// fim do else if caso 2
		}// fim do if rfc

		// Verifica qual a posicao da chave
		switch (CARGA_RESISTIVA.GetComponent<Chave_Seletora>().posicao) {
		case 0:
			valor_carga = 0;
			break;
		case 1:
			valor_carga = 180;
			break;
		case 2:
			valor_carga = 90;
			break;
		case 3:
			valor_carga = 60;
			break;
		case 4:
			valor_carga = 45;
			break;
		case 5:
			valor_carga = 36;
			break;
		}// fim do switch 

		// calcular rac - utiliza o valor da carga
		rac = 0;
		if (Tipo_Carga!=0){
			if (Tipo_Carga == 1) {
				rac = valor_carga*3;
				// caso individual
			} else if (Tipo_Carga==2) {
				rac = valor_carga / 3;
				// caso paralelo
			} else if (Tipo_Carga==3){
				// caso serie
				rac = valor_carga;
			}
		} // fim do carga

		// calcular a tensao
		tensao = 0;
		if (fonte_pos && fonte_neg!=0){
			if (fonte_neg == 1){
				tensao = VARIADOR_1.GetComponent<Variador_de_Tensao>().Variador_Valor;
			} else if (fonte_neg == 2){
				tensao = VARIADOR_1.GetComponent<Variador_de_Tensao>().Variador_Valor +
					VARIADOR_2.GetComponent<Variador_de_Tensao>().Variador_Valor;
			}
		}// calcular a tensao

		corrente_1a = 0;
		corrente_5a = 0;

		float wn_nominal = (1800 * 2 * Mathf.PI) / 60;
		float if_nominal = 180 / 180;
		float kf = 180 / (wn_nominal * if_nominal);
		float torque = (0.05f) * ((180 * 6) / wn_nominal);
		float corrente_if = tensao / (rfc+180);
		float wn = (tensao / (kf * corrente_if)) - ((resistencia_armadura  + rac)/(kf * corrente_if))*torque;
		float Ea = kf * corrente_if * wn;
		float corrente_ia = (tensao - Ea) / (resistencia_armadura + rac);
		float rpm = 0;
		float temp = (wn * 60) / (2*Mathf.PI);
		if (temp>0){
			rpm = temp;
		}



		print ("wn nominal "+wn_nominal);
		print ("if_nominal "+if_nominal);
		print ("kf "+kf);
		print ("torque "+torque);
		print ("if "+corrente_if);
		print ("wn "+wn);
		print ("Ea "+Ea);
		print ("ia "+corrente_ia);







		// calcular a corrente em 1A

		if (status_amperimetro_1a && rfc!=0 && status_motor_campo && tensao !=0){
			//print ("AMPERIMETRO 1A");
			corrente_1a = corrente_if;
			//print (corrente_1a);
		}

		// calcular a corrente em 5A

		if (status_amperimetro_5a && rac!=0 && status_motor_armadura && tensao !=0){
			//print ("AMPERIMETRO 5A");
			corrente_5a = corrente_ia;
			//print (corrente_5a);

		}


		// calcular a rotacao
		// (tensao / (resistencia_campo*corrente_1a)) - (resistencia_armadura+rac)
		rotacao = rpm;

	
	}// fim da funcao

	/* Funcao que exibe o mapa das coneccoes*/
	void Exibir_Mapa (){
		GameObject.FindGameObjectWithTag ("mapa-1").GetComponent<RawImage> ().enabled = false;
		GameObject.FindGameObjectWithTag ("mapa-2").GetComponent<RawImage> ().enabled = false;
		GameObject.FindGameObjectWithTag ("mapa-3").GetComponent<RawImage> ().enabled = false;
		GameObject.FindGameObjectWithTag ("mapa-4").GetComponent<RawImage> ().enabled = false;
		GameObject.FindGameObjectWithTag ("mapa-5").GetComponent<RawImage> ().enabled = false;
		GameObject.FindGameObjectWithTag ("mapa-6").GetComponent<RawImage> ().enabled = false;
		GameObject.FindGameObjectWithTag ("mapa-7").GetComponent<RawImage> ().enabled = false;
		GameObject.FindGameObjectWithTag ("mapa-8").GetComponent<RawImage> ().enabled = false;

		// fonte 1
		if (fonte_pos && fonte_neg!=0){
			GameObject.FindGameObjectWithTag ("mapa-1").GetComponent<RawImage> ().enabled = true;
		}
		// voltimetro 2
		if (status_voltimetro){
			GameObject.FindGameObjectWithTag ("mapa-2").GetComponent<RawImage> ().enabled = true;
		}
		// amperimetro 1A 3
		if (status_amperimetro_1a){
			GameObject.FindGameObjectWithTag ("mapa-3").GetComponent<RawImage> ().enabled = true;
		} 
		// amperimetro 5A 4
		if (status_amperimetro_5a){
			GameObject.FindGameObjectWithTag ("mapa-4").GetComponent<RawImage> ().enabled = true;
		}
		// armadura 5
		if (status_motor_armadura){
			GameObject.FindGameObjectWithTag ("mapa-5").GetComponent<RawImage> ().enabled = true;
		}
		// campo 6
		if (status_motor_campo){
			GameObject.FindGameObjectWithTag ("mapa-6").GetComponent<RawImage> ().enabled = true;
		}
		// Rfc 7
		if (Tipo_Reostato!=0){
			GameObject.FindGameObjectWithTag ("mapa-7").GetComponent<RawImage> ().enabled = true;
		}
		// Rac 8
		if (Tipo_Carga!=0){
			GameObject.FindGameObjectWithTag ("mapa-8").GetComponent<RawImage> ().enabled = true;
		}
		
	}// fim da funcao que exibe o mapa

	/* Funcao que verifica se o motor esta conectado*/
	void Verificar_Motor (){
		status_motor_campo = false;
		status_motor_armadura = false;

		if (motor_f2 !=0 && (C_11_15 || C_11_16 || C_11_17)){
			status_motor_campo = true;
		}

		if (motor_a2 !=0 && (C_13_18 || C_13_19 || C_13_20 || C_13_21 || C_13_22 || C_13_23)){
			status_motor_armadura = true;
		}
	}// fim da funcao motor


	/* Essa função verifica a conexao do voltimento e do dois amperimetros*/
	void Verificar_Instrumentos (){
		status_voltimetro = false;
		status_amperimetro_1a = false;
		status_amperimetro_5a = false;

		// verifica o voltimetro 
		if (volti_pos && volti_neg !=0){
			status_voltimetro = true;
		}
		// verifica o amperimetro de 1A
		if (amp_1A_pos && ((C_8_15 && !C_8_16 && !C_8_17) || (!C_8_15 && C_8_16 && !C_8_17) || (!C_8_15 && !C_8_16 && C_8_17))){
			status_amperimetro_1a = true;			
		}

		// verifica o amperimetro de 5A
		if (amp_5A_pos &&(C_10_18||C_10_19||C_10_20||C_10_21||C_10_22||C_10_23)){
			status_amperimetro_5a = true;			
		}
	}// fim da funcao dos instrumentos

	/* Funcao que verifica a conexao da fonte,
	 * ela também verifica a conexao no positivo dos amperimetros e voltimetro 
	 * e o negativo do voltimetro e do motor */
	void Verificar_Fonte (){
		// caso da fonte ligada no positivo
		if(C_1_5 || C_1_7 || C_1_9){
			volti_pos = false;
			amp_1A_pos = false;
			amp_5A_pos = false;
			fonte_pos = true;

			// ligado no voltimetro
			if(C_1_5){
				volti_pos = true;
				if (C_5_9){
					amp_5A_pos =true;
					if(C_7_9){
						amp_1A_pos = true;
					}
				}
				if (C_5_7){
					amp_1A_pos = true;
					if(C_7_9){
						amp_5A_pos = true;
					}
				}
			}// fim do if voltimetro

			// ligado no amperimetro de 1A
			if (C_1_7){
				amp_1A_pos = true;
				if (C_5_7){
					volti_pos = true;
					if(C_5_9){
						amp_5A_pos = true;
					}
				}
				if (C_7_9){
					amp_5A_pos = true;
					if(C_5_9){
						volti_pos = true;
					}
				}
			}// fim do if do 1A

			// ligado no amperimetro de 5A
			if(C_1_9){
				amp_5A_pos = true;
				if (C_5_9){
					volti_pos = true;
					if (C_5_7){
						amp_1A_pos = true;						
					}
				}
				if (C_7_9){
					amp_1A_pos = true;
					if (C_5_7){
						volti_pos = true;					
					}
				}
			}//fim do if 5A

		} else { // caso nao ha nenhuma conexao com o positivo da fonte
			fonte_pos = false;
			volti_pos = false;
			amp_1A_pos = false;
			amp_5A_pos = false;
		} // fim do else


		// caso da fonte ligada no negativo
		fonte_neg = 0;
		volti_neg = 0;
		motor_a2 = 0;
		motor_f2 = 0;

		if  (C_2_3){
			// caso esteje em serie
			if((C_4_6 || C_4_12 || C_4_14) && (!C_2_6 && !C_2_12 && !C_2_14)){
				fonte_neg = 2;
				if (C_4_6){
					volti_neg = 2;
					if (C_6_12){
						motor_f2 = 2;
						if(C_12_14){
							motor_a2 = 2;
						}
					}// fim if 
					if (C_6_14){
						motor_a2 = 2;
						if (C_12_14){
							motor_f2 = 2;
						}
					}// fim do if
				}// fim do if volimetro-fonte

				if (C_4_12){
					motor_f2 = 2;
					if (C_6_12){
						volti_neg = 2;
						if(C_6_14){
							motor_a2 = 2;
						}
					}// fim do if

					if (C_12_14){
						motor_a2 = 2;
						if (C_6_14){
							volti_neg = 2;
						}
					}// fim do if
				}// fim  do if da fonte motor f2

				if (C_4_14){
					motor_a2 = 2;
					if (C_6_14){
						volti_neg = 2;
						if (C_6_12){
							motor_f2 = 2;
						}
					}// fim do if

					if (C_12_14){
						motor_f2 = 2;
						if (C_6_12){
							volti_neg = 2;
						}
					}// fim do if 
				}// fim do if da fonte motor a2
			}// fim do if 4-6 || 4-12 || 4-14
				//...
		} else {
			// caso nao esteje em serie
			if((C_2_6 || C_2_12 || C_2_14) && (!C_4_6 && !C_4_12 && !C_4_14)){
				fonte_neg = 1;
				if (C_2_6){
					volti_neg = 1;
					if (C_6_12){
						motor_f2 = 1;
						if(C_12_14){
							motor_a2 = 1;
						}
					}// fim if 
					if (C_6_14){
						motor_a2 = 1;
						if (C_12_14){
							motor_f2 = 1;
						}
					}// fim do if
				}// fim do if volimetro-fonte

				if (C_2_12){
					motor_f2 = 1;
					if (C_6_12){
						volti_neg =1;
						if(C_6_14){
							motor_a2 =1;
						}
					}// fim do if

					if (C_12_14){
						motor_a2 = 1;
						if (C_6_14){
							volti_neg = 1;
						}
					}// fim do if
				}// fim  do if da fonte motor f2

				if (C_2_14){
					motor_a2 = 1;
					if (C_6_14){
						volti_neg = 1;
						if (C_6_12){
							motor_f2 = 1;
						}
					}// fim do if

					if (C_12_14){
						motor_f2 = 1;
						if (C_6_12){
							volti_neg = 1;
						}
					}// fim do if 
				}// fim do if da fonte motor a2
			}// fim do if 2-6 || 2-12 || 2-14
		}// fim do else
	}// fim da funcao que verifica a fonte

	// FUNCAO QUE VERIFICA QUAL A CONEXAO DO REOSTATO
	void Verificar_Reostato (){

		Tipo_Reostato = 0;

		if (C_8_15 == true && C_8_16 == false && C_8_17 == false &&
			C_11_15 == false && C_11_16 == true && C_11_17 == false){
			//print("MEIA");
			Tipo_Reostato = 1;
		}

		if (C_8_15 == false && C_8_16 == true && C_8_17 == false &&
			C_11_15 == true && C_11_16 == false && C_11_17 == false){
			//print("Meia");
			Tipo_Reostato = 1;
		}

		if (C_8_15 == false && C_8_16 == true && C_8_17 == false &&
			C_11_15 == false && C_11_16 == false && C_11_17 == true){
			//print("MEIA");
			Tipo_Reostato = 1;
		}

		if(C_8_15 == false && C_8_16 == false && C_8_17 == true &&
			C_11_15 == false && C_11_16 == true && C_11_17 == false){
			//print("MEIA");
			Tipo_Reostato = 1;
		}

		if (C_8_15 == true && C_8_16 == false && C_8_17 == false &&
			C_11_15 == false && C_11_16 == false && C_11_17 == true){
			//print("INTEIRA");
			Tipo_Reostato = 2;
		}

		if (C_8_15 == false && C_8_16 == false && C_8_17 == true &&
			C_11_15 == true && C_11_16 == false && C_11_17 == false){
			//print("INTEIRA");
			Tipo_Reostato = 2;
		}

	}// FIM DA FUNCAO

	/* FUNCAO QUE VERIFICA O CARGA RESISTIVA*/
	void Verificar_Carga (){

		Tipo_Carga = 0; //CASO NÃO HAJA CONEXAO

		// CASOS INDIVIDUAL
		if (C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false &&
		    C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
		    C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false) {

			// CASO INDIVIDUAL 1 BRAÇO
			if (C_10_18 == true && C_10_19 == false && C_10_20 == false && C_10_21 == false && C_10_22 == false && C_10_23 == false &&
			   C_13_18 == false && C_13_19 == true && C_13_20 == false && C_13_21 == false && C_13_22 == false && C_13_23 == false) {
				Tipo_Carga = 3;
				//print ("Individual");
			}
			// CASO INDIVIDUAL 1 BRAÇO
			if (C_10_18 == false && C_10_19 == true && C_10_20 == false && C_10_21 == false && C_10_22 == false && C_10_23 == false &&
			   C_13_18 == true && C_13_19 == false && C_13_20 == false && C_13_21 == false && C_13_22 == false && C_13_23 == false) {
				Tipo_Carga = 3;
				//print ("Individual");
			}
			// CASO INDIVIDUAL 2 BRAÇO
			if (C_10_18 == false && C_10_19 == false && C_10_20 == true && C_10_21 == false && C_10_22 == false && C_10_23 == false &&
			   C_13_18 == false && C_13_19 == false && C_13_20 == false && C_13_21 == true && C_13_22 == false && C_13_23 == false) {
				Tipo_Carga = 3;
				//print ("Individual");
			}
			// CASO INDIVIDUAL 2 BRAÇO
			if (C_10_18 == false && C_10_19 == false && C_10_20 == false && C_10_21 == true && C_10_22 == false && C_10_23 == false &&
			   C_13_18 == false && C_13_19 == false && C_13_20 == true && C_13_21 == false && C_13_22 == false && C_13_23 == false) {
				Tipo_Carga = 3;
				//print ("Individual");
			}
			// CASO INDIVIDUAL 3 BRAÇO
			if (C_10_18 == false && C_10_19 == false && C_10_20 == false && C_10_21 == false && C_10_22 == true && C_10_23 == false &&
			   C_13_18 == false && C_13_19 == false && C_13_20 == false && C_13_21 == false && C_13_22 == false && C_13_23 == true) {
				Tipo_Carga = 3;
				//print ("Individual");
			}
			// CASO INDIVIDUAL 3 BRAÇO	
			if (C_10_18 == false && C_10_19 == false && C_10_20 == false && C_10_21 == false && C_10_22 == false && C_10_23 == true &&
			   C_13_18 == false && C_13_19 == false && C_13_20 == false && C_13_21 == false && C_13_22 == true && C_13_23 == false) {
				Tipo_Carga = 3;
				//print ("Individual");
			}
		}// fim so caso individual, colocar aqui o casos de paralelo e serie
		// FIM DO CASO INDIVIDUAL

		// CASOS PARALELOS
		// 18-20-22 && 19-21-23
		if (((C_18_20 == true && C_20_22 == true) || (C_18_20 == true && C_18_22 == true) || (C_18_22 == true && C_20_22 == true)) && 
			((C_19_21 == true && C_21_23 == true) || (C_19_21 == true && C_19_23 == true) || (C_19_23 == true && C_21_23 == true)) && 
			(C_18_21 == false && C_18_23 == false && C_19_20 == false && C_19_22 == false && C_20_23 == false && C_21_22 == false)){

			if (((C_10_18 == true || C_10_20 == true || C_10_22 == true) && (C_10_19 == false && C_10_21 == false && C_10_23 == false) && 
				 (C_13_19 == true || C_13_21 == true || C_13_23 == true) && (C_13_18 == false && C_13_20 == false && C_13_22 == false)) ||
				((C_13_18 == true || C_13_20 == true || C_13_22 == true) && (C_13_19 == false && C_13_21 == false && C_13_23 == false) && 
				 (C_10_19 == true || C_10_21 == true || C_10_23 == true) && (C_10_18 == false && C_10_20 == false && C_10_22 == false))) {
				Tipo_Carga = 2;

				//print ("PARALELO 1");

			} else {
				print("PARALELO 1 AINDA FALTA CONECTAR O MOTOR");
			}// fim do else
		}

		// 18-20-23 && 19-21-22
		if (((C_18_20 == true && C_20_23 == true) || (C_18_20 == true && C_18_23 == true) || (C_18_23 == true && C_20_23 == true)) && 
			((C_19_21 == true && C_21_22 == true) || (C_19_21 == true && C_19_22 == true) || (C_19_22 == true && C_21_22 == true)) && 
			(C_18_21 == false && C_18_22 == false && C_19_20 == false && C_19_23 == false && C_20_22 == false && C_21_23 == false)){

			if (((C_10_18 == true || C_10_20 == true || C_10_23 == true) && (C_10_19 == false && C_10_21 == false && C_10_22 == false) && 
				 (C_13_19 == true || C_13_21 == true || C_13_22 == true) && (C_13_18 == false && C_13_20 == false && C_13_23 == false)) ||
				((C_13_18 == true || C_13_20 == true || C_13_23 == true) && (C_13_19 == false && C_13_21 == false && C_13_22 == false) && 
				 (C_10_19 == true || C_10_21 == true || C_10_22 == true) && (C_10_18 == false && C_10_20 == false && C_10_23 == false))) {
				Tipo_Carga = 2;

				//print ("PARALELO 2");

			} else {
				print("PARALELO 2 AINDA FALTA CONECTAR O MOTOR");
			}// fim do else
		} // fim do if caso 18-20-23 && 19-21-22

		//-- 18-21-23 && 19-20-22
		if (((C_18_21 == true && C_21_23 == true) || (C_18_21 == true && C_18_23 == true) || (C_18_23 == true && C_21_23 == true)) &&
		    ((C_19_20 == true && C_20_22 == true) || (C_19_20 == true && C_19_22 == true) || (C_19_22 == true && C_20_22 == true)) &&
		    (C_18_20 == false && C_18_22 == false && C_19_21 == false && C_19_23 == false && C_20_23 == false && C_21_22 == false)) {

			if (((C_10_18 == true || C_10_21 == true || C_10_23 == true) && (C_10_19 == false && C_10_20 == false && C_10_22 == false) && 
				 (C_13_19 == true || C_13_20 == true || C_13_22 == true) && (C_13_18 == false && C_13_21 == false && C_13_23 == false)) ||
				((C_13_18 == true || C_13_21 == true || C_13_23 == true) && (C_13_19 == false && C_13_20 == false && C_13_22 == false) && 
				 (C_10_19 == true || C_10_20 == true || C_10_22 == true) && (C_10_18 == false && C_10_21 == false && C_10_23 == false))) {
				Tipo_Carga = 2;

				//print("PARALELO 3");

			} else {
				print("PARALELO 3 AINDA NAO CONECTADO AO MOTOR");
			} // fim do else
		} // fim do if caso 18-21-23 && 19-20-22

		//-- 18-21-22 && 19-20-23
		if (((C_18_21 == true && C_21_22 == true) || (C_18_21 == true && C_18_22 == true) || (C_18_22 == true && C_21_22 == true)) &&
			((C_19_20 == true && C_20_23 == true) || (C_19_20 == true && C_19_23 == true) || (C_19_23 == true && C_20_23 == true)) &&
			(C_18_20 == false && C_18_23 == false && C_19_21 == false && C_19_22 == false && C_20_22 == false && C_21_23 == false)){

			if (((C_10_18 == true || C_10_21 == true || C_10_22 == true) && (C_10_19 == false && C_10_20 == false && C_10_23 == false) &&
			     (C_13_19 == true || C_13_20 == true || C_13_23 == true) && (C_13_18 == false && C_13_21 == false && C_13_22 == false)) ||
			    ((C_13_18 == true || C_13_21 == true || C_13_22 == true) && (C_13_19 == false && C_13_20 == false && C_13_23 == false) &&
			     (C_10_19 == true || C_10_20 == true || C_10_23 == true) && (C_10_18 == false && C_10_21 == false && C_10_22 == false))) {
				Tipo_Carga = 2;

				//print("PARALELO 4");

			} else {
				print("PARALELO 4 AINDA NAO CONECTADO AO MOTOR");			
			}// fim do else
		}// fim do if 18-21-22 && 19-20-23
		// FIM DO CASO PARALELO

		// CASO EM SERIE
		//CASO 18
		if(C_10_18 == true || C_13_18 == true){
			if (((C_10_18 == true && C_10_20 == false && C_13_18 == false && C_13_20 == true)||
				(C_10_18 == false && C_10_20 == true && C_13_18 == true && C_13_20 == false)) &&
				(C_10_19 == false && C_10_21 == false && C_10_22 == false && C_10_23 == false && 
				C_13_19 == false && C_13_21 == false && C_13_22 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == true && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == true)){
					//-19-22 21-23 [18-20]
					Tipo_Carga = 1;
					//print ("SERIE");

				}// fim do if
				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == true &&
					C_20_22 == false && C_20_23 == false && C_21_22 == true && C_21_23 == false)){
					//-19-23 21-22 [18-20]
					Tipo_Carga = 1;
					//print ("SERIE");
				}// fim do if
			} // fim do if 18-20

			if (((C_10_18 == true && C_10_21 == false && C_13_18 == false && C_13_21 == true)||
				(C_10_18 == false && C_10_21 == true && C_13_18 == true && C_13_21 == false)) &&
				(C_10_19 == false && C_10_20 == false && C_10_22 == false && C_10_23 == false && 
				C_13_19 == false && C_13_20 == false && C_13_22 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == true &&
					C_20_22 == true && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					//-19-23 20-22 [18-21]
					Tipo_Carga = 1;
					//print ("SERIE");

				}// fim do if
				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == true && C_19_23 == false &&
					C_20_22 == false && C_20_23 == true && C_21_22 == false && C_21_23 == false)){
					//-19-22 20-23 [18-21]
					Tipo_Carga = 1;
					print ("SERIE");

				}// fim do if
			}// fim do if 18-21

			if (((C_10_18 == true && C_10_22 == false && C_13_18 == false && C_13_22 == true)||
				(C_10_18 == false && C_10_22 == true && C_13_18 == true && C_13_22 == false)) &&
				(C_10_19 == false && C_10_20 == false && C_10_21 == false && C_10_23 == false && 
					C_13_19 == false && C_13_20 == false && C_13_21 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == true && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == true)){
					//-19-20 21-23 [18-22]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == true && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == true && C_21_22 == false && C_21_23 == false)){
					//-19-21 20-23 [18-22]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
			}// fim do if 18-22

			if (((C_10_18 == true && C_10_23 == false && C_13_18 == false && C_13_23 == true)||
				(C_10_18 == false && C_10_23 == true && C_13_18 == true && C_13_23 == false)) &&
				(C_10_19 == false && C_10_20 == false && C_10_21 == false && C_10_22 == false && 
					C_13_19 == false && C_13_20 == false && C_13_21 == false && C_13_22 == false)){

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == true && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == true && C_21_23 == false)){
					//-19-20 21-22 [18-23]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == true && C_19_22 == false && C_19_23 == false &&
					C_20_22 == true && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					//-19-21 20-22 [18-23]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
			}// fim do if 18-23
		}// CASO 18

		// CASO 19
		if(C_10_19 == true || C_13_19 == true){
			if (((C_10_19 == true && C_10_20 == false && C_13_19 == false && C_13_20 == true)||
				(C_10_19 == false && C_10_20 == true && C_13_19 == true && C_13_20 == false)) &&
				(C_10_18 == false && C_10_21 == false && C_10_22 == false && C_10_23 == false && 
					C_13_18 == false && C_13_21 == false && C_13_22 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == true && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == true && C_21_23 == false)){
					// 18-23 21-22 [19-20]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
				if ((C_18_20 == false && C_18_21 == false && C_18_22 == true && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == true)){
					// 18-22 21-23 [19-20]
					Tipo_Carga = 1;
					//print ("SERIE");

				}			
			}// fim do if 19-20

			if (((C_10_19 == true && C_10_21 == false && C_13_19 == false && C_13_21 == true)||
				(C_10_19 == false && C_10_21 == true && C_13_19 == true && C_13_21 == false)) &&
				(C_10_18 == false && C_10_20 == false && C_10_22 == false && C_10_23 == false && 
					C_13_18 == false && C_13_20 == false && C_13_22 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == true && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == true && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					// 18-23 20-22 [19-21]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
				if ((C_18_20 == false && C_18_21 == false && C_18_22 == true && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == true && C_21_22 == false && C_21_23 == false)){
					// 18-22 20-23 [19-21]
					Tipo_Carga = 1;
					//print ("SERIE");
				}		 
			}// fim do if 19-21

			if (((C_10_19 == true && C_10_22 == false && C_13_19 == false && C_13_22 == true)||
				(C_10_19 == false && C_10_22 == true && C_13_19 == true && C_13_22 == false)) &&
				(C_10_18 == false && C_10_20 == false && C_10_21 == false && C_10_23 == false && 
					C_13_18 == false && C_13_20 == false && C_13_21 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == true && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == true && C_21_22 == false && C_21_23 == false)){
					// 18-21 20-23 [19-22]
					Tipo_Carga = 1;
					//print ("SERIE");

				}

				if ((C_18_20 == true && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == true)){
					// 18-20 21-23 [19-22]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
			}// fim do if 19-22

			if (((C_10_19 == true && C_10_23 == false && C_13_19 == false && C_13_23 == true)||
				(C_10_19 == false && C_10_23 == true && C_13_19 == true && C_13_23 == false)) &&
				(C_10_18 == false && C_10_20 == false && C_10_21 == false && C_10_22 == false && 
					C_13_18 == false && C_13_20 == false && C_13_21 == false && C_13_22 == false)){

				if ((C_18_20 == false && C_18_21 == true && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == true && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					// 18-21 20-22 [19-23]
					Tipo_Carga = 1;
					//print ("SERIE");

				}

				if ((C_18_20 == true && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == true && C_21_23 == false)){
					// 18-20 21-22 [19-23]
					Tipo_Carga = 1;
					//print ("SERIE");
				}
			}// fim do if 19-23
		}// CASO 19

		// CASO 20
		if(C_10_20 == true || C_13_20 == true){
			if (((C_10_20 == true && C_10_22 == false && C_13_20 == false && C_13_22 == true)||
				(C_10_20 == false && C_10_22 == true && C_13_20 == true && C_13_22 == false)) &&
				(C_10_18 == false && C_10_19 == false && C_10_21 == false && C_10_23 == false && 
					C_13_18 == false && C_13_19 == false && C_13_21 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == true && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == true &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					//18-21 19-23 [20-22]
					Tipo_Carga = 1;
					//print ("SERIE");

				}

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == true && 
					C_19_20 == false && C_19_21 == true && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					//18-23 19-21 [20-22]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
			}// fim do if 20-22

			if (((C_10_20 == true && C_10_23 == false && C_13_20 == false && C_13_23 == true)||
				(C_10_20 == false && C_10_23 == true && C_13_20 == true && C_13_23 == false)) &&
				(C_10_18 == false && C_10_19 == false && C_10_21 == false && C_10_22 == false && 
					C_13_18 == false && C_13_19 == false && C_13_21 == false && C_13_22 == false)){

				if ((C_18_20 == false && C_18_21 == true && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == true && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					//18-21 19-22 [20-23]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
				if ((C_18_20 == false && C_18_21 == false && C_18_22 == true && C_18_23 == false && 
					C_19_20 == false && C_19_21 == true && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					//18-22 19-21 [20-23]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
			}// fim do if 20-23
		}// CASO 20

		// CASO 21
		if(C_10_21 == true || C_13_21 == true){
			if (((C_10_21 == true && C_10_22 == false && C_13_21 == false && C_13_22 == true)||
				(C_10_21 == false && C_10_22 == true && C_13_21 == true && C_13_22 == false)) &&
				(C_10_18 == false && C_10_19 == false && C_10_20 == false && C_10_23 == false && 
					C_13_18 == false && C_13_19 == false && C_13_20 == false && C_13_23 == false)){

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == false && C_18_23 == true && 
					C_19_20 == true && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					// 18-23 19-20 [21-22]
					Tipo_Carga = 1;
					//print ("SERIE");

				}

				if ((C_18_20 == true && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == false && C_19_23 == true &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					// 18-20 19-23 [21-22]
					Tipo_Carga = 1;
					//print ("SERIE");
				}
			}// fim do if 21-22

			if (((C_10_21 == true && C_10_23 == false && C_13_21 == false && C_13_23 == true)||
				(C_10_21 == false && C_10_23 == true && C_13_21 == true && C_13_23 == false)) &&
				(C_10_18 == false && C_10_19 == false && C_10_20 == false && C_10_22 == false && 
					C_13_18 == false && C_13_19 == false && C_13_20 == false && C_13_22 == false)){

				if ((C_18_20 == true && C_18_21 == false && C_18_22 == false && C_18_23 == false && 
					C_19_20 == false && C_19_21 == false && C_19_22 == true && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					// 18-20 19-22 [21-23]
					Tipo_Carga = 1;
					//print ("SERIE");

				}

				if ((C_18_20 == false && C_18_21 == false && C_18_22 == true && C_18_23 == false && 
					C_19_20 == true && C_19_21 == false && C_19_22 == false && C_19_23 == false &&
					C_20_22 == false && C_20_23 == false && C_21_22 == false && C_21_23 == false)){
					// 18-22 19-20 [21-23]
					Tipo_Carga = 1;
					//print ("SERIE");

				}
			}// fim do if 21-23
		}// CASO 21
		// fim do caso SERIE 
	}// fim da funcao Verifica_Carga

	/* FUNCAO QUE VERIFICA QUAIS SÃO OS CABOS ESTÃO NA CENA*/
	void Verificar_Cabos (){
		/* ESSA TRECHO VERIFICA SE ESTA SENDO EXIBIDO O CABO */ 
		//C_1_4 = GameObject.FindGameObjectWithTag ("1:4").GetComponent<Cabos> ().Hide_Show;
		C_1_5  = GameObject.FindGameObjectWithTag("1:5").GetComponent<Cabos> ().Hide_Show;
		C_1_7  = GameObject.FindGameObjectWithTag("1:7").GetComponent<Cabos> ().Hide_Show;
		C_1_9  = GameObject.FindGameObjectWithTag("1:9").GetComponent<Cabos> ().Hide_Show;
		C_2_3  = GameObject.FindGameObjectWithTag("2:3").GetComponent<Cabos> ().Hide_Show;
		C_2_6  = GameObject.FindGameObjectWithTag("2:6").GetComponent<Cabos> ().Hide_Show;
		C_2_12 = GameObject.FindGameObjectWithTag("2:12").GetComponent<Cabos> ().Hide_Show;
		C_2_14 = GameObject.FindGameObjectWithTag("2:14").GetComponent<Cabos> ().Hide_Show;
		//C_3_6  = GameObject.FindGameObjectWithTag("3:6").GetComponent<Cabos> ().Hide_Show;
		//C_3_12 = GameObject.FindGameObjectWithTag("3:12").GetComponent<Cabos> ().Hide_Show;
		//C_3_14 = GameObject.FindGameObjectWithTag("3:14").GetComponent<Cabos> ().Hide_Show;
		C_4_6  = GameObject.FindGameObjectWithTag("4:6").GetComponent<Cabos> ().Hide_Show;
		C_4_12 = GameObject.FindGameObjectWithTag("4:12").GetComponent<Cabos> ().Hide_Show;
		C_4_14 = GameObject.FindGameObjectWithTag("4:14").GetComponent<Cabos> ().Hide_Show;
		C_5_7  = GameObject.FindGameObjectWithTag("5:7").GetComponent<Cabos> ().Hide_Show;
		C_5_9  = GameObject.FindGameObjectWithTag("5:9").GetComponent<Cabos> ().Hide_Show;
		C_6_12 = GameObject.FindGameObjectWithTag("6:12").GetComponent<Cabos> ().Hide_Show;
		C_6_14 = GameObject.FindGameObjectWithTag("6:14").GetComponent<Cabos> ().Hide_Show;
		C_7_9  = GameObject.FindGameObjectWithTag("7:9").GetComponent<Cabos> ().Hide_Show;
		C_8_15 = GameObject.FindGameObjectWithTag("8:15").GetComponent<Cabos> ().Hide_Show;
		C_8_16 = GameObject.FindGameObjectWithTag("8:16").GetComponent<Cabos> ().Hide_Show;
		C_8_17 = GameObject.FindGameObjectWithTag("8:17").GetComponent<Cabos> ().Hide_Show;
		//C_10_13 = GameObject.FindGameObjectWithTag("10:13").GetComponent<Cabos> ().Hide_Show;
		C_10_18 = GameObject.FindGameObjectWithTag("10:18").GetComponent<Cabos> ().Hide_Show;
		C_10_19 = GameObject.FindGameObjectWithTag("10:19").GetComponent<Cabos> ().Hide_Show;
		C_10_20 = GameObject.FindGameObjectWithTag("10:20").GetComponent<Cabos> ().Hide_Show;
		C_10_21 = GameObject.FindGameObjectWithTag("10:21").GetComponent<Cabos> ().Hide_Show;
		C_10_22 = GameObject.FindGameObjectWithTag("10:22").GetComponent<Cabos> ().Hide_Show;
		C_10_23 = GameObject.FindGameObjectWithTag("10:23").GetComponent<Cabos> ().Hide_Show;
		C_11_15 = GameObject.FindGameObjectWithTag("11:15").GetComponent<Cabos> ().Hide_Show;
		C_11_16 = GameObject.FindGameObjectWithTag("11:16").GetComponent<Cabos> ().Hide_Show;
		C_11_17 = GameObject.FindGameObjectWithTag("11:17").GetComponent<Cabos> ().Hide_Show;
		C_12_14 = GameObject.FindGameObjectWithTag("12:14").GetComponent<Cabos> ().Hide_Show;
		C_13_18 = GameObject.FindGameObjectWithTag("13:18").GetComponent<Cabos> ().Hide_Show;
		C_13_19 = GameObject.FindGameObjectWithTag("13:19").GetComponent<Cabos> ().Hide_Show;
		C_13_20 = GameObject.FindGameObjectWithTag("13:20").GetComponent<Cabos> ().Hide_Show;
		C_13_21 = GameObject.FindGameObjectWithTag("13:21").GetComponent<Cabos> ().Hide_Show;
		C_13_22 = GameObject.FindGameObjectWithTag("13:22").GetComponent<Cabos> ().Hide_Show;
		C_13_23 = GameObject.FindGameObjectWithTag("13:23").GetComponent<Cabos> ().Hide_Show;
		C_18_20 = GameObject.FindGameObjectWithTag("18:20").GetComponent<Cabos> ().Hide_Show;
		C_18_21 = GameObject.FindGameObjectWithTag("18:21").GetComponent<Cabos> ().Hide_Show;
		C_18_22 = GameObject.FindGameObjectWithTag("18:22").GetComponent<Cabos> ().Hide_Show;
		C_18_23 = GameObject.FindGameObjectWithTag("18:23").GetComponent<Cabos> ().Hide_Show;
		C_19_20 = GameObject.FindGameObjectWithTag("19:20").GetComponent<Cabos> ().Hide_Show;
		C_19_21 = GameObject.FindGameObjectWithTag("19:21").GetComponent<Cabos> ().Hide_Show;
		C_19_22 = GameObject.FindGameObjectWithTag("19:22").GetComponent<Cabos> ().Hide_Show;
		C_19_23 = GameObject.FindGameObjectWithTag("19:23").GetComponent<Cabos> ().Hide_Show;
		C_20_22 = GameObject.FindGameObjectWithTag("20:22").GetComponent<Cabos> ().Hide_Show;
		C_20_23 = GameObject.FindGameObjectWithTag("20:23").GetComponent<Cabos> ().Hide_Show;
		C_21_22 = GameObject.FindGameObjectWithTag("21:22").GetComponent<Cabos> ().Hide_Show;
		C_21_23 = GameObject.FindGameObjectWithTag("21:23").GetComponent<Cabos> ().Hide_Show;
		// FIM DO TRECHO
	} // fim do funcao que revifica os cabos

	// VOU EXIBIR O CABO NESSA FUNCAO, A IDEIA ERA SEMELHANTE ENTAO APROVEITA CODIGO
	// ESSA FUNCAO VERIFICA AS CONEXOES
	void Exibir_Cabo(){
		// REVIFICACAO DAS CONECÇOES
		switch (Conexao_1){
		// Variador 1
		case(1):
			switch(Conexao_2){
			case (4): // ligando  as fontes em serie!!
				//cabo = GameObject.FindGameObjectWithTag("1:4");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=4;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;
			case(5):
				cabo = GameObject.FindGameObjectWithTag("1:5");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=5;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 5
			case(7):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("1:7");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=7;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 7
			case(9):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("1:9");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=9;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 9
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 1

		case(2):
			switch (Conexao_2){
			case(3):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:3");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=3;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 3
			case(6):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:6");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=6;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 6
			case(12):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:12");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 12
			case(14):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 14
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}//  FIM DO SWTCH 2
			break;// FIM DO CASE 2

		case(3):	
			switch (Conexao_2){
			case(6):
				//EXIBE CABO
				//cabo = GameObject.FindGameObjectWithTag("3:6");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=3;
				//cabo.GetComponent<Cabos>().Conexao_2=6;
				// REMOVE O REALCE DO BORNE
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				Desativar_Realce();
				break;
			case(12):
				//EXIBE CABO
				//cabo = GameObject.FindGameObjectWithTag("3:12");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=3;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				Desativar_Realce();

				break;
			case (14):
				//EXIBE CABO
				//cabo = GameObject.FindGameObjectWithTag("3:14");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=3;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 3

		case(4):
			switch (Conexao_2){
			case(6):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("4:6");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=4;
				//cabo.GetComponent<Cabos>().Conexao_2=6;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;
			case(12):				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("4:12");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=4;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;
			case(14):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("4:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=4;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}//FIM DO SWITCH 2
			break;// FIM DO CASE 4

			//Voltimentro 
		case(5):
			switch(Conexao_2){
			case(7):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("5:7");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=5;
				//cabo.GetComponent<Cabos>().Conexao_2=7;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 7
			case(9):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("5:9");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=5;
				//cabo.GetComponent<Cabos>().Conexao_2=9;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 9
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 5

		case(6):
			switch (Conexao_2){
			case(12):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("6:12");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=6;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;
			case (14):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("6:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=6;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 6

			// Amperimetro 1A 
		case(7):
			switch(Conexao_2){
			case(9):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("7:9");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=7;
				//cabo.GetComponent<Cabos>().Conexao_2=9;
				// REMOVE O REALCE DO BORNE
				Desativar_Realce();
				break;// FIM DO CASE 9
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 7

		case(8):
			switch(Conexao_2){
			case(15):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("8:15");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=8;
				//cabo.GetComponent<Cabos>().Conexao_2=15;
				Desativar_Realce();
				break;
			case(16):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("8:16");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=8;
				//cabo.GetComponent<Cabos>().Conexao_2=16;
				Desativar_Realce();
				break;
			case(17):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("8:17");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=8;
				//cabo.GetComponent<Cabos>().Conexao_2=17;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 8

		case(10):
			switch(Conexao_2){
			case(13):// AMPERIMETRO DIRETO NO MOTOR
				//EXIBE CABO
				//cabo = GameObject.FindGameObjectWithTag("10:13");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=13;
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				Desativar_Realce();
				break;
			case(18):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:18");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=18;
				Desativar_Realce();
				break;
			case(19):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:19");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=19;
				Desativar_Realce();
				break;
			case(20):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativar_Realce();
				break;
			case(21):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativar_Realce();
				break;
			case(22):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativar_Realce();
				break;
			case(23):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 10

		case(11):
			switch(Conexao_2){
			case(15):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("11:15");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=11;
				//cabo.GetComponent<Cabos>().Conexao_2=15;
				Desativar_Realce();
				break;
			case(16):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("11:16");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=11;
				//cabo.GetComponent<Cabos>().Conexao_2=16;
				Desativar_Realce();
				break;
			case(17):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("11:17");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=11;
				//cabo.GetComponent<Cabos>().Conexao_2=17;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 11

		case(12):
			switch (Conexao_2){
			case (14):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("12:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=12;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH
			break;// FIM DO CASE 12

		case(13):
			switch(Conexao_2){
			case(18):
				cabo = GameObject.FindGameObjectWithTag("13:18");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=18;
				Desativar_Realce();
				break;
			case(19):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:19");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=19;
				Desativar_Realce();
				break;
			case(20):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativar_Realce();
				break;
			case(21):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativar_Realce();
				break;
			case(22):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativar_Realce();
				break;
			case(23):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 13

		case(18):
			switch(Conexao_2){
			case(20):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativar_Realce();
				break;
			case(21):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativar_Realce();
				break;
			case(22):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativar_Realce();
				break;
			case(23):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 18

		case(19):
			switch(Conexao_2){
			case(20):
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("19:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativar_Realce();
				break;
			case(21):
				cabo = GameObject.FindGameObjectWithTag("19:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativar_Realce();
				break;
			case(22):
				cabo = GameObject.FindGameObjectWithTag("19:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativar_Realce();
				break;
			case(23):
				cabo = GameObject.FindGameObjectWithTag("19:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 19

		case(20):
			switch(Conexao_2){
			case(22):
				cabo = GameObject.FindGameObjectWithTag("20:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=20;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativar_Realce();
				break;
			case(23):
				cabo = GameObject.FindGameObjectWithTag("20:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=20;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 20

		case(21):
			switch(Conexao_2){
			case(22):
				cabo = GameObject.FindGameObjectWithTag("21:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=21;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativar_Realce();
				break;
			case(23):
				cabo = GameObject.FindGameObjectWithTag("21:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=21;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativar_Realce();
				break;
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 21

		case(22):
			switch(Conexao_2){
			default:
				print ("NAO EH POSSIVEL");
				mensagem [1] = 1;
				break;
			}
			break; // FIM DO CASE 22
		default:
			print ("NAO EH POSSIVEL");
			mensagem [1] = 1;
			break;
		}// FIM DO SWITCH 1
		//print ("NAO EH possivel");

		Desativar_Realce();
	}// FIM DA FUNCAO MONTAR MATRIZ

	/* FUNCAO QUE RETORNA O BORNE SELECIONADO PARA SER VIRIFICADO A CONEXAO*/
	int Conectar(){

		if (B_DC_MAIS_1.GetComponent<Borne> ().clique == true) {
			B_DC_MAIS_1.GetComponent<Borne> ().realce = true;// realçar pois foi selecionado
			B_DC_MAIS_1.GetComponent<Borne> ().clique = false;// retorna a variavel do borne para false
			return 1;// numero do borne corresponte

		} else if (B_DC_MENOS_1.GetComponent<Borne> ().clique == true) {
			B_DC_MENOS_1.GetComponent<Borne> ().clique = false;
			B_DC_MENOS_1.GetComponent<Borne> ().realce = true;
			return 2;

		} else if (B_AC1_1.GetComponent<Borne> ().clique == true) {
			B_AC1_1.GetComponent<Borne> ().clique = false;
			B_AC1_1.GetComponent<Borne> ().realce = true;
			return 24;

		} else if (B_AC2_1.GetComponent<Borne> ().clique == true) {
			B_AC2_1.GetComponent<Borne> ().clique = false;
			B_AC2_1.GetComponent<Borne> ().realce = true;
			return 25;

		} else if (B_DC_MAIS_2.GetComponent<Borne> ().clique == true) {
			B_DC_MAIS_2.GetComponent<Borne> ().clique = false;
			B_DC_MAIS_2.GetComponent<Borne> ().realce = true;
			return 3;

		} else if (B_DC_MENOS_2.GetComponent<Borne> ().clique == true) {
			B_DC_MENOS_2.GetComponent<Borne> ().clique = false;
			B_DC_MENOS_2.GetComponent<Borne> ().realce = true;
			return 4;

		} else if (B_AC1_2.GetComponent<Borne> ().clique == true) {
			B_AC1_2.GetComponent<Borne> ().clique = false;
			B_AC1_2.GetComponent<Borne> ().realce = true;
			return 26;

		} else if (B_AC2_2.GetComponent<Borne> ().clique == true) {
			B_AC2_2.GetComponent<Borne> ().clique = false;
			B_AC2_2.GetComponent<Borne> ().realce = true;
			return 27;

		} else if (B_24V_MAIS.GetComponent<Borne> ().clique == true) {
			B_24V_MAIS.GetComponent<Borne> ().clique = false;
			B_24V_MAIS.GetComponent<Borne> ().realce = true;
			return 28;

		} else if (B_24V_MENOS.GetComponent<Borne> ().clique == true) {
			B_24V_MENOS.GetComponent<Borne> ().clique = false;
			B_24V_MENOS.GetComponent<Borne> ().realce = true;
			return 29;

		} else if (B_CARGA_1.GetComponent<Borne> ().clique == true) {
			B_CARGA_1.GetComponent<Borne> ().clique = false;
			B_CARGA_1.GetComponent<Borne> ().realce = true;
			return 18;

		} else if (B_CARGA_2.GetComponent<Borne> ().clique == true) {
			B_CARGA_2.GetComponent<Borne> ().clique = false;
			B_CARGA_2.GetComponent<Borne> ().realce = true;
			return 19;

		} else if (B_CARGA_3.GetComponent<Borne> ().clique == true) {
			B_CARGA_3.GetComponent<Borne> ().clique = false;
			B_CARGA_3.GetComponent<Borne> ().realce = true;
			return 20;

		} else if (B_CARGA_4.GetComponent<Borne> ().clique == true) {
			B_CARGA_4.GetComponent<Borne> ().clique = false;
			B_CARGA_4.GetComponent<Borne> ().realce = true;
			return 21;

		} else if (B_CARGA_5.GetComponent<Borne> ().clique == true) {
			B_CARGA_5.GetComponent<Borne> ().clique = false;
			B_CARGA_5.GetComponent<Borne> ().realce = true;
			return 22;

		} else if (B_CARGA_6.GetComponent<Borne> ().clique == true) {
			B_CARGA_6.GetComponent<Borne> ().clique = false;
			B_CARGA_6.GetComponent<Borne> ().realce = true;
			return 23;

		} else if (B_REO_1.GetComponent<Borne> ().clique == true) {
			B_REO_1.GetComponent<Borne> ().clique = false;
			B_REO_1.GetComponent<Borne> ().realce = true;
			return 15;

		} else if (B_REO_2.GetComponent<Borne> ().clique == true) {
			B_REO_2.GetComponent<Borne> ().clique = false;
			B_REO_2.GetComponent<Borne> ().realce = true;
			return 16;

		} else if (B_REO_3.GetComponent<Borne> ().clique == true) {
			B_REO_3.GetComponent<Borne> ().clique = false;
			B_REO_3.GetComponent<Borne> ().realce = true;
			return 17;

		} else if (B_F1.GetComponent<Borne> ().clique == true) {
			B_F1.GetComponent<Borne> ().clique = false;
			B_F1.GetComponent<Borne> ().realce = true;
			return 11;

		} else if (B_F2.GetComponent<Borne> ().clique == true) {
			B_F2.GetComponent<Borne> ().clique = false;
			B_F2.GetComponent<Borne> ().realce = true;
			return 12;

		} else if (B_D1.GetComponent<Borne> ().clique == true) {
			B_D1.GetComponent<Borne> ().clique = false;
			B_D1.GetComponent<Borne> ().realce = true;
			return 30;

		} else if (B_D2.GetComponent<Borne> ().clique == true) {
			B_D2.GetComponent<Borne> ().clique = false;
			B_D2.GetComponent<Borne> ().realce = true;
			return 31;

		} else if (B_A1.GetComponent<Borne> ().clique == true) {
			B_A1.GetComponent<Borne> ().clique = false;
			B_A1.GetComponent<Borne> ().realce = true;
			return 13;

		} else if (B_A2.GetComponent<Borne> ().clique == true) {
			B_A2.GetComponent<Borne> ().clique = false;
			B_A2.GetComponent<Borne> ().realce = true;
			return 14;

		} else if (B_EXPLORATRIZ_1.GetComponent<Borne> ().clique == true) {
			B_EXPLORATRIZ_1.GetComponent<Borne> ().clique = false;
			B_EXPLORATRIZ_1.GetComponent<Borne> ().realce = true;
			return 32;

		} else if (B_EXPLORATRIZ_2.GetComponent<Borne> ().clique == true) {
			B_EXPLORATRIZ_2.GetComponent<Borne> ().clique = false;
			B_EXPLORATRIZ_2.GetComponent<Borne> ().realce = true;
			return 33;

		} else if (B_5A_DC_MAIS.GetComponent<Borne> ().clique == true) {
			B_5A_DC_MAIS.GetComponent<Borne> ().clique = false;
			B_5A_DC_MAIS.GetComponent<Borne> ().realce = true;
			return 9;

		} else if (B_5A_DC_MENOS.GetComponent<Borne> ().clique == true) {
			B_5A_DC_MENOS.GetComponent<Borne> ().clique = false;
			B_5A_DC_MENOS.GetComponent<Borne> ().realce = true;
			return 10;

		} else if (B_5A_AC_MAIS.GetComponent<Borne> ().clique == true) {
			B_5A_AC_MAIS.GetComponent<Borne> ().clique = false;
			B_5A_AC_MAIS.GetComponent<Borne> ().realce = true;
			return 34;

		} else if (B_5A_AC_MENOS.GetComponent<Borne> ().clique == true) {
			B_5A_AC_MENOS.GetComponent<Borne> ().clique = false;
			B_5A_AC_MENOS.GetComponent<Borne> ().realce = true;
			return 35;

		} else if (B_1A_DC_MAIS.GetComponent<Borne> ().clique == true) {
			B_1A_DC_MAIS.GetComponent<Borne> ().clique = false;
			B_1A_DC_MAIS.GetComponent<Borne> ().realce = true;
			return 7;

		} else if (B_1A_DC_MENOS.GetComponent<Borne> ().clique == true) {
			B_1A_DC_MENOS.GetComponent<Borne> ().clique = false;
			B_1A_DC_MENOS.GetComponent<Borne> ().realce = true;
			return 8;

		} else if (B_1A_AC_MAIS.GetComponent<Borne> ().clique == true) {
			B_1A_AC_MAIS.GetComponent<Borne> ().clique = false;
			B_1A_AC_MAIS.GetComponent<Borne> ().realce = true;
			return 36;

		} else if (B_1A_AC_MENOS.GetComponent<Borne> ().clique == true) {
			B_1A_AC_MENOS.GetComponent<Borne> ().clique = false;
			B_1A_AC_MENOS.GetComponent<Borne> ().realce = true;
			return 37;

		} else if (B_250V_DC_MAIS.GetComponent<Borne> ().clique == true) {
			B_250V_DC_MAIS.GetComponent<Borne> ().clique = false;
			B_250V_DC_MAIS.GetComponent<Borne> ().realce = true;
			return 5;

		} else if (B_250V_DC_MENOS.GetComponent<Borne> ().clique == true) {
			B_250V_DC_MENOS.GetComponent<Borne> ().clique = false;
			B_250V_DC_MENOS.GetComponent<Borne> ().realce = true;
			return 6;

		} else if (B_250V_AC_MAIS.GetComponent<Borne> ().clique == true) {
			B_250V_AC_MAIS.GetComponent<Borne> ().clique = false;
			B_250V_AC_MAIS.GetComponent<Borne> ().realce = true;
			return 38;

		} else if (B_250V_AC_MENOS.GetComponent<Borne> ().clique == true) {
			B_250V_AC_MENOS.GetComponent<Borne> ().clique = false;
			B_250V_AC_MENOS.GetComponent<Borne> ().realce = true;
			return 39;

		} else if (B_R2.GetComponent<Borne> ().clique == true) {
			B_R2.GetComponent<Borne> ().clique = false;
			B_R2.GetComponent<Borne> ().realce = true;
			return 40;

		} else if (B_S2.GetComponent<Borne> ().clique == true) {
			B_S2.GetComponent<Borne> ().clique = false;
			B_S2.GetComponent<Borne> ().realce = true;
			return 41;

		} else if (B_T2.GetComponent<Borne> ().clique == true) {
			B_T2.GetComponent<Borne> ().clique = false;
			B_T2.GetComponent<Borne> ().realce = true;
			return 42;

		} else if (B_ENTRADA_R.GetComponent<Borne> ().clique == true) {
			B_ENTRADA_R.GetComponent<Borne> ().clique = false;
			B_ENTRADA_R.GetComponent<Borne> ().realce = true;
			return 43;

		} else if (B_ENTRADA_S.GetComponent<Borne> ().clique == true) {
			B_ENTRADA_S.GetComponent<Borne> ().clique = false;
			B_ENTRADA_S.GetComponent<Borne> ().realce = true;
			return 44;

		} else if (B_ENTRADA_T.GetComponent<Borne> ().clique == true) {
			B_ENTRADA_T.GetComponent<Borne> ().clique = false;
			B_ENTRADA_T.GetComponent<Borne> ().realce = true;
			return 45;

		} else if (B_ENTRADA_N.GetComponent<Borne> ().clique == true) {
			B_ENTRADA_N.GetComponent<Borne> ().clique = false;
			B_ENTRADA_N.GetComponent<Borne> ().realce = true;
			return 46;

		} else if (B_SAIDA_R.GetComponent<Borne> ().clique == true) {
			B_SAIDA_R.GetComponent<Borne> ().clique = false;
			B_SAIDA_R.GetComponent<Borne> ().realce = true;
			return 47;

		} else if (B_SAIDA_S.GetComponent<Borne> ().clique == true) {
			B_SAIDA_S.GetComponent<Borne> ().clique = false;
			B_SAIDA_S.GetComponent<Borne> ().realce = true;
			return 48;

		} else if (B_SAIDA_T.GetComponent<Borne> ().clique == true) {
			B_SAIDA_T.GetComponent<Borne> ().clique = false;
			B_SAIDA_T.GetComponent<Borne> ().realce = true;
			return 49;

		} else if (B_SAIDA_N.GetComponent<Borne> ().clique == true) {
			B_SAIDA_N.GetComponent<Borne> ().clique = false;
			B_SAIDA_N.GetComponent<Borne> ().realce = true;
			return 50;

		} else if (B_TERRA.GetComponent<Borne> ().clique == true) {
			B_TERRA.GetComponent<Borne> ().clique = false;
			B_TERRA.GetComponent<Borne> ().realce = true;
			return 51;
		}

		return 0;
	}// fim da funcao conectar

	// DESATIVA TODOS OS REALCES DOS BORNES
	void Desativar_Realce(){
		B_250V_DC_MAIS.GetComponent<Borne> ().realce = false;
		B_DC_MAIS_1.GetComponent<Borne> ().realce = false;
		B_DC_MENOS_1.GetComponent<Borne> ().realce = false;
		B_AC1_1.GetComponent<Borne> ().realce = false;
		B_AC2_1.GetComponent<Borne> ().realce = false;
		B_DC_MAIS_2.GetComponent<Borne> ().realce = false;
		B_DC_MENOS_2.GetComponent<Borne> ().realce = false;
		B_AC1_2.GetComponent<Borne> ().realce = false;
		B_AC2_2.GetComponent<Borne> ().realce = false;
		B_24V_MAIS.GetComponent<Borne> ().realce = false;
		B_24V_MENOS.GetComponent<Borne> ().realce = false;
		B_CARGA_1.GetComponent<Borne> ().realce = false;
		B_CARGA_2.GetComponent<Borne> ().realce = false;
		B_CARGA_3.GetComponent<Borne> ().realce = false;
		B_CARGA_4.GetComponent<Borne> ().realce = false;
		B_CARGA_5.GetComponent<Borne> ().realce = false;
		B_CARGA_6.GetComponent<Borne> ().realce = false;
		B_REO_1.GetComponent<Borne> ().realce = false;
		B_REO_2.GetComponent<Borne> ().realce = false;
		B_REO_3.GetComponent<Borne> ().realce = false;
		B_F1.GetComponent<Borne> ().realce = false;
		B_F2.GetComponent<Borne> ().realce = false;
		B_D1.GetComponent<Borne> ().realce = false;
		B_D2.GetComponent<Borne> ().realce = false;
		B_A1.GetComponent<Borne> ().realce = false;
		B_A2.GetComponent<Borne> ().realce = false;
		B_EXPLORATRIZ_1.GetComponent<Borne> ().realce = false;
		B_EXPLORATRIZ_2.GetComponent<Borne> ().realce = false;
		B_5A_DC_MAIS.GetComponent<Borne> ().realce = false;
		B_5A_DC_MENOS.GetComponent<Borne> ().realce = false;
		B_5A_AC_MAIS.GetComponent<Borne> ().realce = false;
		B_5A_AC_MENOS.GetComponent<Borne> ().realce = false;
		B_1A_DC_MAIS.GetComponent<Borne> ().realce = false;
		B_1A_DC_MENOS.GetComponent<Borne> ().realce = false;
		B_1A_AC_MAIS.GetComponent<Borne> ().realce = false;
		B_1A_AC_MENOS.GetComponent<Borne> ().realce = false;
		B_250V_DC_MAIS.GetComponent<Borne> ().realce = false;
		B_250V_DC_MENOS.GetComponent<Borne> ().realce = false;
		B_250V_AC_MAIS.GetComponent<Borne> ().realce = false;
		B_250V_AC_MENOS.GetComponent<Borne> ().realce = false;
		B_R2.GetComponent<Borne> ().realce = false;
		B_S2.GetComponent<Borne> ().realce = false;
		B_T2.GetComponent<Borne> ().realce = false;
		B_ENTRADA_R.GetComponent<Borne> ().realce = false;
		B_ENTRADA_S.GetComponent<Borne> ().realce = false;
		B_ENTRADA_T.GetComponent<Borne> ().realce = false;
		B_ENTRADA_N.GetComponent<Borne> ().realce = false;
		B_SAIDA_R.GetComponent<Borne> ().realce = false;
		B_SAIDA_S.GetComponent<Borne> ().realce = false;
		B_SAIDA_T.GetComponent<Borne> ().realce = false;
		B_SAIDA_N.GetComponent<Borne> ().realce = false;
		B_TERRA.GetComponent<Borne> ().realce = false;
	}// fim da Funcao desativa realse

}// fim do clasee
