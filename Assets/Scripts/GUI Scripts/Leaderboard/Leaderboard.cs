using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour {
	public Transform[] colum = new Transform[10];
	private DatabaseClient dataBase;
	private LeaderBoard[] leaderInfo = new LeaderBoard[10];
	private int page = 1;
	private int placeholder = 1;
	private bool fadeText;

	public void nextPage(){
		placeholder ++;
		fadeText = true;
	}

	public void backPage(){
		if (placeholder != 1) {
			placeholder --;
			fadeText = true;
		}
	}

	void Start () {
		for (int i = 0; i < 10; i++) 
			leaderInfo[i] = new LeaderBoard();
        dataBase = GameObject.FindGameObjectWithTag("Database").GetComponent<DatabaseClient>();
		loadPage ();
	}

	void loadPage(){
		leaderInfo = null;
		StartCoroutine(dataBase.setPage(placeholder));
	}

	void Update () {
		if (fadeText && colum [0].GetComponent<CanvasGroup> ().alpha >= 0.01) {
			for (int i = 0; i < 10; i++) {
				colum [i].GetComponent<CanvasGroup>().alpha -= 0.05f;
			}
		} else if(colum [0].GetComponent<CanvasGroup> ().alpha  < 1){
			if(fadeText){
				fadeText = false;
				loadPage ();
			}
			page = placeholder;
			for (int i = 0; i < 10; i++) {
				colum [i].GetComponent<CanvasGroup>().alpha += 0.05f;
			}
		}
		leaderInfo = dataBase.leaderboard;
		for (int i = 0; i < 10; i++) {
			if (leaderInfo != null && leaderInfo[i].entrytime != ""){
				colum [i].GetChild (0).GetComponent<Text> ().text = leaderInfo [i].entrytime;
				colum [i].GetChild (1).GetComponent<Text> ().text = leaderInfo [i].score.ToString ();
				colum [i].GetChild (2).GetComponent<Text> ().text = leaderInfo [i].username;
				colum [i].GetChild (3).GetComponent<Text> ().text = (((page - 1) * 10) + (i + 1)).ToString ();
			}
			else{
				colum [i].GetChild (0).GetComponent<Text> ().text = "";
				colum [i].GetChild (1).GetComponent<Text> ().text = "";
				colum [i].GetChild (2).GetComponent<Text> ().text = "";
				colum [i].GetChild (3).GetComponent<Text> ().text = "";
			}
		}
	}
}
