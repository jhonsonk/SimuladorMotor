using UnityEngine;
using System.Collections;

public class Botao_Desligar : MonoBehaviour {
	public bool Ligado;
	public GameObject Bot_Ligar;

	/*Quando o botao for precionado*/
	void OnMouseDown()
	{
		Ligado = false;
		Bot_Ligar.GetComponent<Botao_Ligar>().Ligado =false;
	}
}
