using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {


	public void Pratica_Motor_Shunt (){
		Application.LoadLevel ("Pratica_Motor_Shunt");

	}

	public void Tela_Principal (){
		Application.LoadLevel ("Menu_Inicial");
	}

	public void Sair (){
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
		#endif
		
		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
	public void Show(GameObject panel){
		panel.SetActive (true);

	}

	public void Hide(GameObject panel){
		panel.SetActive (false);
	}

	public void Hide_Show_canvas (GameObject panel) {
		if (panel.GetComponent<Canvas> ().enabled) {
			panel.GetComponent<Canvas> ().enabled = false;
		} else {
			panel.GetComponent<Canvas> ().enabled = true;
		}
	
	}

	public void Hide_Show (GameObject panel){
		
		if (panel.activeSelf) {
			panel.SetActive (false);
			
		} else {
			panel.SetActive (true);
		}
	
	}
}
