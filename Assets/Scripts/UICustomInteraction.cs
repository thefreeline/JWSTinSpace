namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;

    public class UICustomInteraction : MonoBehaviour
    {
        private const int EXISTING_CANVAS_COUNT = 4;
        private RawImage[] menuImgs;
        private RawImage menuImg;
        private GameObject menuObj;
        private int menuImgIter = 1;
        private int menuImgCnt;
        private MovieTexture movie;


        public void CloseMenu()
        {
            GameObject childObject = this.gameObject;
            string tag = "infoMenu";

            Transform t = childObject.transform;
            while (t.parent != null)
            {
                if (t.parent.tag == tag)
                {
                    t.parent.GetComponent<AudioSource>().Stop();
                    t.parent.transform.localPosition = new Vector3(20000, 0, 0);
                }
                t = t.parent.transform;
            }
        }

        public void ImgAdvance()
        {
            GameObject childObject = this.gameObject;
            string tag = "infoMenu";

            Transform t = childObject.transform;
            while (t.parent != null)
            {
                if (t.parent.tag == tag)
                {
                    var menu = t.parent;
                    menuImgs = menu.GetComponentsInChildren<RawImage>(true);
                    menuImgCnt = menuImgs.Length - 2;

                    if (menuImgIter <= menuImgCnt)
                    {
                        foreach (RawImage menuImg in menuImgs)
                        {
                            if (menuImg.name.Contains("Display Image"))
                            {
                                if (menuImg.name == "Display Image:" + menuImgIter)
                                {
                                    movie = menuImg.texture as MovieTexture;
                                    if (movie != null)
                                    {
                                        movie.Play();
                                        menuImg.enabled = true;
                                    }
                                    else
                                    {
                                        menuImg.enabled = true;
                                    }
                                }
                                else
                                {
                                    menuImg.enabled = false;
                                }
                            }
                        }

                        menuImgIter += 1;
                        if (menuImgIter > menuImgCnt) menuImgIter = 0;
                    }
                    else
                    {
                        menuImgIter = 0;
                    }
                }

                t = t.parent.transform;
            }
        }

        public void ImgBack()
        {
            GameObject childObject = this.gameObject;
            string tag = "infoMenu";

            Transform t = childObject.transform;
            while (t.parent != null)
            {
                if (t.parent.tag == tag)
                {
                    var menu = t.parent;
                    menuImgs = menu.GetComponentsInChildren<RawImage>(true);
                    menuImgCnt = menuImgs.Length - 1;

                    if (menuImgIter < menuImgCnt)
                    {
                        foreach (RawImage menuImg in menuImgs)
                        {
                            if (menuImg.name.Contains("Display Image"))
                            {
                                if (menuImg.name == "Display Image:" + menuImgIter)
                                {
                                    menuImg.enabled = true;
                                }
                                else
                                {
                                    menuImg.enabled = false;
                                }
                            }
                        }

                        menuImgIter += 1;
                        if (menuImgIter == menuImgCnt) menuImgIter = 0;
                    }
                    else
                    {
                        menuImgIter = 0;
                    }
                }

                t = t.parent.transform;
            }
        }

        public void TeleportToJWSTModel()
        {
            Debug.Log("Teleporting");
        }

        public void Button_Pink()
        {
            Debug.Log("Pink Button Clicked");
        }

        public void Toggle(bool state)
        {
            Debug.Log("The toggle state is " + (state ? "on" : "off"));
        }

        public void Dropdown(int value)
        {
            Debug.Log("Dropdown option selected was ID " + value);
        }

        public void CreateCanvas()
        {
            var canvasCount = FindObjectsOfType<Canvas>().Length - EXISTING_CANVAS_COUNT;
            var newCanvasGO = new GameObject("TempCanvas");
            newCanvasGO.layer = 5;
            var canvas = newCanvasGO.AddComponent<Canvas>();
            var canvasRT = canvas.GetComponent<RectTransform>();
            canvasRT.position = new Vector3(-4f, 2f, 2f + canvasCount);
            canvasRT.sizeDelta = new Vector2(300f, 400f);
            canvasRT.localScale = new Vector3(0.005f, 0.005f, 0.005f);
            canvasRT.eulerAngles = new Vector3(0f, 270f, 0f);

            var newButtonGO = new GameObject("TempButton");
            newButtonGO.transform.parent = newCanvasGO.transform;
            newButtonGO.layer = 5;

            newButtonGO.AddComponent<RectTransform>();

            var buttonRT = newButtonGO.GetComponent<RectTransform>();
            buttonRT.position = new Vector3(0f, 0f, 0f);
            buttonRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            buttonRT.localPosition = new Vector3(0f, 0f, 0f);
            buttonRT.sizeDelta = new Vector2(180f, 60f);
            buttonRT.localScale = new Vector3(1f, 1f, 1f);
            buttonRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            newButtonGO.AddComponent<Image>();
            var canvasButton = newButtonGO.AddComponent<Button>();
            var buttonColourBlock = canvasButton.colors;
            buttonColourBlock.highlightedColor = Color.red;
            canvasButton.colors = buttonColourBlock;

            var newTextGO = new GameObject("BtnText");
            newTextGO.transform.parent = newButtonGO.transform;
            newTextGO.layer = 5;

            var textRT = newTextGO.AddComponent<RectTransform>();
            textRT.position = new Vector3(0f, 0f, 0f);
            textRT.anchoredPosition = new Vector3(0f, 0f, 0f);
            textRT.localPosition = new Vector3(0f, 0f, 0f);
            textRT.sizeDelta = new Vector2(180f, 60f);
            textRT.localScale = new Vector3(1f, 1f, 1f);
            textRT.localEulerAngles = new Vector3(0f, 0f, 0f);

            var txt = newTextGO.AddComponent<Text>();
            txt.text = "New Button";
            txt.color = Color.black;
            txt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

            //FindObjectOfType<VRTK_UIPointer>().SetWorldCanvas(canvas);
        }
    }
}