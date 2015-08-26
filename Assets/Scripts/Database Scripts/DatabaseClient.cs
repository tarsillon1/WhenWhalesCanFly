using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

public class DatabaseClient : MonoBehaviour{
	private string adress = "192.168.1.14:8080";
	public int highscore{ get; set; }
	public string username{ get; set; }
	public List<LeaderBoard> leaderboard{ get; set; }

	void Start(){
		StartCoroutine (getUsername ());
	}

	public IEnumerator setHighscore(int score){
		string url = "http://" + adress + "/LeaderBoardService/lb/putScore";
		WWWForm form = new WWWForm();
		form.AddField("score", score.ToString());
		form.AddField("userid", SystemInfo.deviceUniqueIdentifier);
		highscore = score;

		WWW www = new WWW(url, form);
		yield return www;
	}

	public IEnumerator postScore(string user, int score){
		// Pull down the JSON from our web-service
		string url = "http://" + adress + "/LeaderBoardService/lb/postScore/";
		LeaderBoard colum = new LeaderBoard ();
		colum.entrytime = "TIME";
		colum.userid = SystemInfo.deviceUniqueIdentifier;
		colum.username = user;
		colum.score = score;
		WWWForm form = new WWWForm();
		form.AddField("lb", JsonConvert.SerializeObject(colum));


		WWW www = new WWW(url, form);
		yield return www;
	}

	public IEnumerator getHighscore(){
		// Pull down the JSON from our web-service

		WWW www = new WWW(
			"http://" + adress + "/LeaderBoardService/lb/getHighscore/" + SystemInfo.deviceUniqueIdentifier
			);
		yield return www;
		try{
		if (!www.text.Contains ("error")) {
			highscore = JsonConvert.DeserializeObject<int> (www.text);
			Debug.Log("Highscore:" + highscore);
		}
		}catch(JsonReaderException e){
			Debug.Log(e.StackTrace);
		}
	}

	public IEnumerator getUsername(){
		// Pull down the JSON from our web-service
		
		WWW www = new WWW(
			"http://" + adress + "/LeaderBoardService/lb/getUsername/" + SystemInfo.deviceUniqueIdentifier);
		yield return www;
		try{
			if (!www.text.Contains ("error")) {
				username = www.text;
				Debug.Log("Username:" + www.text);
				StartCoroutine (getHighscore());
			}
		}catch(JsonReaderException e){
			Debug.Log(e.StackTrace);
		}
	}

	public IEnumerator setPage(int i){
			// Pull down the JSON from our web-service
			
			WWW www = new WWW(
				"http://" + adress + "/LeaderBoardService/lb/getPage/" + i
				);
			yield return www;
			
			Debug.Log("Waiting for leaderboard definitions\n");
			if(!www.text.Contains("error")){
				leaderboard = JsonConvert.DeserializeObject<List<LeaderBoard>> (www.text);
				Debug.Log(www.text);
			}
	}
}
	
	