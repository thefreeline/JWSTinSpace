using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class SceneChanger : MonoBehaviour {

    public string sceneName;

	private void changeScene(object sender, InteractableObjectEventArgs e)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void Update()
    {
        

    }

}
