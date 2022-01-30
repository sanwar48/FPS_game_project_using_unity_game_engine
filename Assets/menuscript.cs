using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuscript : MonoBehaviour {



	public void PlayGame(){
		SceneManager.LoadScene ("lv_1");
	
	}

	public void QuitGame(){

		Debug.Log ("QUIT !");
		Application.Quit ();

	}
}
