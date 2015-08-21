using UnityEngine;
using System.Collections;

public class Colum {
	
	private string entrytime;
	private int userid;
	private string username;
	private int score;
	
	public string getEntrytime() {
		return entrytime;
	}
	public void setEntrytime(string entrytime) {
		this.entrytime = entrytime;
	}
	public int getUserid() {
		return userid;
	}
	public void setUserid(int userid) {
		this.userid = userid;
	}
	public string getUsername() {
		return username;
	}
	public void setUsername(string username) {
		this.username = username;
	}
	public int getScore() {
		return score;
	}
	public void setScore(int score) {
		this.score = score;
	}
	public string toString(){
		return entrytime + ":" + userid + ": " + username + "\t" + score ;
		
	}
	
}


