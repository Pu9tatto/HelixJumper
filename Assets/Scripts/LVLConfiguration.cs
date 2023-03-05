using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Config", menuName = "Config")]
public class LVLConfiguration : ScriptableObject
{
    [SerializeField] private int _levelCount;
    [SerializeField] private int _levelNumber;
    [SerializeField] private Platform[] _platform;

    public int LevelCount => _levelCount;
    public int LevelNumber => _levelNumber;
    public Platform[] Platform => _platform;
}
