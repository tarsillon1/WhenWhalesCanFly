using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Leaderboard : MonoBehaviour {
	public Transform[] colum = new Transform[10];
	private DatabaseClient dataBase;
	private List<LeaderBoard> leaderInfo;
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
        dataBase = GameObject.FindGameObjectWithTag("Database").GetComponent<DatabaseClient>();
		Debug.Log (dataBase);
		loadPage ();
	}

	void loadPage(){
		leaderInfo = null;
		StartCoroutine(dataBase.setPage(placeholder));
        StartCoroutine(dataBase.getUsername());
        StartCoroutine(dataBase.getUsername());
        StartCoroutine(dataBase.getUsername());
        StartCoroutine(dataBase.getUsername());
        StartCoroutine(dataBase.getUsername());
        StartCoroutine(dataBase.getHighscore());
    }

    void Update()
    {
        if (fadeText && colum[0].GetComponent<CanvasGroup>().alpha >= 0.01)
        {
            for (int i = 0; i < 10; i++)
            {
                colum[i].GetComponent<CanvasGroup>().alpha -= 0.05f;
            }
        }
        else if (colum[0].GetComponent<CanvasGroup>().alpha < 1)
        {
            if (fadeText)
            {
                fadeText = false;
                loadPage();
            }
            page = placeholder;
            for (int i = 0; i < 10; i++)
            {
                colum[i].GetComponent<CanvasGroup>().alpha += 0.05f;
            }
        }
        leaderInfo = dataBase.leaderboard;
        int y = 0;
        if (leaderInfo != null)
        {
            foreach (LeaderBoard lb in leaderInfo)
            {
                colum[y].GetChild(0).GetComponent<Text>().text = leaderInfo[y].entrytime;
                colum[y].GetChild(1).GetComponent<Text>().text = leaderInfo[y].score.ToString();
                colum[y].GetChild(2).GetComponent<Text>().text = leaderInfo[y].username;
                colum[y].GetChild(3).GetComponent<Text>().text = (((page - 1) * 10) + (y + 1)).ToString();
                y++;
            }
        }

        for(int z = y; z < 10; z++)
        {
            colum[z].GetChild(0).GetComponent<Text>().text = "";
            colum[z].GetChild(1).GetComponent<Text>().text = "";
            colum[z].GetChild(2).GetComponent<Text>().text = "";
            colum[z].GetChild(3).GetComponent<Text>().text = "";
        }
    }
}
