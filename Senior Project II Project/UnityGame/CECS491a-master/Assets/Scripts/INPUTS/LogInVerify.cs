using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text;

public class LogInVerify : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject signInButton;

	public GameObject fieldUsername;
	public GameObject fieldPassword;
	public Text textName;
	public Text textPassword;

	int scene;

	WWWForm form;//send to php
	public Text textfeedback;

	void Start(){
		//textfeedback.text = " ";
	}

	void Update(){
	
	}

	public void onSignIn()
	{
		textfeedback.text = "Logging in...";
		StartCoroutine("RequestLogin");
		Debug.Log("after StartCo..");

		/*
		else if (!Password.Equals (dummyPass) || !userName.Equals(dummyName)) {
			missing.text = "Username or Password are incorrect";
			missing.gameObject.SetActive(true);
			ok = false;
		}
		if (ok == true) {
			SceneManager.LoadScene(1);
		}
*/
	}
	// Use this for initialization
	public bool fieldEmpty(string userName, string Password)
	{

		if (userName.Length == 0) 
		{
			return true;
		}
		else if (Password.Length == 0) 
		{
			return true;	
		}

		return false;
	}

	public IEnumerator RequestLogin(){
		Debug.Log("Inside request");
		string name  = textName.text;
		string pass = fieldPassword.GetComponent<InputField>().text;// textPassword.text;
		Debug.Log(name);
		Debug.Log(pass);
		//bool fieldsMissing = false;
		//bool ok = true;
		if (fieldEmpty (name, pass)) 
		{
			textfeedback.text = "Fields are Missing!!!";
			//missing.gameObject.SetActive(true); 
			//fieldsMissing =true;
			//ok = false;
		}

		form = new WWWForm();
		form.AddField("userName", name);
		form.AddField("password", pass);

		form.headers ["content-type"] = "application/json";

		//string input = "{\"userName\":\"" + name + ",\"password\":\"" + pass + "\"}";
		Dictionary<string, string> headers = new Dictionary<string,string>();
		headers.Add ("Content-Type", "application/json");

		//comment out for actaul login-------------
//		PlayerData.playerData.userName = name;
//		SceneManager.LoadScene(1);
//
//		yield return 0;
		//to here ---------------------------------


		//for testing and avoiding real login comment out-----------------------------
		//uncomment for login to work work
		WWW w = new WWW("localhost:8081/signIn", form.data, form.headers);
		yield return w; 
		Debug.Log(w.text.ToString());
		if(string.IsNullOrEmpty(w.error)){
			//success..
			if(w.text.ToLower().Contains("not valid")){
				textfeedback.text = "invalid email or password";
			}else{
				textfeedback.text = "logging successful..";
				Debug.Log(w.text.ToString());
				//save the user file
				PlayerData.playerData.userName = name;
				SceneManager.LoadScene(1);
			}
		}else{
			//error
			textfeedback.text = "Login error";
		}
		//------------------------------------------------------------------------------

	}
}
