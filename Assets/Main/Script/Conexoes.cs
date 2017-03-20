using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;


public class Conexoes : MonoBehaviour {


	// Esses objetos sao os bornes da cena
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
	//total 51

	// OBJETOS COM INTERAÇAO 
	public GameObject VOLTIMETRO_DC;     // OBJETO DO VOLTIMETRO QUE IRA SE MOVIMENTAR
	public GameObject AMPERIMETRO_DC_5A; // OBJETO DO AMPERIMETRO QUE IRA SE MOVIMENTAR
	public GameObject AMPERIMETRO_DC_1A; // OBJETO DO MILIAMPERIMETRO QUE IRA SE MOVIMENTAR
	public GameObject EIXO_MOTOR;        // OBEJTO QUE REALIZA A ROTACAO

	// OBJETOS QUE FORNECEM INFORMAÇOES
	public GameObject VARIADOR_1;
	public GameObject VARIADOR_2;
	public GameObject REOSTATO;
	public GameObject CARGA_RESISTIVA;
	public GameObject ACIONAMENTO_GERAL;

	public GameObject Relatorio;
	public GameObject mapa;

	private GameObject cabo;
		
	private int linha,coluna;
	public int [,] Matriz;

	int k = 0;

	//VARIAVEIS DE ESTADO DE VERIFICAÇAO
	private int Conexao_1;
	private int Conexao_2;
	private bool fonte_serie_enable=false;
	public bool voltimetro_enable=false; // trocar pra private
	public bool voltimetro_serie_enable=false; // trocar pra private (PODE SER REMOVIDO)
	private bool mA_enable=false;
	private bool A_enable=false;
	private int Carga_do_Campo=0;//0:ZERO, 1:CARGA MARCADA, 2:TOTAL
	private int Tipo_Carga=0;// 1 SERIE, 2 PARALELO, 3 INDIVIDUAL, 0 NAO HA CARGA
	private bool fonte_individual = false;

	// variveis de controle de conexao
	private bool conec_Fonte   = false;
	private bool conec_Volt    = false;
	private bool conec_1A      = false;
	private bool conec_5A      = false;
	private bool conec_Motor   = false;
	private bool conec_Indutor = false;
	private bool conec_Rfc     = false;
	private bool conec_Rac     = false;


	// VARIAVEIS
	private float valor_tensao;
	private float valor_mA;
	private float valor_A;
	private float valor_rotacao=1;
	private float valor_reostato;
	private float valor_carga_resistiva;

	// CONSTANTES
	private float resistencia_campo = 180;// ESSE VALOR DEVE SER METIDO NO MOTOR (RESISTENCIA DO CAMPO)
	private float resistencia_motor = 1;// ESSE VALOR DEVE SER METIDO NO MOTOR (RESISTENCIA INTERNA DA BOBINA)
	private float torque = 0.2865f; // ESSE VALOR FOI PASSADO PELO PROFESSOR JUAN

	// VALORES DA CARGA RESISTIVA DE ACORDO COM A POSSIÇAO
	private float valor_carga_1 = 180;
	private float valor_carga_2 = 90;
	private float valor_carga_3 = 60;
	private float valor_carga_4 = 45;
	private float valor_carga_5 = 36;

	// VARIAVEIS DE CONTROLE DOS CABOS
	public bool C_1_4 = false;
	public bool C_1_5 = false;
	public bool C_1_7 = false;
	public bool C_1_9 = false;
	public bool C_2_3 = false;
	public bool C_2_6 = false;
	public bool C_2_12 = false;
	public bool C_2_14 = false;
	public bool C_3_6 = false;
	public bool C_3_12 = false;
	public bool C_3_14 = false;
	public bool C_4_6 = false;
	public bool C_4_12 = false;
	public bool C_4_14 = false;
	public bool C_5_7 = false;
	public bool C_5_9 = false;
	public bool C_6_12 = false;
	public bool C_6_14 = false;
	public bool C_7_9 = false;
	public bool C_8_15 = false;
	public bool C_8_16 = false;
	public bool C_8_17 = false;
	public bool C_10_13 = false;
	public bool C_10_18 = false;
	public bool C_10_19 = false;
	public bool C_10_20 = false;
	public bool C_10_21 = false;
	public bool C_10_22 = false;
	public bool C_10_23 = false;
	public bool C_11_15 = false;
	public bool C_11_16 = false;
	public bool C_11_17 = false;
	public bool C_12_14 = false;
	public bool C_13_18 = false;
	public bool C_13_19 = false;
	public bool C_13_20 = false;
	public bool C_13_21 = false;
	public bool C_13_22 = false;
	public bool C_13_23 = false;
	public bool C_18_20 = false;
	public bool C_18_21 = false;
	public bool C_18_22 = false;
	public bool C_18_23 = false;
	public bool C_19_20 = false;
	public bool C_19_21 = false;
	public bool C_19_22 = false;
	public bool C_19_23 = false;
	public bool C_20_22 = false;
	public bool C_20_23 = false;
	public bool C_21_22 = false;
	public bool C_21_23 = false;
	

	void Start () {
		//INICIALIZAÇAO
		Conexao_1 = 0;
		Conexao_2 = 0;

		//TAMANHO DA MATRIZ
		linha = 11;
		coluna = 15;
		Matriz = new int[linha,coluna];

		//Preenche a Matriz com ZERO
		for(int i = 1;i<linha;i++){
			for(int j = 1;j<coluna;j++){
				Matriz [i,j]=0;
			} // fim do for j
		}// fim do for i
	}// fim da funcao start

	/* Pontos:
	 * Ponto A: 1,5,7,9
	 * Ponto B: 2,3,6,12,14
	 * Ponto C: 4,6,12,14
	 * Ponto D: 8,15,16,17
	 * Ponto E: 11,15,16,17
	 * Ponto F: 10
	 * Ponto G: 18,19,20,21,22,23
	 * Ponto H: 18,19,20,21,22,23
	 * Ponto I: 18,19,20,21,22,23
	 * Ponto J: 13
	 * 
	 * Componentes:
	 * 1: Variador 1 (1,2)
	 * 2: Variador 2 (3,4)
	 * 3: Voltimetro DC (5,6)
	 * 4: Amperimetro 1A DC (7,8)
	 * 5: Amperimetro 5A DC (9,10)
	 * 6: Campo do Motor (11,12)
	 * 7: Shield (13,14)
	 * 8: Reostato (3 Pontos)(15,16,17)
	 * 9: Carga R1 18
	 * 10: Carga R1 19
	 * 11: Carga R2 20
	 * 12: Carga R2 21
	 * 13: Carga R3 22
	 * 14: Carga R3 23
	 * 
	 * Matriz:
	 *  |01|02|03|04|05|06|07|08|09|10|11|12|13|14|
	 * A|+1|  |+1|+1|+1|  |  |  |  |  |  |  |  |  |
	 * B|-1|+1|-1|  |  |-1|-1|  |  |  |  |  |  |  |
	 * C|  |-1|-1|  |  |-1|-1|  |  |  |  |  |  |  |
	 * D|  |  |  |-1|  |  |  | 1|  |  |  |  |  |  |
	 * E|  |  |  |  |  |+1|  | 1|  |  |  |  |  |  |
	 * F|  |  |  |  |-1|  |  |  | 1| 1| 1| 1| 1| 1|
	 * G|  |  |  |  |  |  |+1|  | 1| 1| 1| 1| 1| 1|
	 * H|  |  |  |  |  |  |  |  | 1| 1| 1| 1| 1| 1|
	 * I|  |  |  |  |  |  |  |  |  | 1| 1| 1| 1|  |
	 * J|  |  |  |  |  |  |  |  | 1| 1| 1| 1| 1| 1|
	 * 
	 * Fontes em Serie:
	 * 1-(DC)-2-3(DC)-4
	 * 
	 * 
	 */
	
