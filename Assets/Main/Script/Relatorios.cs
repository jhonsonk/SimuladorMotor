using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Relatorios : MonoBehaviour {
	
	// Use this for initialization
	public string te;
	Text texto;
	private GameObject game;

	void Start (){
		texto = gameObject.GetComponent<Text> ();
		texto.text = te;
	}
	
	// Update is called once per frame
	void Update () {
	//	cont++;
		//text.text = "TESTE" + cont;
		texto.text=te;

	}
}