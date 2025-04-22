using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

namespace Kalend
{
    // This is the (abstract) base class from which ClipSelector is derived. (PlaylistSelector is, in turn, derived from ClipSlector.) 
    // The static variables declared below are availabel to all derived classes (and their children). 

    public abstract class AudioSelection : MonoBehaviour
    {
        public static string currentClipName;

        public static string currentPlayListName;

        public static string musicGroupVolume = "MusicGroupVolume";  // Exposed parameter: volume on music subgroup of Kalend Music Mixer == "MusicGroupVolume"

        public static AudioClip currentAudioClip;

        public static AudioSource currentAudioSource;

        public static AudioMixer currentAudioMixer;

        public static AudioMixerGroup currentAudioMixerGroup;

        public static float currentAudioMixweGroupVolume;

        public static AudioClip[] currentAudioClips;

        public static int clipCount = 1;

        public static int currentIndex = 0;

        public static bool paused;

       


        // Increment and Decrement functions can be built from this int (as in the ClipSelector class) by setting delta equal to one, or minus one, respectively. 
        public static int ModShift(int index, int n, int delta)
        {

            n = Mathf.Max(n, 1); //prevents n from ever being less than one. 

            delta = (delta % n); //prevents delta from ever being larger than n.

            int result = 0;

            index += n + delta;

            result = Mathf.Abs((index % n)); // retruns a result shifted by delta then mod n.

            return result;


        }





    }


}


