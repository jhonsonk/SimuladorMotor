using UnityEngine;
using System.Collections;

public class Botao_Ligar : MonoBehaviour {
	public bool Ligado;
	public GameObject Bot_Desligar;

	/*Quando o botao for precionado*/
	void OnMouseDown()
	{
		Ligado = true;
		Bot_Desligar.GetComponent<Botao_Desligar>().Ligado =true;
	}
}
