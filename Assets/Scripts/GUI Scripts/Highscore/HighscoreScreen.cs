using UnityEngine;
using UnityEngine.UI;

public class HighscoreScreen : MonoBehaviour {
	private float distance;
	private string username = "";
	private int highscore = 0;
	private int score;
	public Transform usernameUI{ get; set; }
	public Transform normalScoreUI{ get; set; }
	public Transform newHighscoreUI{ get; set; }
	public DatabaseClient dataBase{ get; set; }

	void Start () {
		GetComponent<CanvasGroup> ().alpha = 0f;
		this.GetComponent<Canvas> ().worldCamera = Camera.main;
        dataBase = GameObject.FindGameObjectWithTag("Database").GetComponent<DatabaseClient>();
	}
	

	void Update () {
		if (distance < 25) { 
			if(distance == 0){
				getUsername ();
				if (username == "") {
					Transform ui = (Transform)Instantiate (usernameUI, new Vector3 (0, 0, 90), Quaternion.identity);
					ui.SetParent (this.transform);
					ui.localScale = new Vector3 (1, 1, 1);
					ui.localPosition = new Vector3 (0, 0, 0);
				}
				else if(score <= highscore && username != ""){
					getHighscore();
					Transform ui = (Transform)Instantiate (normalScoreUI, new Vector3 (0, 0, 90), Quaternion.identity);
					ui.SetParent (this.transform);
					ui.localScale = new Vector3 (1, 1, 1);
					ui.localPosition = new Vector3 (0, 0, 0);
					ui.GetChild(1).GetComponent<Text>().text = score.ToString();
					ui.GetChild(2).GetComponent<Text>().text = highscore.ToString();
				}else if(username != ""){
					getHighscore();
					Transform ui = (Transform)Instantiate (newHighscoreUI, new Vector3 (0, 0, 90), Quaternion.identity);
					ui.SetParent (this.transform);
					ui.localScale = new Vector3 (1, 1, 1);
					ui.localPosition = new Vector3 (0, 0, 0);
					ui.GetChild(1).GetComponent<Text>().text = score.ToString();
					setHighscore();
				}
				this.GetComponent<Canvas> ().renderMode = RenderMode.WorldSpace;
				this.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y - 25, 90);
				GetComponent<CanvasGroup> ().alpha = 1f;
			}
			this.transform.position += Camera.main.transform.up / 2;
			distance += Camera.main.transform.up.y / 2;
		}
	}

	void getUsername(){
		if(dataBase.username != null)
			username = dataBase.username;
	}

	void writeUsername(){
		StartCoroutine(dataBase.postScore (username, score));
	}

	void getHighscore(){
		highscore = dataBase.highscore;
	}

	public void setHighscore(){
		StartCoroutine(dataBase.setHighscore(score));
	}

	public int getScore(){
		return score;
	}

	public void setUsername(string user){
		username = user;
		Debug.Log ("Username: " + username);
		writeUsername ();
	}

	public void setScore(int i){
		score = i;
	}
}
