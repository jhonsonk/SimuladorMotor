using UnityEngine;
using System.Collections;


/* Clique do botao esquerdo mouse no borne,
 * verifica a colisao do mouse com o borne,
 * 
 */
public class Borne : MonoBehaviour {

	// Use this for initialization

	public float Valor;
	//public bool Status;
	public bool clique;
	public bool realce;
	Component halo;


	void Start () {
		clique = false;
		realce = false;
		halo = GetComponent ("Halo");
	}
	
	// Update is called once per frame
	void Update () {

		if (realce == true) {
			halo.GetType ().GetProperty ("enabled").SetValue (halo, true, null);
	
		} else if (realce==false){
			halo.GetType ().GetProperty ("enabled").SetValue (halo, false, null);
		}
	}

	void OnMouseUp(){
		clique = true;
	}
}
