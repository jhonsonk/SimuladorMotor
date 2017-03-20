using UnityEngine;
using System.Collections;


// CLASSE PRINCIPAL QUE CONTROLA O VARIADOR.
public class Variador_de_Tensao : MonoBehaviour {

	public GameObject Dijuntor;
	public GameObject Lamp_Energizado;
	public GameObject Variador;
	public GameObject Acionamento;

	//public GameObject DC_Mais;
	//public GameObject DC_Menos;
	//public GameObject AC1;
	//public GameObject AC2;

	/*PRECISO DEFINIR COMO FAZER PARA OS DOIS CASOS*/
	//public GameObject DC24_Mais;
	//public GameObject DC24_Menos;

	public bool Dijuntor_Estado = false;
	private bool Acionamento_Estado = false;
	public float Variador_Valor = 0; //ESSE EH O VALOR DA TENSAO A SER PASSADO

	// Use this for initialization
	void Start () {
		Lamp_Energizado.GetComponent<Renderer>().enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		// Pegar os valores de inicializacao
		Dijuntor_Estado = Dijuntor.GetComponent<Dijuntor> ().ligado;
		Acionamento_Estado = Acionamento.GetComponent<Acionamento_Geral> ().Acionado_Geral;

		// verificar se esta ativo o dijuntor e pega o valor da tensao
		if (Dijuntor_Estado == true&&Acionamento_Estado==true) {

			Lamp_Energizado.GetComponent<Renderer> ().enabled = true;
			Variador_Valor = Variador.GetComponent<Variador_Reostato> ().Variador_Valor;

			//DESATIVAR A SAIDA
		} else {
			Lamp_Energizado.GetComponent<Renderer> ().enabled = false;
			Variador_Valor = 0;

		}


	}
}
