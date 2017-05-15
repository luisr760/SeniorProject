using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateAccountManager : MonoBehaviour {

	public InputField email;
	public InputField username;
	public InputField password;
	public InputField confirmPassword;
	public Text missing;

	private string Email;
	private string userName;
	private string Password;
	private string confirmPass;
	int SceneIndex;

	public void OnDone()
	{
		Email = email.text;
		userName = username.text;
		Password = password.text;
		confirmPass = confirmPassword.text;
		bool fieldsMissing = false;
		bool ok = true;
		if (fieldEmpty (Email, userName, Password, confirmPass)) 
		{
			missing.text = "Fields are Missing!!!";
			missing.gameObject.SetActive(true);
			fieldsMissing =true;
			ok = false;

		}
		if (!Password.Equals (confirmPass) && fieldsMissing == false) {
			missing.text = "Passwords don't match";
			missing.gameObject.SetActive(true);
			ok = false;
		}
		if (ok == true) {
			SceneManager.LoadScene(1);
		}

	}


	public bool fieldEmpty(string Email, string userName, string Password, string confirmPass)
	{
		
		if (Email.Length == 0) 
		{
			return true;
		}
		else if (userName.Length == 0) 
		{
			return true;
		}
		else if (Password.Length == 0) 
		{
			return true;	
		}
		else if (confirmPass.Length == 0) 
		{
			return true;
		}
		return false;
	}
}
