using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour
{
	public GUIStyle myGUI;
	public GameObject LeaderBoardsButton;
	public GameObject list;
	public Text boards;
	public Text names;
	public Text scorestext;
	public Text ranks;
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("clicked leader");

		HighScores ();

	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI(){
		
//		GUI.Label(new Rect(300,200,300,100), "NAMEHERE", myGUI);
//		GUI.Label(new Rect(580,200,300,100), "Score: ", myGUI);
		//change the 200 up for lower position? 
	}

	/// <summary>
	/// Corotine to start RequestSubmit
	/// </summary>
	public void HighScores()
	{		
		StartCoroutine("GetHigh");
		Debug.Log("after getHIGH Submit..");
	}

	/// <summary>
	/// Submits scores to Node endpoint /submitScores
	/// </summary>
	/// <returns>The submit.</returns>
	public IEnumerator GetHigh(){
		Debug.Log("Inside high scores");

//		Debug.Log("Name : " +PlayerData.playerData.userName);
//		Debug.Log("Score after flag : " + PlayerData.playerData.score);
//		form = new WWWForm();
//		form.AddField("userName", PlayerData.playerData.userName);
//		form.AddField("score", ""+PlayerData.playerData.score);
//		form.headers ["content-type"] = "application/json";
//
//		Dictionary<string, string> headers = new Dictionary<string,string>();
//		headers.Add ("Content-Type", "application/json");

		//for testing and avoiding real login comment out-----------------------------
		//uncomment for login to work work
		WWW w = new WWW("localhost:8081/highscores");
		yield return w; 
		//Debug.Log(w.text.ToString());
		if(string.IsNullOrEmpty(w.error)){
			//success..
			if(w.text.ToLower().Contains("error")){
				Debug.Log(w.text.ToString());
				Debug.Log("error while submitting scores");
			}else{
				
				Debug.Log (w.text.ToString());
				Scores[] obj = JsonHelper.getJsonArray<Scores> (w.text.ToString ());
				//Debug.Log("my new object: " + obj [0].userName);
				//Debug.Log("my new object: " + obj [0].score);

				setText (obj);


				//foreach (Scores n in w.text.AsEnumerable) {
				//	Scores t = JsonUtility.FromJson<Scores> (n);
				//}
				//Scores tops = JsonUtility.FromJson<Scores> (w.text.ToString ());


			}
		}else{
			//error
			Debug.Log(w.text.ToString());

		}
		//------------------------------------------------------------------------------

	}

	void setText(Scores[] scores){
		int count = 1;
		foreach (Scores a in scores) {
			Debug.Log (count +".  "+ a.userName + "    score: " + a.score + "   date: " + a.stamp);
			ranks.text += count + "\n";
			names.text += a.userName + "\n";
			scorestext.text += a.score + "\n";
			count++;
		}
	}



}

[System.Serializable]
public class Scores{
	public string userName;
	public int score;
	public string stamp;
}


public class JsonHelper{
	public static T[] getJsonArray<T>(string json){
		string newJson = "{\"array\":"+json+"}";
		Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>> (newJson);
		return wrapper.array;
	}

	[System.Serializable]
	private class Wrapper<T>{
		public T[] array;
	}
}