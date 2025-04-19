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

        private bool _lerping;

        public Slider rotationSlider;

        public bool rotateSkybox;

        [Range(-10f, 10f)]
        public float rotationSpeed = 0.001f;

        private float _rotationSpeed = 2f;

        private float _currentRotationSpeed;

        private float _rotationParameter = 1f;

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
            //rotateSkybox = true;

            StartLerp(0f, _currentRotationSpeed, Utilities.InterpolationType.Linear, _lerpDuration);

            // rotationSpeed = _rotationSpeed;
        }

        public void StartLerp(float start, float end, Kalend.Utilities.InterpolationType iType, float duration)
        {

            StartCoroutine(ScalarLerp.ScalarLerpRoutine(start, end, iType, duration));

        }


        // Update is called once per frame
        void Update()
        {
            //_rotationParameter = Time.time * rotationSpeed * _sliderValue % 360;


          

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
                    // _skybox.SetFloat("_Rotation", Time.time * rotationSpeed);

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

               // _skybox.SetFloat("_Rotation", _rotationParameter);

                //_skybox.SetFloat("_Rotation", Time.time * rotationSpeed * _sliderValue);

                

                //Debug.Log(_skybox.GetFloat("_Rotation"));


            }

        }



    }


}




