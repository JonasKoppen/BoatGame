using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoaders : MonoBehaviour
{
    public class LevelLoader : MonoBehaviour
    {
        public GameObject loadingscreen;
        public Slider slider;
        public Dropdown dropdown;
        int nextlevel;
        bool SceneIsLoaded = false;

        void Start()
        {
        }
        public void LoadLevel(int sceneIndex)
        {
            //   Debug.Log(sceneIndex.ToString());
            StartCoroutine(LoadAsychronously(sceneIndex));

        }

        public void LoadNextLevel()
        {

            int mode = dropdown.value;
            int modeIndex;
            //ChangeGameMode();



        }

        public void EndGameActionfinal(string json, string locatienaam, double score)
        {
            Debug.Log("json for score is" + json);

            EndGameAction(json);
        }

        void donothing(string json)
        { Debug.Log("score is " + json); }
        public void EndGameAction(string json)
        {
            Debug.Log("gamemode = " + json);
            switch (json)
            {

                case "0":
                    Debug.Log("case0");
                    SceneIsLoaded = false;
                    StartCoroutine(LoadAsychronously(4));
                    break;

                case "1":
                    if (!SceneIsLoaded)
                    {
                        Debug.Log("case1");
                        StartCoroutine(LoadAsychronously(13));
                        SceneIsLoaded = true;

                    }
                    break;
                case "2":

                    SceneIsLoaded = false;
                    StartCoroutine(LoadAsychronously(2));
                    break;

                case "3":
                    Debug.Log("case3");

                    if (!SceneIsLoaded)
                    {
                        StartCoroutine(LoadAsychronously(13));
                        SceneIsLoaded = true;
                    }
                    break;

            }
        }
        IEnumerator LoadAsychronously(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
            Debug.Log("loading scene " + sceneIndex);
            loadingscreen.SetActive(true);
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;

                yield return null;

            }
        }
    }
}
