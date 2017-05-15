using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
	public string nextLevel;
	public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

	public void LoadNextScene() {
		int numberOfScenes = SceneManager.sceneCountInBuildSettings;
		int currentScene = SceneManager.GetActiveScene ().buildIndex;
		// If there is another scene to load...
		if (currentScene != numberOfScenes - 1) {
			// ... load next scene by incrementing index
			SceneManager.LoadScene (currentScene + 1);
		}
	}
	public void LoadCurrentLevel()
	{
		string sceneName = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (sceneName);
	}
	public void LoadNextLevel()
	{
		SceneManager.LoadScene (nextLevel);
	}
}
