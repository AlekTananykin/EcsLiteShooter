using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private StaticData _staticData;
    private SceneData _sceneData;
    public void Init(EcsSystems systems)
    {
        int playerEntity = _ecsWorld.NewEntity();
        ref var player = ref playerEntity.Get<Player>();
        ref var inputData = ref playerEntity.Get<PlayerInputData>();

        GameObject playerGO = Object.Instantiate(_staticData.PlayerPrefab,
            _sceneData.PlayerSpawnPoint.position, Quaternion.identity);

        player.PlayerRigidbody = playerGO.GetComponent<Rigidbody>();
        player.PlayerSpeed = _staticData.PlayerSpeed;
        player.PlayerTransform = playerGO.transform;
    }
}
