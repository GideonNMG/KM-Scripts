using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kalend
{
    [CreateAssetMenu(menuName = "Music Playlist")]
    public class MusicPlaylist : ScriptableObject
    {


        public string playListName = "playlist";


        public AudioClip[] playListAudioClips;



        public void OnEnable()
        {



        }


    }

}