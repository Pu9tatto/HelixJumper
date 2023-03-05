using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    [SerializeField] private int _streakForBreake = 3;
    [SerializeField] private ParticleSystem _destroyEffect;

    private GameManager _level;
    private LoadLevel _loadLevel;
    private LevelView _levelView;


    private LevelProgress _levelProgress;
    private int _streak;

    private void Start()
    {
        _levelProgress = FindObjectOfType<LevelProgress>();
        _level = FindObjectOfType<GameManager>();
        _loadLevel = FindObjectOfType<LoadLevel>();
        _levelView = FindObjectOfType<LevelView>();
    }
    private void Update()
    {
        Debug.Log(_level.TakeNumberLevel());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlatformSegment platformSegment))
        {            
            _streak++;
            other.GetComponentInParent<Platform>().Breake();
            _levelProgress.ChangeSlider();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_streak>= _streakForBreake)
        {
            _streak = 0;
            if (other.gameObject.TryGetComponent(out VisiblePlatformSegment visiblePlatformSegment))
            {
                other.gameObject.GetComponentInParent<Platform>().Breake();
            } 
        }
        else
        {
            if(other.gameObject.TryGetComponent(out RedPlatformSegment redPlatformSegment))
            {
                Destroy(gameObject);
                Instantiate(_destroyEffect, transform.position, _destroyEffect.transform.rotation);
                _loadLevel.DelayLoadLVL();
            } else _streak = 0;
        }
        if (other.gameObject.TryGetComponent(out FinishPlatform finishPlatform))
        {

            _levelProgress.ChangeSlider();
            _level.LevelUp();
            _levelView.LVLUp();
            _loadLevel.DelayLoadLVL();
        }
    }
}
