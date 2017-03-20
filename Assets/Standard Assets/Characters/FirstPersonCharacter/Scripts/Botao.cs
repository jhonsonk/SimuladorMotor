using UnityEngine;
using System.Collections;

/* Este script trada dos eventos relacionados
 * aos botoes de aumentar e diminuir */

public class Botao : MonoBehaviour {
	public bool click=false;

	void Start () {
		//inicia o botao com a cor preta
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
	}

	/*Quando o botao for precionado*/
	void OnMouseDown()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.red;
		click = true;
	}
	/*Quando o botao for desprecionado*/
	void OnMouseUp(){
		gameObject.GetComponent<Renderer>().material.color = Color.blue;
		click = false;
	}
}
