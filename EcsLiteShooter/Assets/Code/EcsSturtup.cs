

using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

public class EcsSturtup : MonoBehaviour
{
    public StaticData Configuration;
    public SceneData SceneData;

    private EcsWorld _ecsWorld;
    private EcsSystems _updateSystems;
    private EcsSystems _fixedUpdateSystem;

    void Start()
    {
        _ecsWorld = new EcsWorld();
        _updateSystems = new EcsSystems(_ecsWorld);
        _fixedUpdateSystem = new EcsSystems(_ecsWorld);

        RuntimeData runtimeData = new RuntimeData();


        _updateSystems
            .Add(new PlayerInitSystem())
            .Add(new PlayerInputSystem())
            .Inject(Configuration, SceneData);

        _fixedUpdateSystem
            .Add(new PlayerMoveSystem());

        _updateSystems.Init();
        _fixedUpdateSystem.Init();
    }

    void Update()
    {
        _updateSystems.Run();
    }

    private void FixedUpdate()
    {
        _fixedUpdateSystem.Run();
    }

    private void OnDestroy()
    {
        _updateSystems?.Destroy();
        _updateSystems = null;

        _fixedUpdateSystem?.Destroy();
        _fixedUpdateSystem = null;

        _ecsWorld?.Destroy();
        _ecsWorld = null;
    }

}
