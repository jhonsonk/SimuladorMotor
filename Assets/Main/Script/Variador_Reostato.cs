using UnityEngine;
using System.Collections;

public class Variador_Reostato : MonoBehaviour {

	/* Essa Classe soh trata o variador do reostado */

	public int Status;// Essa variavel eh atualizada pela classe botao
	public float Variador_Valor=1;

		void Update () {
		if (gameObject.name.Equals ("Variador")) {

			if (Status == 1&&Variador_Valor<120) {// Sentido positivo
				gameObject.GetComponent<Renderer> ().transform.Rotate (0, 0, 1.83f);
				Variador_Valor = Variador_Valor + 1;

			} else if (Status == -1&&Variador_Valor>0) {// sentido negativo
				gameObject.GetComponent<Renderer> ().transform.Rotate (0, 0, -1.83f);
				Variador_Valor = Variador_Valor - 1;

			} else {// Caso parado
				gameObject.GetComponent<Renderer> ().transform.Rotate (0, 0, 0);	
			}
			
		}

		if (gameObject.name.Equals("Variador_Reostato")){
			if (Status == 1&&Variador_Valor<1000) {// Sentido positivo
				gameObject.GetComponent<Renderer> ().transform.Rotate (0, 0, 1.5f);
				Variador_Valor = Variador_Valor + 5;

			} else if (Status == -1&&Variador_Valor>1) {// sentido negativo
				gameObject.GetComponent<Renderer> ().transform.Rotate (0, 0, -1.5f);
				Variador_Valor = Variador_Valor - 5;

			} else {// Caso parado
				gameObject.GetComponent<Renderer> ().transform.Rotate (0, 0, 0);	
			}

		}// fim reostato


	//
	}

}