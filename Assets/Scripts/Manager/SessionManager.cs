using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



//This Manager is used to manage each game session that a player has.
namespace SA
{
    public class SessionManager : MonoBehaviour
    {
        // Start is called before the first frame update
        public static SessionManager singleton;
        public delegate void OnSceneLoaded();
        public OnSceneLoaded onSceneLoaded;
        private void Awake()
        {
            if (singleton == null)
            {
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        public void LoadGameLevel(OnSceneLoaded callback)
        {
            onSceneLoaded = callback;

            StartCoroutine("scene1");

        }

        public void LoadMenu()
        {
            StartCoroutine("menu");
        }
        IEnumerator LoadLevel(string level)
        {
            yield return SceneManager.LoadSceneAsync(level, LoadSceneMode.Single);
            if (onSceneLoaded != null)
            {
                onSceneLoaded();
                onSceneLoaded = null;
            }
        }
    }
}