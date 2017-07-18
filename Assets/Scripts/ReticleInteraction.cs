using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;


public class ReticleInteraction : MonoBehaviour {
        // This script is a simple example of how an interactive item can
        // be used to change things on gameobjects by handling events.
        [SerializeField]
        public Material m_NormalMaterial;
        [SerializeField]
        public Material m_OverMaterial;
        [SerializeField]
        public Material m_ClickedMaterial;
        [SerializeField]
        public Material m_DoubleClickedMaterial;
        [SerializeField]
        public VRInteractiveItem m_InteractiveItem;
        [SerializeField]
        public Renderer m_Renderer;

        private Vector3 origStarSize;
        private float origStarColRadius;

        //private void Awake()
        //{
        //Debug.Log(m_Renderer);
        //Debug.Log(m_NormalMaterial);
        //    m_Renderer.material = m_NormalMaterial;
        //}

        private void Start()
        {
            m_Renderer.material = m_NormalMaterial;
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }

        //private void OnEnable()
        //{
        //    m_InteractiveItem.OnOver += HandleOver;
        //    m_InteractiveItem.OnOut += HandleOut;
        //    m_InteractiveItem.OnClick += HandleClick;
        //    m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        //}


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
            //Debug.Log("Show over state");
            m_Renderer.material = m_OverMaterial;

            origStarSize = m_InteractiveItem.transform.localScale;
            origStarColRadius = m_InteractiveItem.GetComponent<SphereCollider>().radius;

            //m_InteractiveItem.GetComponent<SphereCollider>().radius = 0.5f;
            //m_InteractiveItem.transform.localScale = new Vector3(10f, 10f, 10f);
        }


        //Handle the Out event
        private void HandleOut()
        {
            //Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
            //m_InteractiveItem.GetComponent<SphereCollider>().radius = origStarColRadius;
            //m_InteractiveItem.transform.localScale = origStarSize;
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            m_Renderer.material = m_ClickedMaterial;
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
        }
    }