	// Update is called once per frame
	void Update () {
		//Relatorio.GetComponent<Text> ().text = "";

		// VERIFICA O PAR DE CONEXAO
		if (Conexao_1 == 0) { //ESPERA A PRIMEIRA CONEXAO
			Conexao_1 = Conectar ();
		} else if (Conexao_2 == 0) {// APOS A PRIMEIRA CONEXAO ESPERA A SEGUNDA CONEXAO
			Conexao_2 = Conectar ();
			//print(Conexao_1+":"+Conexao_2);// apagar depois
			//Relatorio.GetComponent<Text>().text = Conexao_1+":"+Conexao_2;

		} else if (Conexao_1 != 0 && Conexao_2 != 0) {
			//Garante que vai preencher somente a diagonal superior da matriz
			if (Conexao_1 > Conexao_2) {
				int Temp = Conexao_1;
				Conexao_1 = Conexao_2;
				Conexao_2 = Temp;
			}

			//FUNCAO PARA VERIFICAR E MONTAR A MATRIZ
			Montar_Matriz ();

			//ESSA FUNCAO SALVA EM UM ARQUIVO
			Salvar_Matriz ();

			// FUNCAO QUE EXIBE O CABO NA TELA
			//Exibir_Cabo();

			//APOS PREENCHER A MATRIZ MARCAR AS VARIAVES COM ZERO
			Conexao_1 = 0;
			Conexao_2 = 0;
		}

		// FAZ AS CHAMADAS DAS VERIFICAÇOES
		Verificar_Conexao ();

		// FAZ OS CALCULOS DOS COMPONENTES
		Realizar_Calculos ();
		Exibir_mapa_circuito ();
		Exibir_status ();

		// ATIVA A SIMULAÇAO
		// EXIBE OS VALORES CALCULADOS NOS INSTRUMENTOS
		Acionar_Simulacao_Instrumentos ();


	}// FIM DO UPDATE

	/*FUNCAO QUE PROCURA QUAIS SAO OS CABOS QUE ESTAO NA TELA*/
	void Exibir_status (){

		/* ESSA TRECHO VERIFICA SE ESTA SENDO EXIBIDO O CABO */ 
		C_1_4 = GameObject.FindGameObjectWithTag ("1:4").GetComponent<Cabos> ().Hide_Show;
		C_1_5  = GameObject.FindGameObjectWithTag("1:5").GetComponent<Cabos> ().Hide_Show;
		C_1_7  = GameObject.FindGameObjectWithTag("1:7").GetComponent<Cabos> ().Hide_Show;
		C_1_9  = GameObject.FindGameObjectWithTag("1:9").GetComponent<Cabos> ().Hide_Show;
		C_2_3  = GameObject.FindGameObjectWithTag("2:3").GetComponent<Cabos> ().Hide_Show;
		C_2_6  = GameObject.FindGameObjectWithTag("2:6").GetComponent<Cabos> ().Hide_Show;
		C_2_12 = GameObject.FindGameObjectWithTag("2:12").GetComponent<Cabos> ().Hide_Show;
		C_2_14 = GameObject.FindGameObjectWithTag("2:14").GetComponent<Cabos> ().Hide_Show;
		C_3_6  = GameObject.FindGameObjectWithTag("3:6").GetComponent<Cabos> ().Hide_Show;
		C_3_12 = GameObject.FindGameObjectWithTag("3:12").GetComponent<Cabos> ().Hide_Show;
		C_3_14 = GameObject.FindGameObjectWithTag("3:14").GetComponent<Cabos> ().Hide_Show;
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
		C_10_13 = GameObject.FindGameObjectWithTag("10:13").GetComponent<Cabos> ().Hide_Show;
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


	
	}
	/* ESSA FUNCAO TEM COMO OBJETIVO CONFERIR A CONEXAO E EXIBIR O MAPA ADEQUADO */
	// CADA COMPONENTE QUANDO CONECTADO DEVER SER EXIBIDO A SUA CONEXAO NO MAPA
	void Exibir_mapa_circuito (){
		// Caso do fonte
		if (Matriz [1, 1] != 0 && Matriz [2, 1] != 0 && Matriz [2, 2] != 0 && Matriz [3, 2] != 0) {
			//print ("FONTE SERIE");
			conec_Fonte = true;
			GameObject.FindGameObjectWithTag ("mapa-1").GetComponent<RawImage> ().enabled = true;
		} else if (Matriz [1, 1] != 0 && Matriz [2, 1] != 0 && Matriz [2, 2] == 0 && Matriz [3, 2] == 0) {
			//print ("FONTE INDIVIDUAL");		
			conec_Fonte = true;
			GameObject.FindGameObjectWithTag ("mapa-1").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_Fonte = false;
			GameObject.FindGameObjectWithTag ("mapa-1").GetComponent<RawImage> ().enabled = false;
		}
		// Caso do voltimetro
		if (Matriz [1, 3] != 0 && (Matriz [2, 3] != 0 || Matriz [3, 3] != 0)) {
			//print ("Voltimetro");
			conec_Volt = true;
			GameObject.FindGameObjectWithTag ("mapa-2").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_Volt = false;
			GameObject.FindGameObjectWithTag ("mapa-2").GetComponent<RawImage> ().enabled = false;
		}
		// caso do 1A
		if (Matriz [1, 4] != 0 && Matriz [4, 4] != 0) {
			//print ("1A");
			conec_1A = true;
			GameObject.FindGameObjectWithTag ("mapa-3").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_1A = false;
			GameObject.FindGameObjectWithTag ("mapa-3").GetComponent<RawImage> ().enabled = false;
		}
		// caso do 5A
		if (Matriz [1, 5] != 0 && Matriz [6, 5] != 0) {
			conec_5A = true;
			GameObject.FindGameObjectWithTag ("mapa-4").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_5A = false;
			GameObject.FindGameObjectWithTag ("mapa-4").GetComponent<RawImage> ().enabled = false;
		}
		// caso do rfc // campo do indutor [4,8]
		if (Matriz [4, 8] != 0 && Matriz [5, 8] != 0 ) {
			//print ("RESISTENCIA - RFC");
			conec_Rfc = true;
			GameObject.FindGameObjectWithTag ("mapa-7").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_Rfc = false;
			GameObject.FindGameObjectWithTag ("mapa-7").GetComponent<RawImage> ().enabled = false;
		}
		// caso do rac // motor
		if ((Matriz [6, 9] != 0 || Matriz [6, 10] != 0 || Matriz [6, 11] != 0 || Matriz [6, 12] != 0 || Matriz [6, 13] != 0 || Matriz [6, 14] != 0) && Tipo_Carga != 0 &&
		    (Matriz [10, 9] != 0 || Matriz [10, 10] != 0 || Matriz [10, 11] != 0 || Matriz [10, 12] != 0 || Matriz [10, 13] != 0 || Matriz [10, 14] != 0)) {
			//print ("RESISTENCIA - RAC");
			conec_Rac = true;
			GameObject.FindGameObjectWithTag ("mapa-8").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_Rac = false;
			GameObject.FindGameObjectWithTag ("mapa-8").GetComponent<RawImage> ().enabled = false;
		}
		// caso do motor
		print (Tipo_Carga);

		if (Matriz [10, 7] != 0 && (Matriz [2, 7] != 0 || Matriz [3, 7] != 0)) {
			conec_Motor = true;
			GameObject.FindGameObjectWithTag ("mapa-5").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_Motor = false;
			GameObject.FindGameObjectWithTag ("mapa-5").GetComponent<RawImage> ().enabled = false;
		}
		// caso do indutor
		if (Matriz [2, 6] != 0 && (Matriz [3, 6] != 0 || Matriz [5, 6] != 0)) {
			conec_Indutor = true;
			GameObject.FindGameObjectWithTag ("mapa-6").GetComponent<RawImage> ().enabled = true;
		} else {
			conec_Indutor = false;
			GameObject.FindGameObjectWithTag ("mapa-6").GetComponent<RawImage> ().enabled = false;
		}
	
	} // fim da funcao que exibe

