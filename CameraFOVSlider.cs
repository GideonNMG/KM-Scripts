using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Kalend
{
    public class CameraFOVSlider : MonoBehaviour
    {
        public Camera fovCamera;

        public Slider fOVSlider;

        public TextMeshProUGUI fovValueDisplay;

        public bool useFOVSlider;

        public float cameraFOV = 80f;

        [Range(20, 60)]
        public float fovMin = 30f;

        [Range(100, 140)]
        public float fovMax = 100f;



        // Start is called before the first frame update
        private void Awake()
        {

            if (fovCamera == null)        //If you do not set a camera in the editor, the main camera will be set as the FOV Camera.
            {
                fovCamera = Camera.main;

            }

            SetFOVSliderActivation();

        }

        public void SetFOVSliderActivation()
        {

            if (fOVSlider != null)
            {
                fOVSlider.gameObject.SetActive(useFOVSlider);

            }
        }

        public void SetCameraFOV()
        {

            if (useFOVSlider && fOVSlider != null)
            {

                cameraFOV = Mathf.Clamp(fOVSlider.value, fovMin, fovMax);

            }

        }

        public void Update()
        {

            SetFOVSliderActivation();



            if (fovValueDisplay != null)
            {

                fovValueDisplay.text = cameraFOV.ToString();
            }

        }


        void LateUpdate()
        {
            fovCamera.fieldOfView = cameraFOV;
        }
    }


}

