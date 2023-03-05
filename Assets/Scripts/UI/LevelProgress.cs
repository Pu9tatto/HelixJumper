using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private Slider _slider;
    [SerializeField] private BuildTower _buildTower;

    private float _maxProgress, _currentProgress;

    private void Start()
    {
        _maxProgress = _buildTower.LevelCount;
        _currentProgress = 0;
    }

    public void ChangeSlider()
    {
        _currentProgress++;

        _slider.DOValue(_currentProgress / _maxProgress, _duration);
    }


}
