using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

using UnityEngine;
using Object = UnityEngine.Object;

public class PlayerInitSystem : IEcsInitSystem
{
    [EcsWorld]
    readonly private EcsWorld _ecsWorld = default;

    [EcsInject]
    private StaticData _staticData = default;

    [EcsInject]
    private SceneData _sceneData = default;

    public void Init(EcsSystems systems)
    {
        int playerEntity = _ecsWorld.NewEntity();

        AddPlayer(playerEntity);
        AddInputSystem(playerEntity);
    }

    private void AddInputSystem(int playerEntity)
    {
        var inputPool = _ecsWorld.GetPool<PlayerInputData>();
        inputPool.Add(playerEntity);
    }

    private void AddPlayer(int playerEntity)
    {
        var playerPool = _ecsWorld.GetPool<Player>();
        ref var player = ref playerPool.Add(playerEntity);
         
        GameObject playerGO = Object.Instantiate(_staticData.PlayerPrefab,
            _sceneData.PlayerSpawnPoint.position, Quaternion.identity);

        player.PlayerRigidbody = playerGO.GetComponent<Rigidbody>();
        player.PlayerSpeed = _staticData.PlayerSpeed;
        player.PlayerTransform = playerGO.transform;
    }



}
