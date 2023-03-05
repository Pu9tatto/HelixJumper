using UnityEngine;
using IJunior.TypedScenes;
using System.Collections.Generic;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] private float _delayForNextLVL = 1;
    [SerializeField] private LVLConfiguration[] _config;
    [SerializeField] private GameManager _gameManager;


    private IEnumerator _coroutine;
  
    private IEnumerator LoadLVL()
    {
        yield return new WaitForSeconds(_delayForNextLVL);
        GameLVL.Load(_config[_gameManager.TakeNumberLevel()]);
    }

    public void DelayLoadLVL()
    {
        StartCoroutine(LoadLVL());
    }
}
