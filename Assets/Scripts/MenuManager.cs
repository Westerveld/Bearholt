using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public GameObject infoBox;

	public void PlayGame(){
		Application.LoadLevel ("main");
	}

	public void loadInfo(){
		infoBox.SetActive (true);
	}

	public void closeInfo(){
		infoBox.SetActive (false);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
