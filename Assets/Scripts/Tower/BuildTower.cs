using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class BuildTower : MonoBehaviour, ISceneLoadHandler<LVLConfiguration>
{
    [SerializeField] private int _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private float _additionalScale =2;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform[] _platform;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionalScale = 0.5f;

    public int LevelCount => _levelCount;
    public float BeamScaleY => _levelCount / 2f + _startAndFinishAdditionalScale+ _additionalScale/2f;

    public void OnSceneLoaded(LVLConfiguration argument)
    {
        _levelCount = argument.LevelCount;
        _platform = argument.Platform;
    }

    private void Awake()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        Transform TowerTransform = GetComponentInParent<Transform>();
        beam.transform.localScale = new Vector3(1, BeamScaleY,1);

        Vector3 spawnPosiotion = beam.transform.position;
        spawnPosiotion.y += beam.transform.localScale.y - _additionalScale;
        SpawnPlatform(_spawnPlatform, ref spawnPosiotion, TowerTransform, Vector3.zero);
        for(int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platform[Random.Range(0, _platform.Length)], ref spawnPosiotion, TowerTransform, new Vector3(0, Random.Range(0, 360), 0));
        }
        SpawnPlatform(_finishPlatform, ref spawnPosiotion, TowerTransform, Vector3.zero);
    }

    private void SpawnPlatform(Platform platform,ref Vector3 spawnPosition, Transform parent, Vector3 rotation)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(rotation), parent);
        spawnPosition.y -= 1;
    }
}
