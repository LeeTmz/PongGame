using RenderHeads.Media.AVProVideo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using VirtualTown.Managers;
using VirtualTown.Request;

public partial class WatchingroomBaseController : MonoBehaviour
{
    protected virtual void Start()
    {
        StartCoroutine(Initialize());
    }

    protected virtual IEnumerator Initialize()
    {
        //m_mediaPlayers = new MediaPlayer[videosParent.childCount];

        //for (int i = 0; i < videosParent.childCount; i++)
        //{
        //    m_mediaPlayers[i] = videosParent.GetChild(i).GetComponentInChildren<MediaPlayer>();
        //}

        if (!string.IsNullOrEmpty(GameManager.Instance.GameData.sessionData.urlvideo))
        {
            string[] videosUrl = GameManager.Instance.GameData.sessionData.urlvideo.Split(';');

            //if(GameManager.Instance.GameData.sessionData.videos_volume == null) 
            //{
            //}

            for (int i = 0; i < m_mediaPlayers.Length; i++)
            {
                if (string.IsNullOrEmpty(videosUrl[i]))
                    continue;

                SessionData.ChromaKeyVideos lChromaSettings = GameManager.Instance.GameData.sessionData.chromakey_urlvideo[m_mediaPlayers[i].index];

                if (lChromaSettings.enable)
                {
                    DisplayUGUI lDisplayGUI = m_mediaPlayers[i].mediaPlayer.transform.parent.GetComponentInChildren<DisplayUGUI>();
                    lDisplayGUI.material = chromaMaterial;

                    Material lMaterial = lDisplayGUI.material;
                    Color lChromaColor;

                    ColorUtility.TryParseHtmlString(GameManager.Instance.GameData.sessionData.chromakey_urlvideo[i].color, out lChromaColor);
                    lMaterial.SetColor("_MaskColor", lChromaColor);
                }

                if (m_mediaPlayers[i].index < videosUrl.Length)
                {
                    if (GameManager.Instance.GameData.sessionData.videos_volume != null)
                    {
                        if (i < GameManager.Instance.GameData.sessionData.videos_volume.Length)
                        {
                            if (m_mediaPlayers[i].index == GameManager.Instance.GameData.sessionData.videos_volume[i].index)
                            {
                                m_mediaPlayers[i].mediaPlayer.AudioVolume = GameManager.Instance.GameData.sessionData.videos_volume[i].video_volume / 100;
                            }
                        }
                    }

                    Uri lvideoUrl = new Uri(videosUrl[m_mediaPlayers[i].index]);

                    m_mediaPlayers[i].mediaPlayer.gameObject.SetActive(true);
                    string lExtention = Path.GetExtension(lvideoUrl.AbsoluteUri);

                    switch (lExtention)
                    {
                        case ".m3u8":
                            m_mediaPlayers[i].mediaPlayer.ForceFileFormat = FileFormat.HLS;
                            m_mediaPlayers[i].mediaPlayer.PlatformOptionsWebGL.externalLibrary = WebGL.ExternalLibrary.HlsJs;
                            break;
                        default:
                            m_mediaPlayers[i].mediaPlayer.ForceFileFormat = FileFormat.Unknown;
                            m_mediaPlayers[i].mediaPlayer.PlatformOptionsWebGL.externalLibrary = WebGL.ExternalLibrary.None;
                            break;
                    }

                    m_mediaPlayers[i].mediaPlayer.OpenMedia(MediaPathType.AbsolutePathOrURL, lvideoUrl.AbsoluteUri);
                    m_mediaPlayers[i].mediaPlayer.AudioMuted = true;
                    m_mediaPlayers[i].mediaPlayer.Play();
                }

            }
            //for (int i = 0; i < videosUrl.Length; i++)
            //{
            //    if (i >= m_mediaPlayers.Length)
            //        break;

            //    if(i < GameManager.Instance.GameData.sessionData.chromakey_urlvideo.Length)
            //    {
            //        //var videoObject = m_mediaPlayers[i].transform.Find("Video");
            //        var displayGUI = m_mediaPlayers[i].transform.parent.GetComponentInChildren<DisplayUGUI>();
            //        displayGUI.material = chromaMaterial;
            //        var material = displayGUI.material;

            //        Color lChromaColor;

            //        ColorUtility.TryParseHtmlString(GameManager.Instance.GameData.sessionData.chromakey_urlvideo[i].color, out lChromaColor);

            //        if (i < GameManager.Instance.GameData.sessionData.chromakey_urlvideo.Length)
            //            material.SetColor("_MaskColor", lChromaColor);
            //    }


            //}
        }
        else
        {
            foreach (var item in m_mediaPlayers)
                item.mediaPlayer.gameObject.SetActive(false);

            Debugger.LogError("Video", "Video url has not setted");
        }

        yield return null;
    }








    private void SetVideoVolumeSettings(int i)
    {
        if (GameManager.Instance.GameData.sessionData.videos_volume == null
           || GameManager.Instance.GameData.sessionData.videos_volume.Length == 0)
            return;

        if (m_mediaPlayers[i].index == GameManager.Instance.GameData.sessionData.videos_volume[i].index)
        {
            m_mediaPlayers[i].mediaPlayer.AudioVolume = GameManager.Instance.GameData.sessionData.videos_volume[i].video_volume / 100f;
        }
    }
}
