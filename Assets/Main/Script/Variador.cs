using UnityEngine;
using System.Collections;

public class Variador : MonoBehaviour {

	///public GameObject variador;

	public int Status;// Essa variavel eh atualizada pela classe botao
	public float Variador_Valor=0;

	//void Start (){
	    // variador.GetComponent<Renderer> ().transform.Rotate (0, 0, -7);
	//}

	void Update () {

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
}
