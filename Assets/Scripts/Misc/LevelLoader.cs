using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    private float transitionTime = 1f;

    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadLevelByIndex(levelIndex));
    }

    public IEnumerator LoadLevelByIndex(int levelIndex)
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