	/* ESSA FUNCAO VERIFICA SE EXISTE CONDIÇOES PARA FUCIONAMENTO DA SIMULACAO */
	// VERIFICA SE ESTA LIGADA A BANCADA (TALVEZ PODE SER REMOVIDO)
	// VERIFICA SE OS INTRUMENTOS ESTAO LIGADOS
	// VERIFICA SE ESTAO FEITAS TODAS AS CONEXOES NESCESSARIAS
	// ATIVA OS INTRUMENTOS
	// EXIBI OS RESULTADOS NOS INSTRUMENTOS
	void Acionar_Simulacao_Instrumentos (){
		

		// VOLTIMETRO
		if (voltimetro_enable == true) {
			Relatorio.GetComponent<Text>().text = "Voltimetro Conectado";
			VOLTIMETRO_DC.GetComponent<Voltimetro> ().tensao = valor_tensao;
			GameObject.FindGameObjectWithTag ("status_volt").GetComponent<Text>().text = "Voltimetro: "+valor_tensao+" V";
		} else {
			VOLTIMETRO_DC.GetComponent<Voltimetro> ().tensao = 0;
			GameObject.FindGameObjectWithTag ("status_volt").GetComponent<Text>().text = "Voltimetro: "+0+" V";
		}// fim do voltimetro

		// AMPERIMETRO 1A
		if (mA_enable == true) {
			Relatorio.GetComponent<Text>().text = "MiliAmperimetro Conectado";
			AMPERIMETRO_DC_1A.GetComponent<Amperimetro> ().corrente = valor_mA;
			GameObject.FindGameObjectWithTag ("status_1A").GetComponent<Text>().text = "Amperimetro 1A: "+valor_mA.ToString("0.###")+" mA";

		} else {
			AMPERIMETRO_DC_1A.GetComponent<Amperimetro>().corrente=0;
			GameObject.FindGameObjectWithTag ("status_1A").GetComponent<Text>().text = "Amperimetro 1A: "+0+" mA";

		}// fim do amperimetro 1A

		// AMPERIMETRO 
		if (A_enable == true) {
			Relatorio.GetComponent<Text>().text = "Amperimetro Conectado";
			AMPERIMETRO_DC_5A.GetComponent<Amperimetro> ().corrente = valor_A;
			GameObject.FindGameObjectWithTag ("status_5A").GetComponent<Text>().text = "Amperimetro 5A: "+valor_A.ToString("0.###")+" A";
		} else {
			AMPERIMETRO_DC_5A.GetComponent<Amperimetro> ().corrente = 0;
			GameObject.FindGameObjectWithTag ("status_5A").GetComponent<Text>().text = "Amperimetro 5A: "+0+" A";
		}// fim do amperimetro 5A

		// ROTACAO (GARANTIR QUE TODAS AS PEÇAS ESTAO CONECTADAS)
		if (voltimetro_enable == true && mA_enable == true && A_enable == true) {
			// TEM QUE FAZER O EIXO
			if (valor_rotacao >= 0 || valor_rotacao <= 0) {
				EIXO_MOTOR.GetComponent<Transform> ().Rotate (0, 0, valor_rotacao);
				GameObject.FindGameObjectWithTag ("status_velo").GetComponent<Text> ().text = "Velocidade: " + valor_rotacao.ToString ("0.#") + " RPM";
				Relatorio.GetComponent<Text> ().text = "Equipamentos Prontos";
			} else {
				EIXO_MOTOR.GetComponent<Transform> ().Rotate (0,0,0);
				GameObject.FindGameObjectWithTag ("status_velo").GetComponent<Text>().text = "Velocidade: "+ 0 +" RPM";
			}

		} else {
			EIXO_MOTOR.GetComponent<Transform> ().Rotate (0,0,0);
			GameObject.FindGameObjectWithTag ("status_velo").GetComponent<Text>().text = "Velocidade: "+ 0 +" RPM";
			
		} // fim da rotacao
		GameObject.FindGameObjectWithTag ("status_Rfc").GetComponent<Text>().text = "RFC: "+ valor_reostato +" Ohms";
		GameObject.FindGameObjectWithTag ("status_Rac").GetComponent<Text>().text = "RAC: "+ valor_carga_resistiva +" Ohms";


	}// fim da funcao da funcao de acionamento

	/* ESSA FUNCAO REALIZA OS CALCULOS DOS VALORES*/
	// TENSAO
	// CORRENTE (miliamper)
	// CORRENTE (amper)
	// ROTACAO DO MOTOR
	void Realizar_Calculos (){

		/* REALIZA A CHAMADA DA FUNCAO QUE CALCULA A TENSAO */
		Calculo_Tensao ();

		/* REALIZA A CHAMADA DA FUNCAO QUE REALIZA O CALCULO DA CORRENTE miliAMPER*/
		Calculo_Corrente_MiliAmper ();

		/* REALIZA A CHAMADA DA FUNCAO QUE REALIZA O CALCULO DA CORRENTE AMPER*/
		Calculo_Corrente_Amper ();

		/* REALIZA A CHAMADA DA FUNCAO QUE REALIZA O CALCULO DA ROTACAO */
		Calculo_rotacao ();

	}// fim do realizar calculos

	/* FUNCAO QUE CALCULA A TENSAO */
	// ESSA TENSAO SERA A TENSAO FORNECIDA PARA O CIRCUITO
	void Calculo_Tensao (){

		// CASO FONTE SIMPLES
		valor_tensao = VARIADOR_1.GetComponent<Variador_de_Tensao> ().Variador_Valor;

		// CASO FONTE EM SERIE
		if(fonte_serie_enable==true){
			valor_tensao = valor_tensao + VARIADOR_2.GetComponent<Variador_de_Tensao>().Variador_Valor;
		}// fim do if serie

		//print ("TENSAO:"+valor_tensao);//PODE SER APAGADO

	}// fim do calculo da tensao

