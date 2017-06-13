namespace VRTK.Examples
{
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;

    public class Toggle : MonoBehaviour
    {
        public bool highlightBodyOnlyOnCollision = false;

        private VRTK_ControllerTooltips tooltips;
        private VRTK_ControllerActions actions;
        private VRTK_ControllerEvents events;

        public GameObject[] enabledObjects;
        public GameObject[] disabledObjects;
        public GameObject[] toggleObjects;

        private GameObject lightPathObj;

        public void enableObj()
        {
            for (int i = 0; i < enabledObjects.Length; i++)
            {
                enabledObjects[i].SetActive(true);
            }
        }

        public void disableObj()
        {
            for (int i = 0; i < disabledObjects.Length; i++)
            {
                disabledObjects[i].SetActive(false);
            }
        }

        public void toggleObj()
        {
            for (int i = 0; i < toggleObjects.Length; i++)
            {
                if (toggleObjects[i].name == "Toggle: Light Path")
                {
                    StartCoroutine(LightPathToggle(toggleObjects[i]));
                } else
                {
                    if (toggleObjects[i].activeSelf == true)
                    {
                        toggleObjects[i].SetActive(false);
                    }
                    else
                    {
                        toggleObjects[i].SetActive(true);
                    }
                }
                
            }
        }

        IEnumerator LightPathToggle(GameObject obj)
        {
            int childCount = obj.transform.childCount;

            if (obj.activeSelf == true)
            {
                obj.SetActive(false);

                for (int i = 0; i < childCount; i++)
                {
                    lightPathObj = obj.transform.GetChild(i).gameObject;
                    lightPathObj.SetActive(false);
                }
            }
            else
            {
                obj.SetActive(true);

                for (int i = 0; i < childCount; i++)
                {
                    lightPathObj = obj.transform.GetChild(i).gameObject;
                    lightPathObj.SetActive(true);

                    yield return new WaitForSeconds(2);
                }
            }
            yield return null;
        }
    }
}
