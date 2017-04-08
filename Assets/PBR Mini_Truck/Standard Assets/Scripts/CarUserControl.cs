using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        //Start: Matt's stuff
        public bool CanMove = true;
       /* private static CarUserControl instance;
        public static CarUserControl Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<CarUserControl>();
                }
                return instance;
            }
        }*/
        //End: Matt's stuff


        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }


        private void FixedUpdate()
        {
            // pass the input to the car!
            if (CanMove) //Matt: but only if you can move. Later, implement player death and lock movement
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                float handbrake = Input.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
            }
        }
    }
}
