using UnityEngine;
using System.Collections;

// conferir se pode ser apagada essa classe

public class Carga_Resistiva : MonoBehaviour {

	// Use this for initialization

	public GameObject Seletora;
	//public GameObject Borne_1;
	//public GameObject Borne_2;
	//public GameObject Borne_3;
	//public GameObject Borne_4;
	//public GameObject Borne_5;
	//public GameObject Borne_6;

	int possicao_chave;

	int R1=180;
	int R2=90;
	int R3=60;
	int R4=45;
	int R5=36;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		possicao_chave = Seletora.GetComponent<Chave_Seletora> ().posicao;
		//Debug.Log (possicao_chave);
	
	}
}