	/* FUNCAO QUE CALCULA A CORRENTE MILIAMPER */
	// ESSA CORRENTE SERA A CORRENTE QUE PASSA NO CAMPO NO MOTOR
	void Calculo_Corrente_MiliAmper(){

		/* VERIFICA QUAL CONFIGURAÇAO ESTA O REOSTATO */
		// VALOR IGUAL A ZERO
		if (Carga_do_Campo == 0) {
			valor_reostato=0;
		}// fim do caso zero

		// VALOR MARCADO NO REOSTATO
		if (Carga_do_Campo == 1) {
			valor_reostato = REOSTATO.GetComponent<Variador_Reostato> ().Variador_Valor;
		}// fim do caso marcado

		// VALOR TOTAL DO REOSTATO
		if (Carga_do_Campo == 2) {
			valor_reostato = 1000;
		}// fim do caso total

		valor_mA = valor_tensao/(valor_reostato + resistencia_campo);

		//print ("CORRENTE if:"+valor_mA);//pode APAGAR

	}// fim do calculo da corrente

	/* FUNCAO QUE CALCULA A CORRENTE AMPER*/
	// ESSA CORRENTE QUE PASSA PELO MOTOR
	void Calculo_Corrente_Amper(){
		int possicao_chave = CARGA_RESISTIVA.GetComponent<Chave_Seletora>().posicao;

		//VERIFICA A POSSICAO DA CHAVE E ATRIBUI UM VALOR DETERMINADO
		switch (possicao_chave) {
		case 0:
			valor_carga_resistiva = 0;
			break;
		case 1:
			valor_carga_resistiva = valor_carga_1;
			break;
		case 2:
			valor_carga_resistiva = valor_carga_2;
			break;
		case 3:
			valor_carga_resistiva = valor_carga_3;
			break;
		case 4:
			valor_carga_resistiva = valor_carga_4;
			break;
		case 5:
			valor_carga_resistiva = valor_carga_5;
			break;
		}// fim do switch

		// DEFINE O VALOR DA CARGA DE ACORDO COM O ARRANJO
		switch (Tipo_Carga) {
		case 0:// NAO ESTA LIGADO
			valor_carga_resistiva=0;
			break;
		case 1:// LIGADO EM SERIE
			valor_carga_resistiva=valor_carga_resistiva*3;
			break;
		case 2:// LIGADO EM PARALELO
			valor_carga_resistiva=valor_carga_resistiva/3;
			break;
		case 3:// LIGADO INDIVIDUAL
			valor_carga_resistiva=valor_carga_resistiva;
			break;
		}// fim do switch

		// CALCULO DA CORRENTE
		valor_A = valor_tensao / (valor_carga_resistiva + resistencia_motor);

		//print ("CORRENTE:"+valor_A);// PODE APAGAR

	}// fim da funcao que calcula corrente

	/* FUNCAO QUE CALCULA A ROTACAO DO MOTOR */
	// (TENSAO/(RESISTENCIA_CAMPO*CORRENTE_CAMPO)) - ((RESISTENCIA_MOTOR+CARGA)*TORQUE)/(RESISTENCIA_CAMPO*CORRENTE_CAMPO)
	// O RESULTADO EH OBTIDO EM Rad/s
	// CONVERTAR PARA RPM MULTIPLICA POR 9,549296585514
	void Calculo_rotacao(){
		
		/// ESTA COM ERROS CORRIGIR
		/// 
		valor_rotacao = valor_tensao/(resistencia_campo*valor_mA) - ((resistencia_motor+valor_carga_resistiva)*torque)/(resistencia_campo*valor_mA);

		valor_rotacao = valor_rotacao*9.549296585514f;// CONVERTE PARA RPM

		//print ("ROTACAO:" + valor_rotacao);// pode APAGAR
	}// fim do calcular rotacao
	
	/* VERIFICA AS FONTES */
	// VERIFICA A LIGACAO DO VOLTIMETRO DE ACORDO COM AS LIGAÇOES DAS FONTES
	void Verifica_Conexao_Fonte(){
		//VERIFICAR SE A FONTE ESTA EM SERIE OU NAO
		if (Matriz [2, 1] != 0 && Matriz [2, 2] != 0 && Matriz [1, 1] != 0 
			&& Matriz [1,3] != 0 && Matriz [3, 2] != 0 && Matriz [3, 3] != 0) {
			fonte_serie_enable=true;
			Relatorio.GetComponent<Text>().text = "Fontes Ligadas em Serie";
		} else {
			fonte_serie_enable=false;
		}
		
		// VOLTIMETRO LIGADO A UMA UNICA FONTE ou FONTE EM SERIE
		if ((Matriz [1, 1] != 0 && Matriz [1, 3] != 0 && Matriz [2, 1] != 0 && Matriz [2, 3] != 0)||fonte_serie_enable==true) {
			voltimetro_enable = true;
		} else {
			voltimetro_enable = false;
		}

	}// fim do verica conexao fonte
		
	// Verificaçao do Miliamperimeto
	// Fonte->mA->R->Campo->Fonte
	// 1: VERIFICA SE ESTA CONETADO CORRETAMENTE
	// 2: VERIFICA A FORMA DA CONEXAO DA CARGA: VALOR MARCADO, TOTAL OU ZERO 
	void Verifica_Mili_Amperimetro(){
	
		Carga_do_Campo = 0;

		/*CONFERE SE ESTA CONCTADO CORRETAMENTE*/
		// FONTE LIGADA NO mA
		// mA LIGADO NO REOSTATO(CARGA)
		// CAMPO LIGADO NA FONTE

		//A1 & A4 & D4 & D8 & E6 & E8 &((B1&B6)||(C2&C6)) 
		if ((Matriz [1, 1] != 0) && (Matriz [1, 4] != 0) && (Matriz [4, 4] != 0) && (Matriz [4, 8] != 0) && (Matriz [5, 6] != 0) && (Matriz [5, 8] != 0)
			&& (((Matriz [2, 1] != 0) && (Matriz [2, 6] != 0)) || ((Matriz [3, 2] != 0) && (Matriz [3, 6] != 0)))) {

			mA_enable = true;

			/* Confere a carga: VALOR MARCADO
			 * ([D8=1 & E8=2]||[D8=2 & E8=1]) || ([D8=2 & E8=3]||[D8=3 & E8=2]) */
			if (((Matriz [4, 8] == 1 && Matriz [5, 8] == 2) || (Matriz [4, 8] == 2 && Matriz [5, 8] == 1)) ||
				((Matriz [4, 8] == 2 && Matriz [5, 8] == 3) || (Matriz [4, 8] == 3 && Matriz [5, 8] == 2))) {
	
				Relatorio.GetComponent<Text>().text = "Reostado: Valor Marcado";
				//print("KIAKIS");
				Carga_do_Campo = 1;//VALOR MARCADO

			}// FIM DO CONFERE CARGA: VALOR MARCADO

			/* Confere a carga: CARGA TOTAL
			 * (D8=1&E8=3)||(D8=3&E8=1) */
			if ((Matriz [4, 8] == 1 && Matriz [5, 8] == 3) || (Matriz [4, 8] == 3 && Matriz [5, 8] == 1)) {
			
				Relatorio.GetComponent<Text>().text = "Reostado: Valor Total";
				Carga_do_Campo = 2;//CARGA TOTAL

			}// FIM DO CONFERE CARGA: CARGA TOTAL

			/* Confere a carga: CARGA ZERO
			 * D8=E8*/
			if (Matriz [4, 8] == Matriz [5, 8]) {

				Carga_do_Campo = 0;
				Relatorio.GetComponent<Text>().text = "Reostado: Valor ZERO";
				//print("KIAKIS");

			}// FIM DO CONFERE CARGA: CARGA ZERO

		} // fim do if completo
		else { // CASO NAO ATIVO
			mA_enable=false;
		}// FIM DO ELSE NAO ATIVO

	}// fim do miliamperimetro

