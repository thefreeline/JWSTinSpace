namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class ChangeSceneOnClick : VRTK_InteractableObject
    {
        private SteamVR_TrackedController controller;

        private void Start()
        {
            controller = GetComponent<SteamVR_TrackedController>();
            Debug.Log(controller);
            controller.TriggerClicked += changeScene;
        }

        void changeScene(object sender, ClickedEventArgs e)
        {
            SceneManager.LoadScene("--Experimental--LUVOIR Planetary System");
        }

        //public override void StartUsing(GameObject usingObject)
        //{
        //    Debug.Log("Change Scene");
        //    base.StartUsing(usingObject);
        //    SceneManager.LoadScene("--Experimental--LUVOIR Planetary System");
        //}


    }
}
