using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelView : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentLVLView;
    [SerializeField] private TMP_Text _nextLVLView;
    [SerializeField] private GameManager _level;


    private void Start()
    {
        _currentLVLView.text = _level.TakeNumberLevel().ToString();
        _nextLVLView.text = (_level.TakeNumberLevel() + 1).ToString();
    }

    public void LVLUp()
    {
        _currentLVLView.text = _level.TakeNumberLevel().ToString();
        _nextLVLView.text = (_level.TakeNumberLevel() + 1).ToString();
    }
    public void RestartLVL()
    {
    }
}