	/* VERIFICAR A PARTE DO AMPERIMETRO COM O MOTOR E CARGA DE RESIETENCIA */
	// Fonte->A->R->MOTOR->Fonte
	// A fonte sempre sera a fonte1
	// O amperimetro eh o de 5A
	// A carga de resistencia sera ligada: 3 em Serie / 3 em paralelo / 1 individual
	void Verifica_Amperimetro (){
		Tipo_Carga = 0;

		/* CONFERE A CARGA RESISTIVA
		 * 1 CASO EM SERIE
		 * 2 CASOS EM PARALELOS
		 * 3 CASOS INDIVIDUAIS
		 */

		/* CASO EM SERIE */
		// NAO PODE HAVER CONEXAO G E H.
		// NAO PODE HAVER CONEXAO EM F10, F11, F12, F13, F14
		// SOMENTE CONEXAO EM I
		if ((Matriz [9, 10] == 1 && Matriz [9, 11] == 1 && Matriz [9, 12] == 1 && Matriz [9, 13] == 1)
			&& ((Matriz[6,9]==1 && Matriz[10,14]==1)||(Matriz[6,14]==1 && Matriz[10,9]==1))) {
			// verifica que nao tem conexao em G,H,F10,F11,F12,F13,F14,
			if ((Matriz[6,10]!=1 && Matriz[6,11]!=1 &&Matriz[6,12]!=1 && Matriz[6,13]!=1)
			    && (Matriz[7,9]!=1 && Matriz[7,10]!=1 && Matriz[7,11]!=1 &&Matriz[7,12]!=1 && Matriz[7,13]!=1&&Matriz[7,14]!=1)
			    && (Matriz[8,9]!=1 && Matriz[8,10]!=1 && Matriz[8,11]!=1 &&Matriz[8,12]!=1 && Matriz[8,13]!=1&&Matriz[8,14]!=1)
			    && (Matriz[10,10]!=1 && Matriz[10,11]!=1 &&Matriz[10,12]!=1 && Matriz[10,13]!=1)){
			
				Relatorio.GetComponent<Text>().text = "Carga Resistiva: Ligada em Serie";
				Tipo_Carga =1;

			}

		} else {
			// 2 CASOS PARALELOS TRATADOS
			// JA ESTA ELIMINADO A POSSIBILIDADE DE TER CONEXAO EM I(SERIE)
			// CASO 1: AMPERIMETRO E MOTOR LIGADOS A TODAS AS RESISTECIAS DE FORMA PARALELA
			// CASO 2: RESISTENCIA LIGADAS ENTRE SI EM PARALELO E HA PELO MENOS UMA CONEXAO COM O AMPERIMETRO E MOTOR

			/* CASO 1 PARALELO */
			// NAO PODE HAVER CONEXAO EM I(JA TRATADO)
			// NAO PODE HAVER CONEXAO EM G E H
			// SE F TEM SOMENTE IMPAR J TEM SOMENTE PAR
			// SE F TEM SOMENTE PAR J TEM SOMENTE IMPAR
			// ((F IMPAR E J PAR) OU (F PAR E J IMPAR)) E (NAO TEM G) E (NAO TEM H)
			if  ((((Matriz[6,9]==1 && Matriz[6,11]==1 && Matriz[6,13]==1)// F IMPAR E J PAR
			    && (Matriz[10,10]==1 && Matriz[10,12]==1 && Matriz[10,14]==1)
			    && (Matriz[6,10]!=1 && Matriz[6,12]!=1 && Matriz[6,14]!=1)
			    && (Matriz[10,9]!=1 && Matriz[10,11]!=1 && Matriz[10,13]!=1)
			       ) || //F PAR J IMPAR 
			      ((Matriz[6,10]==1 && Matriz[6,12]==1 && Matriz[6,14]==1)
			    && (Matriz[10,9]==1 && Matriz[10,11]==1 && Matriz[10,13]==1)
			    && (Matriz[6,9]!=1 && Matriz[6,11]!=1 && Matriz[6,13]!=1)
			    && (Matriz[10,10]!=1 && Matriz[10,12]!=1 && Matriz[10,14]!=1)
			      		))//FIM DO OU.
			     // GARANTIR QUE NAO TEM CONEXAO EM G E H
			    && (Matriz[7,9]!=1 && Matriz[7,10]!=1 && Matriz[7,11]!=1 &&Matriz[7,12]!=1 && Matriz[7,13]!=1&&Matriz[7,14]!=1)
			    && (Matriz[8,9]!=1 && Matriz[8,10]!=1 && Matriz[8,11]!=1 &&Matriz[8,12]!=1 && Matriz[8,13]!=1&&Matriz[8,14]!=1)){

				Relatorio.GetComponent<Text>().text = "Carga Resistiva: Ligada em Paralelo";
				Tipo_Carga=2;

			}// FIM DO CASO 1 PARALELO

			/* CASO 2 PARALELO */
			// NAO PODE HAVER CONEXAO EM I(JA TRATADO)
			// PELO MENOS 1 CONEXAO EM F e J
			// SE G TEM SOMENTE IMPAR H TEM SOMENTE PAR
			// SE G TEM SOMENTE PAR H TEM SOMENTE IMPAR
			// ((G IMPAR E H PAR) OU (G PAR E H IMPAR)) E (TEM UMA F) E (TEM UMA J)
			if ((((Matriz[7,9]==1 && Matriz[7,11]==1 && Matriz[7,13]==1)// F IMPAR E J PAR
			      && (Matriz[8,10]==1 && Matriz[8,12]==1 && Matriz[8,14]==1)
			      && (Matriz[7,10]!=1 && Matriz[7,12]!=1 && Matriz[7,14]!=1)
			      && (Matriz[8,9]!=1 && Matriz[8,11]!=1 && Matriz[8,13]!=1)
			      ) || //F PAR J IMPAR 
			     ((Matriz[7,10]==1 && Matriz[7,12]==1 && Matriz[7,14]==1)
			 && (Matriz[8,9]==1 && Matriz[8,11]==1 && Matriz[8,13]==1)
			 && (Matriz[7,9]!=1 && Matriz[7,11]!=1 && Matriz[7,13]!=1)
			 && (Matriz[8,10]!=1 && Matriz[8,12]!=1 && Matriz[8,14]!=1)
			 	))// FIM DO OU
			 // GARANTIR QUE HA PELO MENOS UMA CONEXAO EM F E J.
			 &&(Matriz[6,9]==1 || Matriz[6,10]==1 || Matriz[6,11]==1 || Matriz[6,12]==1 || Matriz[6,13]==1 || Matriz[6,14]==1)
			 &&(Matriz[10,9]==1|| Matriz[10,10]==1 || Matriz[10,11]==1 || Matriz[10,12]==1 || Matriz[10,13]==1 || Matriz[10,14]==1 )){

				Relatorio.GetComponent<Text>().text = "Carga Resistiva: Ligada em Paralelo";
				Tipo_Carga=2;

			}// FIM DO CASO 2 PARALELO
		}// FIM DO ELSE DO VERICAR SERIE

		/* CASOS INDIVIDUAIS */
		// NAO HAVERA CONEXAO EM G
		// NAO HAVERA CONEXAO EM H
		// NAO HAVERA CONEXAO EM I
		// AS CONEXOES SERAO ESSES PARES: F9\J10, F11\J12, F13\J14, F10\J9, F12\J11, F14\F13
		// NAO PODE OCORRER DOIS PARES
		if ((Matriz [8, 9] != 1 && Matriz [8, 10] != 1 && Matriz [8, 11] != 1 && Matriz [8, 12] != 1 && Matriz [8, 13] != 1 && Matriz [8, 14] != 1)
			&& (Matriz [7, 9] != 1 && Matriz [7, 10] != 1 && Matriz [7, 11] != 1 && Matriz [7, 12] != 1 && Matriz [7, 13] != 1 && Matriz [7, 14] != 1)
			&& (Matriz [9, 9] != 1 && Matriz [9, 10] != 1 && Matriz [9, 11] != 1 && Matriz [9, 12] != 1 && Matriz [9, 13] != 1 && Matriz [9, 14] != 1)) {
			// HA APENAS UM PAR
			if ((Matriz[6,9]==1 && Matriz[6,10]!=1 && Matriz[6,11]!=1 && Matriz[6,12]!=1 && Matriz[6,13]!=1 && Matriz[6,14]!=1
			     && Matriz[10,9]!=1 && Matriz[10,10]==1 && Matriz[10,11]!=1 && Matriz[10,12]!=1 && Matriz[10,13]!=1 && Matriz[10,14]!=1)

			    ||(Matriz[6,9]!=1 && Matriz[6,10]==1 && Matriz[6,11]!=1 && Matriz[6,12]!=1 && Matriz[6,13]!=1 && Matriz[6,14]!=1
			   && Matriz[10,9]==1 && Matriz[10,10]!=1 && Matriz[10,11]!=1 && Matriz[10,12]!=1 && Matriz[10,13]!=1 && Matriz[10,14]!=1)

			    ||(Matriz[6,9]!=1 && Matriz[6,10]!=1 && Matriz[6,11]==1 && Matriz[6,12]!=1 && Matriz[6,13]!=1 && Matriz[6,14]!=1
			   && Matriz[10,9]!=1 && Matriz[10,10]!=1 && Matriz[10,11]!=1 && Matriz[10,12]==1 && Matriz[10,13]!=1 && Matriz[10,14]!=1)

			    ||(Matriz[6,9]!=1 && Matriz[6,10]!=1 && Matriz[6,11]!=1 && Matriz[6,12]==1 && Matriz[6,13]!=1 && Matriz[6,14]!=1
			   && Matriz[10,9]!=1 && Matriz[10,10]!=1 && Matriz[10,11]==1 && Matriz[10,12]!=1 && Matriz[10,13]!=1 && Matriz[10,14]!=1)

			    ||(Matriz[6,9]!=1 && Matriz[6,10]!=1 && Matriz[6,11]!=1 && Matriz[6,12]!=1 && Matriz[6,13]==1 && Matriz[6,14]!=1
			   && Matriz[10,9]!=1 && Matriz[10,10]!=1 && Matriz[10,11]!=1 && Matriz[10,12]!=1 && Matriz[10,13]!=1 && Matriz[10,14]==1)

			    ||(Matriz[6,9]!=1 && Matriz[6,10]!=1 && Matriz[6,11]!=1 && Matriz[6,12]!=1 && Matriz[6,13]!=1 && Matriz[6,14]==1
			   && Matriz[10,9]!=1 && Matriz[10,10]!=1 && Matriz[10,11]!=1 && Matriz[10,12]!=1 && Matriz[10,13]==1 && Matriz[10,14]!=1)){

				Relatorio.GetComponent<Text>().text = "Carga Resistiva: Ligada de Forma Individual";
				Tipo_Carga=3;

		}// fim do if dos pares
		}// fim do casos individuais

		/* VERIFICANDO SE O AMPERIMETRO ESTA LIGADO NA FONTE E O MOTOR ESTA LIGADO NA FONTE */
		// A VERIFICACAÇAO DA LIGAÇAO DO AMPERIMETRO COM A RESISTENCIA E DA RESISTENCIA COM O MOTOR JA FOI VERIFICADA.

		/* CASO COM UMA UNICA FONTE */
		if (fonte_serie_enable == false) {
			/* VERIFICANDO AS CONEXOES DA FONTE E DO MOTOR*/
			// FONTE NO AMPERIMETRO (A1=1 e A5=1)
			// MOTOR NA FONTE (B1=-1 e B7=-1)
			if (Matriz [1, 1] == 1 && Matriz [1, 5] == 1 && Matriz [2, 1] == -1 && Matriz [2, 7] == -1 && Tipo_Carga!=0) {
				//print ("MULTIMETRO LIGADO SIMPLES");
				A_enable=true;
			}// fim da verificaçao de conexoes
			else{// CASO NAO HABILITADO
				A_enable=false;
			}// fim do caso nao habilitado
		}// fim caso de fonte serie
		/* CASO COM DUAS FONTES EM SERIE*/
		else {
			/* VERIFICANDO AS CONEXOES DA FONTE E DO MOTOR*/
			// FONTE NO AMPERIMETRO (A1=1 e A5=1)
			// MOTOR NA SEGUNDA FONTE (C2=-1 e C7=-1)
			if (Matriz [1, 1] == 1 && Matriz [1, 5] == 1 && Matriz [3, 2] == -1 && Matriz [3, 7] == -1 && Tipo_Carga!=0){
				//print("MULTIMETRO LIGADO SERIE");
				A_enable=true;

			}// fim da verificaçao de conexoes
			else{// CASO NAO HABILITADO
				A_enable=false;
			}// fim do caso nao habilitado
		}// fim do caso das fontes em serie
	}// fim do verifica_amperimetro
	

