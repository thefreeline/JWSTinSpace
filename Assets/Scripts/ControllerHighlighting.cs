namespace VRTK.Examples
{
    using UnityEngine;

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ControllerHighlighting : MonoBehaviour
    {

        public bool highlightBodyOnlyOnCollision = false;

        private VRTK_ControllerTooltips tooltips;
        private VRTK_ControllerActions actions;
        private VRTK_ControllerEvents events;

        private Color highlightColor;

        private void Start()
        {
            if (GetComponent<VRTK_ControllerEvents>() == null)
            {
                Debug.LogError("VRTK_ControllerEvents_ListenerExample is required to be attached to a Controller that has the VRTK_ControllerEvents script attached to it");
                return;
            }

            events = GetComponent<VRTK_ControllerEvents>();
            actions = GetComponent<VRTK_ControllerActions>();
            tooltips = GetComponentInChildren<VRTK_ControllerTooltips>();

            //Setup controller event listeners
            events.TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            events.TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);

            //events.ButtonOnePressed += new ControllerInteractionEventHandler(DoButtonOnePressed);
            //events.ButtonOneReleased += new ControllerInteractionEventHandler(DoButtonOneReleased);

            events.GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
            events.GripReleased += new ControllerInteractionEventHandler(DoGripReleased);

            events.TouchpadPressed += new ControllerInteractionEventHandler(DoTouchpadPressed);
            events.TouchpadReleased += new ControllerInteractionEventHandler(DoTouchpadReleased);

            highlightColor = new Color(212, 199, 253);
            //tooltips.ToggleTips(false);
        }


        public void DoGripPressed(object sender, ControllerInteractionEventArgs e)
        {
            //tooltips.ToggleTips(true, VRTK_ControllerTooltips.TooltipButtons.GripTooltip);
            actions.ToggleHighlightGrip(true, highlightColor, .5f);
            //actions.SetControllerOpacity(0.8f);
        }

        public void DoGripReleased(object sender, ControllerInteractionEventArgs e)
        {
            //tooltips.ToggleTips(false, VRTK_ControllerTooltips.TooltipButtons.GripTooltip);
            actions.ToggleHighlightGrip(false);
            if (!events.AnyButtonPressed())
            {
                actions.SetControllerOpacity(1f);
            }
        }

        private void DoTouchpadPressed(object sender, ControllerInteractionEventArgs e)
        {
            //tooltips.ToggleTips(true, VRTK_ControllerTooltips.TooltipButtons.TouchpadTooltip);
            actions.ToggleHighlightTouchpad(true, highlightColor, .5f);
            //actions.SetControllerOpacity(0.8f);
        }

        private void DoTouchpadReleased(object sender, ControllerInteractionEventArgs e)
        {
            //tooltips.ToggleTips(false, VRTK_ControllerTooltips.TooltipButtons.TouchpadTooltip);
            actions.ToggleHighlightTouchpad(false);
            if (!events.AnyButtonPressed())
            {
                actions.SetControllerOpacity(1f);
            }
        }

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            //tooltips.ToggleTips(true, VRTK_ControllerTooltips.TooltipButtons.TouchpadTooltip);
            actions.ToggleHighlightTrigger(true, highlightColor, .5f);
            //actions.SetControllerOpacity(0.8f);
        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            //tooltips.ToggleTips(false, VRTK_ControllerTooltips.TooltipButtons.TouchpadTooltip);
            actions.ToggleHighlightTrigger(false);
            if (!events.AnyButtonPressed())
            {
                actions.SetControllerOpacity(1f);
            }
        }

        public void IndicateGrabStart(object sender)
        {
            actions.ToggleHighlightGrip(true, Color.cyan, 0.5f);
            actions.SetControllerOpacity(0.8f);
        }

        private void Update()
        {

        }
    }
}
