using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        //Start: Matt's stuff
        public bool CanMove = true;
        private bool axisInUse = false;
        private float nitroMultiplier;
        private bool nitroing = false;
        [SerializeField]
        private GameObject part;
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
            nitroMultiplier = 1f;
        }

        private void FixedUpdate()
        {
            // pass the input to the car!
            if (CanMove) //Matt: but only if you can move. Later, implement player death and lock movement
            {
                float h = Input.GetAxis("Horizontal");
                float v = Input.GetAxis("Vertical");

                float handbrake = (Input.GetAxis("Submit"));
                m_Car.Move(h * nitroMultiplier, v * nitroMultiplier, v, handbrake-0.1f);
            }
            if (Input.GetAxisRaw("LShift") != 0)
            {
                if (!axisInUse)
                {
                    //nitro
                    if (GameManager.Instance.NitroNum > 0)
                        ApplyNitro();
                    //Debug.Log("Nitro here.");
                    axisInUse = true;
                }
            }
            if (Input.GetAxisRaw("LShift") == 0)
            {
                axisInUse = false;
            }
        }

        private IEnumerator Boost()
        {
            nitroMultiplier = 5f;
            nitroing = true;
            Debug.Log("Start nitro");
            part.SetActive(true);
            yield return new WaitForSeconds(6f);
            part.SetActive(false);
            Debug.Log("End nitro");
            nitroing = false;
            nitroMultiplier = 1f;
        }

        private void ApplyNitro()
        {
            if (!nitroing)
            {
                GameManager.Instance.NitroNum--;
                StartCoroutine(Boost());
            }
        }
    }
}