	/*ESSA FUNCAO CHAMA AS FUNCOES QUE VERIFICA AS CONEXOES QUE SAO ORGANIZADAS EM 3 PARTES*/
	// VERIFICA A CONEXAO DA FONTE(SIMPLES OU SERIE) E VERIFICAÇAO DO VOLTIMETRO
	// VERIFICA A CONEXAO DO MILIAMPERIMETRO
	// VERIFICA A CONEXAO DO AMPERIMETRO
	// O RESULTADO SERA NAS VARIAVEIS DE CONTROLE PARA CADA FUNCAO
	void Verificar_Conexao(){
		/* VERIFICA A LIGACAO DA FONTE E DO VOLTIMETRO */
		/* RESULTADOS:
		 * fonte_serie_enable = TRUE: CASO A FONTE ESTEJA EM SERIE
		 * fonte_serie_enable = FALSE: CASO A FONTE NAO ESTEJA EM SERIE (SIMPLES)
		 * voltimetro_enable = TRUE: CASO O VOLTIMETRO ESTAJA LIGADO
		 * voltimetro_enable = FALSE: CASO O VOLTIMETRO NAO ESTAJA LIGADO
		 */
		Verifica_Conexao_Fonte ();

		/* VERIFICA A LIGACAO DO MILIAMPERIMETRO */
		/* RESULTADOS:
		 * mA_enable = TRUE: CASO O MILIAMPERIMETRO ESTEJA LIGADO
		 * mA_enable = FALSE: CASO O MILAMPERIMETRO NAO ESTEJA LIGADO
		 * Carga_do_Campo = 0: NAO HA CARGA
		 * Carga_do_Campo = 1: SERA O VALOR QUE ESTIVER MARCANDO NA CARGA
		 * Carga_do_Campo = 2: SERA O VALOR TOTAL DA CARGA
		 */
		Verifica_Mili_Amperimetro ();
	
		/* VERIFICA A LIGACAO DO AMPERIMETRO */
		/* RESULTADOS:
		 * A_enable = TRUE: CASO DO AMPERIMETRO ESTEJA LIGADO
		 * A_enable = FALSE: CASO DO AMPERIMETRO NAO ESTEJA LIGADO
		 * Tipo_Carga = 0: NAO HA CARGA LIGADA
		 * Tipo_Carga = 1: CARGA LIGADA EM SERIE
		 * Tipo_Carga = 2: CARGA LIGADA EM PARALELO
		 * Tipo_Carga = 3: CARGA LIGADA DE FORMA INDIVIDUAL
		 */
		Verifica_Amperimetro ();

	}// fim do verificar_conexao


