using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Kalend
{

    public static class ScalarLerp
    {


        public static bool lerping;

        public static float lerpValue;



        public static IEnumerator ScalarLerpRoutine(float startValue, float endValue,  Kalend.Utilities.InterpolationType lerpType, float lerpDuration)
        {


            lerping = true;

            float elapsedTime = 0f;

            //float result;

            Debug.Log("<color=blue> Lerping. </color>");


            while (elapsedTime < lerpDuration)
            {


                elapsedTime += Time.deltaTime;


                float t = Mathf.Clamp01(elapsedTime / lerpDuration);

                t = Kalend.Utilities.LerpType(t, lerpType);

                t = Mathf.Clamp01(t);


                lerpValue = Mathf.Lerp(startValue, endValue, t);

       
                yield return null;
            }

            lerping = false;

            Debug.Log("<color=Red> Stopped Lerping. </color>");


        }
    }


}
