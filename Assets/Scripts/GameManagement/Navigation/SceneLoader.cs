﻿
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Navigation
{
    public class SceneLoader : MonoBehaviour
    {
        public delegate void FinishedLoadingHandler();
        public event FinishedLoadingHandler FinishedLoading;
        string levelName;
        AsyncOperation async;
        bool fading = false;

        public void StartLoading(string levelName)
        {
            this.levelName = levelName;
            StartCoroutine("load");
        }

        IEnumerator load()
        {
            Debug.LogWarning("ASYNC LOAD STARTED FOR SCENE :  " + levelName +
               " - DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
            async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
            async.allowSceneActivation = false;
            fading = false;
            yield return async;
        }

        public void ActivateScene()
        {
            async.allowSceneActivation = true;
            CameraFade.FinishedFade -= ActivateScene;
        }


        private void Update()
        {
            if (async != null && async.progress >= 0.9f)
            {
                //Debug.Log(async.progress);
                //Debug.Log(levelName);
                if (!fading)
                {
                    fading = true;
                    CameraFade.FinishedFade += ActivateScene;
                    CameraFade.StartFade(CameraFade.FadeType.FADEIN);
                }
            }
        }

        void OnLevelWasLoaded()
        {
            if (FinishedLoading != null)
                FinishedLoading.Invoke();
            CameraFade.StartFade(CameraFade.FadeType.FADEOUT);
            async = null;
        }

        private static Camera GetMainCamera()
        {
            Camera targetCamera = Camera.main;
            //if (Camera.main == null)
            //{
            //    targetCamera = GameObject.FindGameObjectWithTag(Tags.UICamera).GetComponent<Camera>();

            //}

            return targetCamera;
        }
    }
}