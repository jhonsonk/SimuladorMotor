using UnityEngine;
using System.Collections;

public class Selecionar_Deletar : MonoBehaviour {

	public bool selecionado;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)){
			selecionado=false;
			this.GetComponent<Renderer> ().material.SetFloat("_Outline", .000f);
		}
	
	}

	void OnMouseDown(){

		// SELECIONA A CORDA
		if (selecionado == false) {
			selecionado = true;
			string nome = this.name;

			if (nome == "11:15ob"||nome == "11:16ob"||nome == "11:17ob"|| nome == "8:15ob"||nome == "8:16ob"||nome == "8:17ob"||
			    nome == "10:18ob"||nome == "10:19ob"||nome == "10:20ob" || nome == "10:21ob"||nome == "10:22ob"||nome == "10:23ob"||
			    nome == "13:18ob"||nome == "13:19ob"||nome == "13:20ob" || nome == "13:21ob"||nome == "13:22ob"||nome == "13:23ob"){ // CASOS ESPECIAIS, CABOS QUE DERAM PROBLEMA
				this.GetComponent<Renderer> ().material.SetFloat ("_Outline", .004f);
			}else{
				this.GetComponent<Renderer> ().material.SetFloat ("_Outline", .01f);
			}

		} else { // REMOVE A SELECAO
			selecionado=false;
			this.GetComponent<Renderer> ().material.SetFloat("_Outline", .000f);
		}

	}// fim do onmoudedown
}