	// SALVA EM UM ARQUIVO  ESSA FUNCAO PODE SER EXCLUIDA
	void Salvar_Matriz(){
		string[] letra = {"A","B","C","D","E","F","G","H","I","J"};
		StreamWriter wr = new StreamWriter(@"c:\pasta\arquivo.txt", false);
		wr.Write(" | 1| 2| 3| 4| 5| 6| 7| 8| 9|10|11|12|13|14|");
		wr.WriteLine ("");
		for(int i = 1;i<linha;i++){
			wr.Write (letra[i-1] +"|");
			for(int j = 1;j<coluna;j++){
				if(Matriz[i,j]<0){
				wr.Write(Matriz [i,j]+"|");
				}else{
					wr.Write(" "+Matriz [i,j]+"|");
				}
			} // fim do for j
			wr.WriteLine ("");

		}// fim do for i
		wr.Close();
	}

	// VOU EXIBIR O CABO NESSA FUNCAO, A IDEIA ERA SEMELHANTE ENTAO APROVEITA CODIGO
	// ESSA FUNCAO VERIFICA AS CONEXOES E MONTA A MATRIZ DE CONECÇOES
	void Montar_Matriz(){
		// REVIFICACAO DAS CONECÇOES
		switch (Conexao_1){
			// Variador 1
		case(1):
			switch(Conexao_2){
			case (4): // ligando  as fontes em serie!!
				Matriz[2,1]=-1;
				Matriz[2,2]=+1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("1:4");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=4;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			case(5):
				Matriz[1,1]=1;
				Matriz[1,3]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("1:5");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=5;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 5
			case(7):
				Matriz[1,1]=1;
				Matriz[1,4]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("1:7");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=7;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 7
			case(9):
				Matriz[1,1]=1;
				Matriz[1,5]=1;
				
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("1:9");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=1;
				//cabo.GetComponent<Cabos>().Conexao_2=9;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 9
			default:
				//Relatorio.GetComponent<Text>().text = "Conexao NAO permitida";
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 1
			
		case(2):
			switch (Conexao_2){
			case(3):
				Matriz[2,1]=-1;
				Matriz[2,2]=+1;
				
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:3");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=3;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 3
			case(6):
				Matriz[2,1]=-1;
				Matriz[2,3]=-1;
				
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:6");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=6;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 6
			case(12):
				Matriz[2,1]=-1;
				Matriz[2,6]=-1;
				
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:12");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 12
			case(14):
				Matriz[2,1]=-1;
				Matriz[2,7]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("2:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=2;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 14
			}//  FIM DO SWTCH 2
			break;// FIM DO CASE 2
			
		case(3):	
			switch (Conexao_2){
			case(6):
				Matriz[2,2]=+1;
				Matriz[2,3]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("3:6");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=3;
				//cabo.GetComponent<Cabos>().Conexao_2=6;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			case(12):
				Matriz[2,2]=+1;
				Matriz[2,6]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("3:12");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=3;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			case (14):
				Matriz[2,2]=+1;
				Matriz[2,7]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("3:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=3;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 3
			
		case(4):
			switch (Conexao_2){
			case(6):
				Matriz[3,2]=-1;
				Matriz[3,3]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("4:6");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=4;
				//cabo.GetComponent<Cabos>().Conexao_2=6;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			case(12):
				Matriz[3,2]=-1;
				Matriz[3,6]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("4:12");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=4;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			case(14):
				Matriz[3,2]=-1;
				Matriz[3,7]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("4:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=4;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			}//FIM DO SWITCH 2
			break;// FIM DO CASE 4
			
			//Voltimentro 
		case(5):
			switch(Conexao_2){
			case(7):
				Matriz[1,3]=1;
				Matriz[1,4]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("5:7");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=5;
				//cabo.GetComponent<Cabos>().Conexao_2=7;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 7
			case(9):
				Matriz[1,3]=1;
				Matriz[1,5]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("5:9");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=5;
				//cabo.GetComponent<Cabos>().Conexao_2=9;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 9
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 5
			
		case(6):
			switch (Conexao_2){
			case(12):
				Matriz[2,3]=-1;
				Matriz[2,6]=-1;
				
				Matriz[3,3]=-1;
				Matriz[3,6]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("6:12");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=6;
				//cabo.GetComponent<Cabos>().Conexao_2=12;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;
			case (14):
				Matriz[2,3]=-1;
				Matriz[2,7]=-1;
				
				Matriz[3,3]=-1;
				Matriz[3,7]=-1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("6:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=6;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;

			}// FIM DO SWITCH 2
			break;// FIM DO CASE 6
			
			// Amperimetro 1A 
		case(7):
			switch(Conexao_2){
			case(9):
				Matriz[1,4]=1;
				Matriz[1,5]=1;
				
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("7:9");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=7;
				//cabo.GetComponent<Cabos>().Conexao_2=9;
				// REMOVE O REALCE DO BORNE
				Desativa_Realce();

				break;// FIM DO CASE 9
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 7
			
		case(8):
			switch(Conexao_2){
			case(15):
				Matriz[4,4]=-1;
				Matriz[4,8]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("8:15");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=8;
				//cabo.GetComponent<Cabos>().Conexao_2=15;
				Desativa_Realce();

				break;
			case(16):
				Matriz[4,4]=-1;
				Matriz[4,8]=2;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("8:16");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=8;
				//cabo.GetComponent<Cabos>().Conexao_2=16;
				Desativa_Realce();

				break;
			case(17):
				Matriz[4,4]=-1;
				Matriz[4,8]=3;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("8:17");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=8;
				//cabo.GetComponent<Cabos>().Conexao_2=17;
				Desativa_Realce();

				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 8
			
		case(10):
			switch(Conexao_2){
			case(13):// AMPERIMETRO DIRETO NO MOTOR
				Matriz[7,5]=1;
				Matriz[7,7]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:13");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=13;
				Desativa_Realce();

				break;
			case(18):
				Matriz[6,5]=1;
				Matriz[6,9]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:18");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=18;
				Desativa_Realce();

				break;
			case(19):
				Matriz[6,5]=1;
				Matriz[6,10]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:19");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=19;
				Desativa_Realce();

				break;
			case(20):
				Matriz[6,5]=1;
				Matriz[6,11]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativa_Realce();

				break;
			case(21):
				Matriz[6,5]=1;
				Matriz[6,12]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativa_Realce();

				break;
			case(22):
				Matriz[6,5]=1;
				Matriz[6,13]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativa_Realce();

				break;
			case(23):
				Matriz[6,5]=1;
				Matriz[6,14]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("10:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=10;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativa_Realce();

				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 10
			
		case(11):
			switch(Conexao_2){
			case(15):
				Matriz[5,6]=1;
				Matriz[5,8]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("11:15");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=11;
				//cabo.GetComponent<Cabos>().Conexao_2=15;
				Desativa_Realce();

				break;
			case(16):
				Matriz[5,6]=1;
				Matriz[5,8]=2;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("11:16");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=11;
				//cabo.GetComponent<Cabos>().Conexao_2=16;
				Desativa_Realce();

				break;
			case(17):
				Matriz[5,6]=1;
				Matriz[5,8]=3;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("11:17");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=11;
				//cabo.GetComponent<Cabos>().Conexao_2=17;
				Desativa_Realce();

				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 11
			
		case(12):
			switch (Conexao_2){
			case (14):
				Matriz[2,6]=-1; // ponto B
				Matriz[2,7]=-1; // ponto B
				
				Matriz[3,3]=-1; // Ponto C
				Matriz[3,7]=-1; // Ponto C

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("12:14");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=12;
				//cabo.GetComponent<Cabos>().Conexao_2=14;
				Desativa_Realce();

				break;
			}// FIM DO SWITCH
			break;// FIM DO CASE 12
			
		case(13):
			switch(Conexao_2){
			case(18):
				Matriz[10,7]=1;
				Matriz[10,9]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:18");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=18;
				Desativa_Realce();

				break;
			case(19):
				Matriz[10,7]=1;
				Matriz[10,10]=1;
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:19");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=19;
				Desativa_Realce();

				break;
			case(20):
				Matriz[10,7]=1;
				Matriz[10,11]=1;
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativa_Realce();
				break;
			case(21):
				Matriz[10,7]=1;
				Matriz[10,12]=1;

				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativa_Realce();

				break;
			case(22):
				Matriz[10,7]=1;
				Matriz[10,13]=1;
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativa_Realce();

				break;
			case(23):
				Matriz[10,7]=1;
				Matriz[10,14]=1;
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("13:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=13;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativa_Realce();

				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 13

		/*
		case(16):
			switch(Conexao_2){
			case(17):
				Matriz[4,8]=1; //Ponto D
				Matriz[5,8]=1; //Ponto E
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 16
		*/
			// CONEXOES DA CARGA RESISTIVA
			// PARES: PONTO G
			// IMPARES: PONTO H
			// DIFERENTES: PONTO I
		case(18):
			switch(Conexao_2){
			case(19):
				//print("ERRO");
				//EXIBE CABO
				//cabo = GameObject.FindGameObjectWithTag("18:19");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				////cabo.GetComponent<Cabos>().Conexao_1=18;
				////cabo.GetComponent<Cabos>().Conexao_2=19;
				Desativa_Realce();

				break;
				
			case(20):
				Matriz[7,9]=1;//ponto G
				Matriz[7,11]=1;//ponto G
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativa_Realce();
				break;
				
			case(21):
				Matriz[9,9]=1;//ponto I
				Matriz[9,12]=-1;//ponto I
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativa_Realce();
				break;
				
			case(22):
				Matriz[7,9]=1;//ponto G
				Matriz[7,13]=1;//ponto G
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativa_Realce();
				break;
				
			case(23):
				Matriz[9,9]=1;//ponto I
				Matriz[9,14]=1;//ponto I
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("18:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=18;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativa_Realce();
				break;

			}// FIM DO SWITCH 2
			break;// FIM DO CASE 18
			
		case(19):
			switch(Conexao_2){
			case(20):
				Matriz[9,10]=1;//ponto I
				Matriz[9,11]=1;//POnto I
				//EXIBE CABO
				cabo = GameObject.FindGameObjectWithTag("19:20");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=20;
				Desativa_Realce();
				break;
				
			case(21):
				Matriz[8,10]=1;//ponto H
				Matriz[8,12]=1;//POnto H

				cabo = GameObject.FindGameObjectWithTag("19:21");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativa_Realce();
				break;
				
			case(22):
				Matriz[9,10]=1;//ponto I
				Matriz[9,13]=1;//POnto I

				cabo = GameObject.FindGameObjectWithTag("19:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativa_Realce();
				break;
				
			case(23):
				Matriz[8,10]=1;//ponto H
				Matriz[8,14]=1;//POnto H

				cabo = GameObject.FindGameObjectWithTag("19:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=19;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativa_Realce();
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 19
			
		case(20):
			switch(Conexao_2){
			case (21):
				//print("ERRO");
				//cabo = GameObject.FindGameObjectWithTag("20:21");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				////cabo.GetComponent<Cabos>().Conexao_1=20;
				////cabo.GetComponent<Cabos>().Conexao_2=21;
				Desativa_Realce();
				break;

			case(22):
				Matriz[7,11]=1;//ponto G
				Matriz[7,13]=1;//POnto G
				cabo = GameObject.FindGameObjectWithTag("20:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=20;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativa_Realce();

				break;
				
			case(23):
				Matriz[9,11]=1;//ponto I
				Matriz[9,14]=1;//POnto I
				cabo = GameObject.FindGameObjectWithTag("20:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=20;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativa_Realce();
				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 20
			
		case(21):
			switch(Conexao_2){
			case(22):
				Matriz[9,12]=1;//Ponto I
				Matriz[9,13]=1;//Ponto I
				cabo = GameObject.FindGameObjectWithTag("21:22");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=21;
				//cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativa_Realce();
				break;
				
			case(23):
				Matriz[8,12]=1;//Ponto H
				Matriz[8,14]=1;//Ponto H

				cabo = GameObject.FindGameObjectWithTag("21:23");
				cabo.GetComponent<Cabos>().Hide_Show=true;
				//cabo.GetComponent<Cabos>().Conexao_1=21;
				//cabo.GetComponent<Cabos>().Conexao_2=23;
				Desativa_Realce();

				break;
			}// FIM DO SWITCH 2
			break;// FIM DO CASE 21

		case(22):
			switch(Conexao_2){
			case(23):
				//print("ERRO");
				//cabo = GameObject.FindGameObjectWithTag("21:22");
				//cabo.GetComponent<Cabos>().Hide_Show=true;
				////cabo.GetComponent<Cabos>().Conexao_1=21;
				////cabo.GetComponent<Cabos>().Conexao_2=22;
				Desativa_Realce();
				break;
			}
			break; // FIM DO CASE 22

		}// FIM DO SWITCH 1
		Desativa_Realce();
	}// FIM DA FUNCAO MONTAR MATRIZ


	/*
	 * ESSA FUNCAO VERIFICA QUAL O BORNE FOI SELECIONADO 
	 * TAMBEM REALÇA O BORNE SELECIONADO
	 */
	int Conectar(){

		if (B_DC_MAIS_1.GetComponent<Borne> ().clique == true) {
			B_DC_MAIS_1.GetComponent<Borne> ().realce = true;// realçar
			B_DC_MAIS_1.GetComponent<Borne> ().clique = false;
			return 1;
		
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
	}// fim da funcao 

	// DESATIVA TODOS OS REALCES DOS BORNES
	void Desativa_Realce(){
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
	
		
	
}// fim da classe