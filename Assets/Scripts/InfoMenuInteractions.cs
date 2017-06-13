namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class InfoMenuInteractions : VRTK_InteractableObject
    {

        private float spinSpeed = 100f;
        private Transform icon;
        private GameObject infoMenu;
        private GameObject[] infoMenuContainers;
        private Transform infoMenuContainerT;
        private GameObject[] infoMenus;
        private RawImage[] infoMenuImgs;
        private GameObject jwstModel;
        private Quaternion cameraRot;
        private Vector3 cameraPos;
        private float camPosZ;
        private GameObject[] infoMenusStart;

        private bool menuFlag = false;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);

            //Debug.Log("StartUsing");
            icon = this.transform;

            // Get Info Menu Container and reposition out of view

            infoMenuContainers = GameObject.FindGameObjectsWithTag("infoMenuContainer");

            // Get current camera position and rotation. Used to determine display location and rotation of information menus
            cameraRot = Camera.main.gameObject.transform.rotation;
            camPosZ = Camera.main.nearClipPlane + 1.25F;

            // Spin icons
            icon.transform.Rotate(new Vector3(0f, spinSpeed * Time.deltaTime, 0f));

            if (menuFlag == false)
            {

                foreach (GameObject infoMenuContainer in infoMenuContainers)
                {
                    var iconName = this.name;
                    var iconSubstr = iconName.Substring(iconName.LastIndexOf(':') + 1);

                    infoMenuContainerT = infoMenuContainer.transform;

                    //Loop through each instance of a container to find its number value
                    //If the value matches the value of the icon that was clicked
                    //Move the container into view and start the audio
                    foreach (Transform infoMenu in infoMenuContainerT)
                    {
                        var infoMenuName = infoMenu.name;
                        var infoMenuSubstr = infoMenuName.Substring(infoMenuName.LastIndexOf(':') + 1);

                        infoMenu.transform.position = new Vector3(60000, 0, 0);

                        if (infoMenuSubstr == iconSubstr)
                        {
                            infoMenu.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.35f, camPosZ - 0.7f));
                            infoMenu.transform.rotation = Quaternion.Euler(0f, cameraRot.eulerAngles.y + -45f, 0f);
                            infoMenu.GetComponent<AudioSource>().Play();
                        }
                    }
                }
                   
                menuFlag = true;
            }
            

        }

        public override void StopUsing(GameObject usingObject)
        {
            base.StopUsing(usingObject);
            menuFlag = false;
        }
    }
}
