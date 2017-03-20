/* Nome: JHONSON DE SOUZA RODRIGUES
 * Revisado:02/06/2006
 * versão: 4.1
 */
using UnityEngine;
using System.Collections;

public class Cabos : MonoBehaviour {

	public bool Hide_Show;
	public bool selecionado;

	// Use this for initialization
	void Start () {
		Hide_Show = false;
		selecionado = false;
	}
	
	// Update is called once per frame
	void Update () {
		int qtd_child = transform.childCount;
		selecionado = transform.GetChild(2).GetComponent<Selecionar_Deletar>().selecionado;// recebe a informaçao do filho

		// envia a mensagem do relatorio
		if (selecionado){
			GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [0] = 1;			
		}


		// Exibe o cabo
		if (Hide_Show==true){
			transform.GetChild(0).GetComponent<Renderer>().enabled=true;
			transform.GetChild(1).GetComponent<Renderer>().enabled=true;
			transform.GetChild(2).GetComponent<Renderer>().enabled=true;
			transform.GetChild(2).GetComponent<MeshCollider>().enabled=true;

			// envia a mensagem do relatorio
			if (GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [19] == 0){
				GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [19] = 1;
			}

			if (qtd_child==4){
				transform.GetChild(3).GetComponent<Renderer>().enabled=true;
			}
		
		// oculta o cabo
		}else if (Hide_Show==false){
			transform.GetChild(0).GetComponent<Renderer>().enabled=false;
			transform.GetChild(1).GetComponent<Renderer>().enabled=false;
			transform.GetChild(2).GetComponent<Renderer>().enabled=false;
			transform.GetChild(2).GetComponent<MeshCollider>().enabled=false;
			transform.GetChild (2).GetComponent<Renderer> ().material.SetFloat("_Outline", .000f);
			if (qtd_child==4){
				transform.GetChild(3).GetComponent<Renderer>().enabled=false;
				transform.GetChild (2).GetComponent<Renderer> ().material.SetFloat("_Outline", .000f);
			}
		}// fim do else de ocultar

		// EXCLUI CASO SELECIONADO
		if (selecionado == true && Input.GetKey(KeyCode.Delete) ){
			Hide_Show= false;
			transform.GetChild(2).GetComponent<Selecionar_Deletar>().selecionado=false;// recebe a informaçao do filho
			GameObject.FindGameObjectWithTag ("bancada").GetComponent<Pratica_motor_shunt> ().mensagem [0] = 3;	
		}
	
	}// fim do up
		
}// fim da clasee
