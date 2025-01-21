using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;//µ¥ÀýÄ£Ê½
    private CanvasGroup canvasGroup;
    public float scaler;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        StartCoroutine(FadeScreen(0));
    }
    private IEnumerator FadeScreen(int amount)
    {
        canvasGroup.blocksRaycasts = true;
        while(canvasGroup.alpha != amount)
        {
            switch (amount)
            {
                case 0:
                    canvasGroup.alpha -= Time.deltaTime * scaler;
                    break;
                case 1:
                    canvasGroup.alpha += Time.deltaTime * scaler;
                    break;
            }
            yield return null;
        }
        canvasGroup.blocksRaycasts = false;

    }
    public void transition(string Toscene)
    {
        StartCoroutine(TransitionToScene(Toscene));
    }
    private IEnumerator TransitionToScene(string ToScene)
    {
        Time.timeScale = 1;
        yield return FadeScreen(1);
        yield return SceneManager.LoadSceneAsync(ToScene);
        yield return FadeScreen(0);
    }
}
