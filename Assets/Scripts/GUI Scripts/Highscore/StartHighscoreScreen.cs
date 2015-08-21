using UnityEngine;
using System.Collections;

public class StartHighscoreScreen : MonoBehaviour
{
	public Transform usernameUI;
	public Transform normalScoreUI;
	public Transform newHighscoreUI;
	public DatabaseClient dataBase;

	void Start ()
	{
		GetComponent<CanvasGroup> ().alpha = 0f;
		this.GetComponent<Canvas> ().worldCamera = Camera.main;
		StartCoroutine (startScreen ());
	}
	
	IEnumerator startScreen(){
		yield return new WaitForSeconds (1);
		HighscoreScreen hs = this.gameObject.AddComponent<HighscoreScreen> ();
		hs.usernameUI = usernameUI;
		hs.normalScoreUI = normalScoreUI;
		hs.newHighscoreUI = newHighscoreUI;
		hs.dataBase = dataBase;
		Destroy (this);
	}
}

