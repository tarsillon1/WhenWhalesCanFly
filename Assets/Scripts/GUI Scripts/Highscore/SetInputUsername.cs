using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetInputUsername : MonoBehaviour {
	private bool fadeOut;
	private Transform ui;
	public Transform newHighscoreUI;

	public void setUser(){
		this.GetComponentInParent<HighscoreScreen> ().setUsername (this.transform.GetChild(1).GetComponent<InputField> ().text);
		fadeOut = true;
	}

	void Update(){
		if (fadeOut) {
			this.GetComponent<CanvasGroup> ().alpha = this.GetComponent<CanvasGroup> ().alpha - 0.02f;
			if (this.GetComponent<CanvasGroup> ().alpha <= 0) {
				ui = (Transform)Instantiate (newHighscoreUI, new Vector3 (0, 0, 90), Quaternion.identity);
				ui.SetParent (this.transform.parent);
				ui.localScale = new Vector3 (1, 1, 1);
				ui.localPosition = new Vector3 (0, 0, 0);
				ui.GetChild (1).GetComponent<Text> ().text = this.GetComponentInParent<HighscoreScreen> ().getScore ().ToString ();
				this.GetComponentInParent<HighscoreScreen> ().setHighscore ();
				ui.GetComponent<CanvasGroup> ().alpha = 0;
				fadeOut = false;
			}
		} else if(ui != null){
			ui.GetComponent<CanvasGroup> ().alpha = ui.GetComponent<CanvasGroup> ().alpha + 0.02f;
			if(ui.GetComponent<CanvasGroup>().alpha == 1f){
				Destroy(this.gameObject);
			}
		}
	}
}
