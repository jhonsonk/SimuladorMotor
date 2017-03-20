using UnityEngine;
using System.Collections;

/* A Classe verifica se o dijuntor esta acionado juntamento com o acionamento SEPARADO
 * Se o dijuntor nao estiver acionado nada eh acionado 
 * O acionamento separado ativa e desativa as saidas
 * Retorno:
 * Acionado_R2 = true: se o dijuntor e o acionamento estao ativos
 * Acionado_S2 = true: se o dijuntor geral, o dijunto 127V e o acionamento estao ativos
 * Acionado_T2 = true: se o dijuntor geral, o dijunto 220V e o acionamento estao ativos
 */

public class Acionamento_Separado : MonoBehaviour {

	// Objetos que fazem parte da interreçao
	public GameObject Dijuntor;
	public GameObject B_Acionado;
	public GameObject Lamp_Acionada;
	public GameObject Lamp_Botao;

	// Objetos dos bornes
	public GameObject Borner_R2;
	public GameObject Borner_S2;
	public GameObject Borner_T2;

	// Variaveis de estado 
	public bool Dijuntor_Estado=false;
	public bool B_Acionado_Estado=false;

	// Variaveis dos bornes
	public bool Borner_R2_Estado = false;
	public bool Borner_S2_Estado = false;
	public bool Borner_T2_Estado = false;

	// Variaveis de saida
	public bool Acionado_R2 = false;
	public bool Acionado_S2 = false;
	public bool Acionado_T2 = false;

	// Update is called once per frame
	void Update () {
		Dijuntor_Estado = Dijuntor.GetComponent<Dijuntor> ().ligado;
		B_Acionado_Estado = B_Acionado.GetComponent<Botao_Ligar> ().Ligado;

		if (Dijuntor_Estado == true) {
			if(B_Acionado_Estado==true){
				Lamp_Acionada.GetComponent<Renderer> ().enabled = true;
				Lamp_Botao.GetComponent<Renderer> ().enabled = true;
				Acionado_R2 = true;
				Acionado_S2 = true;
				Acionado_T2 = true;

			}else{
				Lamp_Acionada.GetComponent<Renderer> ().enabled = false;
				Lamp_Botao.GetComponent<Renderer> ().enabled = false;
				Acionado_R2 = false;
				Acionado_S2 = false;
				Acionado_T2 = false;
			}// fim 
		
		} else {
			Lamp_Acionada.GetComponent<Renderer> ().enabled = false;
			Lamp_Botao.GetComponent<Renderer> ().enabled = false;
			B_Acionado.GetComponent<Botao_Ligar> ().Ligado= false;
			Acionado_R2 = false;
			Acionado_S2 = false;
			Acionado_T2 = false;
		}// Desligar tudo

	
	}
}
