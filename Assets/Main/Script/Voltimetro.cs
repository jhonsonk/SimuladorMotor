using UnityEngine;
using System.Collections;

public class Voltimetro : MonoBehaviour {

	// Use this for initialization
	public float tensao;
	private float new_tensao;

	
	// Update is called once per frame
	void Update () {

		if (tensao>=new_tensao && new_tensao<265){
			new_tensao=new_tensao+5.50f;
			transform.Rotate (0,0,2f);
		} 
		if (tensao<=new_tensao&& new_tensao>-15){
			new_tensao=new_tensao-5.50f;
			transform.Rotate (0,0,-2f);
		}
	}// fim do up
}// fim da classe
