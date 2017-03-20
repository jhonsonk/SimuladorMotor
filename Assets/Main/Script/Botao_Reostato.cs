using UnityEngine;
using System.Collections;

public class Botao_Reostato : MonoBehaviour {

	public GameObject Variador;
	public GameObject Botao_Inverso;

	public int Status=0;
	public bool click=false;

	void OnMouseDown(){

		gameObject.GetComponent<Renderer> ().material.color = Color.red;
		Variador.GetComponent<Variador_Reostato>().Status = 0;

		if (gameObject.name == "Botao_Menos"&&click==false) {
			Variador.GetComponent<Variador_Reostato>().Status = -1;
			Botao_Inverso.GetComponent<Botao_Reostato>().Status=-1;

		} else if (gameObject.name == "Botao_Mais"&&click==false) {
			Variador.GetComponent<Variador_Reostato>().Status = 1;
			Botao_Inverso.GetComponent<Botao_Reostato>().Status=1;

		}
	}

	void OnMouseUp (){
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
		Variador.GetComponent<Variador_Reostato>().Status = 0;
		Botao_Inverso.GetComponent<Botao_Reostato>().Status=0;

	}
}
