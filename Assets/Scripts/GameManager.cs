using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _level = 0;

    public void Awake()
    {
        int objectsCount = FindObjectsOfType<GameManager>().Length;
        if (objectsCount <= 1)
        DontDestroyOnLoad(this);
    }
    public void LevelUp()
    {
        _level++;
    }
    public int TakeNumberLevel() => _level;
}
