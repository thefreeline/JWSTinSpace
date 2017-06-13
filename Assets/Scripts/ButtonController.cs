using UnityEngine;
using UnityEngine.UI; // <-- you need this to access UI (button in this case) functionalities

public class ButtonController : MonoBehaviour {
	Button myButton;

	void Awake()
	{
		myButton = GetComponent<Button>();
		myButton.onClick.AddListener (returnToMainScene);

	}

	void returnToMainScene()
	{
		Application.LoadLevel ("Main");
	}
}