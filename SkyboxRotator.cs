using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Kalend
{
    public class SkyboxRotator : MonoBehaviour
    {
        public Material skybox;

        private Material _skybox;

        public bool useSkyboxChanger;

        public bool useRotationSlider;

        public Slider rotationSlider;

        public bool rotateSkybox;

        [Range(-30f, 30f)]
        public float rotationSpeed = 0.001f;

        private float _rotationSpeed = 2f;

        private float _currentRotationSpeed;
       
        private float _rotation; 

        [SerializeField]
        [Range(-1f, 1f)]
        private float _startingSliderValue = 0.25f;

        [Range(-1f, 1f)]
        private float _sliderValue = 0f;


        [SerializeField]
        [Range(0.01f, 5f)]
        private float _lerpDuration = 0.5f;


        private void Awake()
        {
            if (rotateSkybox)
            {
                _sliderValue = _startingSliderValue;

                if (skybox != null && !useSkyboxChanger)
                {
                    _skybox = skybox;

                }         

            }

            _rotationSpeed = rotationSpeed;

            _currentRotationSpeed = rotationSpeed;
        }


        public void SetRotationSpeed()
        {

            if (useRotationSlider && rotationSlider != null && !ScalarLerp.lerping)
            {

                _sliderValue = Mathf.Clamp(rotationSlider.value, -1f, 1f);

            }

        }


        public void StopRotation()
        {

            _currentRotationSpeed = rotationSpeed;

            StartLerp(_currentRotationSpeed, 0f, Utilities.InterpolationType.Linear, _lerpDuration);        

            //Debug.Log("<color=red>Skybox Rotation Stopped.</color>");
        }
    

        public void StartRotation()
        {
     

            StartLerp(0f, _currentRotationSpeed, Utilities.InterpolationType.Linear, _lerpDuration);

            
        }

        public void StartLerp(float start, float end, Kalend.Utilities.InterpolationType iType, float duration)
        {

            StartCoroutine(ScalarLerp.ScalarLerpRoutine(start, end, iType, duration));

        }


        // Update is called once per frame
        void Update()
        {
            

               if (useSkyboxChanger)
                {

                    _skybox = SkyboxChanger.currentSkybox;


                    skybox = _skybox;
                }
          


            if (rotateSkybox )
            {


                _rotation = skybox.GetFloat("_Rotation");

                _rotation += (Time.deltaTime * rotationSpeed * _sliderValue);


                _rotation %= 360;

                if (ScalarLerp.lerping)
                {
                    rotationSpeed = Mathf.Abs(ScalarLerp.lerpValue);
                   

                    rotationSlider.gameObject.SetActive(false);
                }
                
                else
                {
                    if(useRotationSlider && rotationSlider != null && rotationSpeed != 0f)
                    {
                        rotationSlider.gameObject.SetActive(true);

                    }

                }


                _skybox.SetFloat("_Rotation", _rotation);

            

            }

        }



    }


}




