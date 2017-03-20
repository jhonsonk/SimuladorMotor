using UnityEngine;
using System.Collections;

public class Dijuntor : MonoBehaviour {
	public bool ligado=false;
	
	// Incia a possiçao inicial "Desligado"
	void Start () {
		gameObject.GetComponent<Renderer>().transform.Rotate (60, 0, 0);
		
	}
	
	
	// Caso o mouse clique
	void OnMouseDown()
	{

		// modo ligado
		if (ligado == false) {
			gameObject.GetComponent<Renderer>().transform.Rotate (-70, 0,0);
			ligado = true;
			
			// modo desligado 
		} else {
			gameObject.GetComponent<Renderer>().transform.Rotate (70, 0, 0);
			ligado = false;
		}
	}
	
	
	
}
