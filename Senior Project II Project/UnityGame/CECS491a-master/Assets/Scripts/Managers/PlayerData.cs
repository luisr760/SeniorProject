using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerData : MonoBehaviour {

	public static PlayerData playerData; //persist across scenes

	/*For now, we can carry around the user name and score.
	 * the userName will tie back to the account saved on the db.
	 * The score should be reset to zero after the a level is completed
	 * and the score has been sent to the db.  Other data needs to 
	 * be saved can be added to this list and send to the db
	 * wrapped in a json object or something similar.
	 * 
	 * */
	//public float health;
	public static int currentLives =3;
	public string userName;
	public int score;
	public bool fromCoinRoom =false;

	void Awake(){ //awake gets called before start
		if(playerData ==null){
			DontDestroyOnLoad(gameObject);
			playerData =this ;
		}else if(playerData != this){
			Destroy(gameObject);//don't want multiple instances of this object
		}			
	}

	public void setScore(int levelScore){
		score = levelScore;
	}
	public void resetScore(){
		score = 0;
	}
	public int getScore(){
		return score;
	}
	public void packageData(){
		//set userName and score to json and for sending to WWW
	}

	//for debuging
	void OnGUI(){
		GUI.Label(new Rect(10,100,300,100), "User Name: " + userName);
		GUI.Label(new Rect(10,150,150,30), "Score: " + score);
	}

	public void setInCoinRoom(){		
		fromCoinRoom = true;
	}

	public void setInCoinFalse(){
		fromCoinRoom = false;
	}

	public bool getFromCoinRoom(){
		return fromCoinRoom;
	}
	public int getLives(){
		return currentLives;
	}
	public void setLives(int l){
		currentLives = l;
	}
	public void resetLives(){
		currentLives = 3;
	}

//just in case howard wants to visit his old code...else delete
//	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir) {
//		float timer = 0;
//
//		while (knockDur > timer) {
//		
//			timer += Time.deltaTime;
//
//			//rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
//
//		}
//
//		yield return 0;
//	}
}
