using UnityEngine;
using System.Collections;

public class Chave_Seletora : MonoBehaviour {

	//public GameObject Chave;

	public int posicao=0;
	int sentido=1;

	// Sao 5 possiçoes cada possiçao 28*5 = 140
	void Start () {
		gameObject.GetComponent<Renderer> ().transform.Rotate (0,0,-85);	
	}
	
	// Update is called once per frame
	void Update () {
		//if (possicao==0){

		}
	void OnMouseDown(){
		if(sentido==1){
			posicao = posicao+1;
			gameObject.GetComponent<Renderer> ().transform.Rotate (0,0,28);
			if (posicao==5){sentido=-1;}

		} else if (sentido==-1){
			posicao = posicao-1;
			gameObject.GetComponent<Renderer> ().transform.Rotate (0,0,-28);
			if (posicao==0){sentido=1;}

		}

	}


}
