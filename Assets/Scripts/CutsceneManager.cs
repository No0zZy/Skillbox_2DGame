using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CutsceneManager : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void LoadCutscene(Cutscene cutscene)
    {
        GameManager.Instance.SwitchState(GameState.Cutscene);
        anim.SetTrigger(cutscene.CutsceneName);
    }

    public void CutsceneEnd()
    {
        GameManager.Instance.SwitchState(GameState.Play);
    }

    public void OnAnimLoadNextScene()
    {
        SceneLoader.LoadNextScene();
    }

    public void OnAnimReloadScene()
    {
        SceneLoader.ReloadScene();
    }
}