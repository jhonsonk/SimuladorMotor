using UnityEngine;
using System.Collections;

/* A Classe verifica se os dijuntores estao acionados juntamento com o acionamento Geral
 * Se o dijuntor geral nao estiver acionado nada eh acionado 
 * O acionamento geral ativa e desativa as saidas
 * Retorno:
 * Acionado_Geral = true: se o dijuntor geral e o acionamento estao ativos
 * Acionado_127V = true: se o dijuntor geral, o dijunto 127V e o acionamento estao ativos
 * Acionado_220V =true: se o dijuntor geral, o dijunto 220V e o acionamento estao ativos
 */
public class Acionamento_Geral : MonoBehaviour {

	// Objetos que fazem parte da interreçao
	public GameObject D_Geral;
	public GameObject D_220V;
	public GameObject D_127V;
	public GameObject B_Acionamento;

	// Objetos das lampadas
	public GameObject Lamp_Energizada;
	public GameObject Lamp_Acionada;
	public GameObject Lamp_220V;
	public GameObject Lamp_127V;
	public GameObject Lamp_Botao;

	// Variaveis de estado 
	bool D_Geral_Estado = false;
	bool D_220V_Estado = false;
	bool D_127V_Estado = false;
	bool B_Acionamento_Estado = false;
	// Variaveis de saida
	public bool Acionado_Geral = false;
	public bool Acionado_127V = false;
	public bool Acionado_220V = false;

	// Funcao de atualizacao padrao
	void Update () {

		//Pega o estado dos objetos verificando os dijuntores
		D_Geral_Estado = D_Geral.GetComponent<Dijuntor>().ligado;
		D_220V_Estado = D_220V.GetComponent<Dijuntor>().ligado;
		D_127V_Estado = D_127V.GetComponent<Dijuntor>().ligado;
		B_Acionamento_Estado = B_Acionamento.GetComponent<Botao_Ligar> ().Ligado;

		/* Verifica se os dinjuntores estao ativos ou nao*/
		if (D_Geral_Estado == true) {
			Lamp_Energizada.GetComponent<Renderer> ().enabled = true;
			if (B_Acionamento_Estado==true){
				Lamp_Acionada.GetComponent<Renderer> ().enabled = true;
				Lamp_Botao.GetComponent<Renderer> ().enabled = true;
				Acionado_Geral = true;
				if (D_127V_Estado == true) {
					Lamp_127V.GetComponent<Renderer> ().enabled = true;
					Acionado_127V = true;
				}else{
					Lamp_127V.GetComponent<Renderer> ().enabled = false;
					Acionado_127V = false;
				}// fim do else
				if (D_220V_Estado == true) {
					Lamp_220V.GetComponent<Renderer> ().enabled = true;
					Acionado_220V = true;
				} else {
					Lamp_220V.GetComponent<Renderer> ().enabled = false;
					Acionado_220V = false;
				}// fim do else
			} else{
				Lamp_Acionada.GetComponent<Renderer> ().enabled = false;
				Lamp_127V.GetComponent<Renderer> ().enabled = false;
				Lamp_220V.GetComponent<Renderer> ().enabled = false;
				Lamp_Botao.GetComponent<Renderer> ().enabled = false;

				Acionado_Geral = false;
				Acionado_127V = false;
				Acionado_220V = false;
			}// fim do else
		} else {
			Lamp_Energizada.GetComponent<Renderer> ().enabled = false;
			Lamp_Acionada.GetComponent<Renderer> ().enabled = false;
			Lamp_220V.GetComponent<Renderer> ().enabled = false;
			Lamp_127V.GetComponent<Renderer> ().enabled = false;
			Lamp_Botao.GetComponent<Renderer> ().enabled = false;
			B_Acionamento.GetComponent<Botao_Ligar>().Ligado = false;

			Acionado_Geral = false;
			Acionado_127V = false;
			Acionado_220V = false;
		}// fim do else
	}// Fim do Update
}// Fim da Classe
