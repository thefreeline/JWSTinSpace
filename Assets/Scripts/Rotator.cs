namespace VRTK.Examples
{
    using UnityEngine;

    public class Rotator : VRTK_InteractableObject
    {
        public float spinSpeed = 100f;

        public enum String { X, Y, Z };
        public String axes;

        private float origSpinSpeed;
        Transform rotator;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            spinSpeed = 0f;
        }

        public override void StopUsing(GameObject usingObject)
        {
            base.StopUsing(usingObject);
            spinSpeed = origSpinSpeed;
        }

        //protected override void Start()
        protected void Start()
        {
            //base.Start();
            rotator = this.transform;
            origSpinSpeed = spinSpeed;
        }

        protected override void Update()
        {
            //String axis = axis;
            string axis = axes.ToString();
            if (axis.Equals("X"))
            {
                rotator.transform.Rotate(new Vector3(spinSpeed * Time.deltaTime, 0f, 0f));
            }
            else if (axis.Equals("Y"))
            {
                rotator.transform.Rotate(new Vector3(0f, spinSpeed * Time.deltaTime, 0f));
            }
            else if (axis.Equals("Z"))
            {
                rotator.transform.Rotate(new Vector3(0f, 0f, spinSpeed * Time.deltaTime));
            }





        }
    }
}