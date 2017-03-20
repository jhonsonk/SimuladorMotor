using UnityEngine;
using System.Collections;

/* O amperimetro tem dois casos que mede de 0 a 5A e outro que mede de 0 a 1A*/
/* O valor de corrente sera passado pela classe de conexao*/
public class Amperimetro : MonoBehaviour {

	public float corrente;
	private float new_corrente;
	
	void Update () {

		//Para Corrente ate 5A
		if (this.transform.name=="Ponteiro_5A"){
			if (corrente>=new_corrente&&new_corrente<5.2){
				new_corrente=new_corrente+.11f;
				transform.Rotate (0,0,2f);
			} 
			if (corrente<=new_corrente&&new_corrente>-0.3){
				new_corrente=new_corrente-.11f;
				transform.Rotate (0,0,-2f);
			}
		}// fim do if nome 5A

		// para Corrente ate 1A
		if (this.transform.name=="Ponteiro_1A"){
			if (corrente>=new_corrente&&new_corrente<1.07f){
				new_corrente=new_corrente+.011f;
				transform.Rotate (0,0,1f);
			} 
			if (corrente<=new_corrente&&new_corrente>-0.06){
				new_corrente=new_corrente-.011f;
				transform.Rotate (0,0,-1f);
			}
		}// fim do if nome 1A
	
	}
}
