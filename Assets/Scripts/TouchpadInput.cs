using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;



public class TouchpadInput : MonoBehaviour {

    public uint controllerIndex;
    public VRControllerState_t controllerState;
    public bool triggerPressed = false;
    public bool steamPressed = false;
    public bool menuPressed = false;
    public bool padPressed = false;
    public bool padTouched = false;
    public bool gripped = false;

    public event ClickedEventHandler MenuButtonClicked;
    public event ClickedEventHandler MenuButtonUnclicked;
    public event ClickedEventHandler TriggerClicked;
    public event ClickedEventHandler TriggerUnclicked;
    public event ClickedEventHandler SteamClicked;
    public event ClickedEventHandler PadClicked;
    public event ClickedEventHandler PadUnclicked;
    public event ClickedEventHandler PadTouched;
    public event ClickedEventHandler PadUntouched;
    public event ClickedEventHandler Gripped;
    public event ClickedEventHandler Ungripped;

    public GameObject[] toggleMenus;

    // Use this for initialization
    void Start()
    {
        if (this.GetComponent<SteamVR_TrackedObject>() == null)
        {
            gameObject.AddComponent<SteamVR_TrackedObject>();
        }

        if (controllerIndex != 0)
        {
            this.GetComponent<SteamVR_TrackedObject>().index = (SteamVR_TrackedObject.EIndex)controllerIndex;
            if (this.GetComponent<SteamVR_RenderModel>() != null)
            {
                this.GetComponent<SteamVR_RenderModel>().index = (SteamVR_TrackedObject.EIndex)controllerIndex;
            }
        }
        else
        {
            controllerIndex = (uint)this.GetComponent<SteamVR_TrackedObject>().index;
        }
    }

    public void SetDeviceIndex(int index)
    {
        this.controllerIndex = (uint)index;
    }

    public virtual void OnPadClicked(ClickedEventArgs e)
    {
        for (int i = 0; i < toggleMenus.Length; i++)
        {
            if (toggleMenus[i].activeSelf == true)
            {
                toggleMenus[i].SetActive(false);
            }
            else
            {
                toggleMenus[i].SetActive(true);
            }
        }
    }

    public virtual void OnPadUnclicked(ClickedEventArgs e)
    {
        
    }

    public virtual void OnPadTouched(ClickedEventArgs e)
    {
        
    }

    public virtual void OnPadUntouched(ClickedEventArgs e)
    {
        
    }

    void Update()
    {
        var system = OpenVR.System;
        if (system != null && system.GetControllerState(controllerIndex, ref controllerState, (uint)System.Runtime.InteropServices.Marshal.SizeOf(typeof(VRControllerState_t))))
        {
            ulong pad = controllerState.ulButtonPressed & (1UL << ((int)EVRButtonId.k_EButton_SteamVR_Touchpad));
            if (pad > 0L && !padPressed)
            {
                padPressed = true;
                ClickedEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                OnPadClicked(e);
            }
            else if (pad == 0L && padPressed)
            {
                padPressed = false;
                ClickedEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                OnPadUnclicked(e);
            }

            

            pad = controllerState.ulButtonTouched & (1UL << ((int)EVRButtonId.k_EButton_SteamVR_Touchpad));
            if (pad > 0L && !padTouched)
            {
                padTouched = true;
                ClickedEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                OnPadTouched(e);

            }
            else if (pad == 0L && padTouched)
            {
                padTouched = false;
                ClickedEventArgs e;
                e.controllerIndex = controllerIndex;
                e.flags = (uint)controllerState.ulButtonPressed;
                e.padX = controllerState.rAxis0.x;
                e.padY = controllerState.rAxis0.y;
                OnPadUntouched(e);
            }
        }
    }
}
