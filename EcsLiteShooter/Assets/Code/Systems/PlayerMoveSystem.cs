
using Leopotam.EcsLite;
using UnityEngine;

public class PlayerMoveSystem : IEcsRunSystem
{
    public void Run(EcsSystems systems)
    {
        var world = systems.GetWorld();
        var selectedEntities = world.Filter<Player>().Inc<PlayerInputData>().End();
        var players = world.GetPool<Player>();
        var inputs = world.GetPool<PlayerInputData>();

        foreach (var entity in selectedEntities)
        {
            ref var player = ref players.Get(entity);
            ref var input = ref inputs.Get(entity);

            Vector3 direction = 
                (Vector3.forward * input.MoveInput.z 
                + Vector3.right * input.MoveInput.x).normalized;

            player.PlayerRigidbody.AddForce(direction * player.PlayerSpeed, ForceMode.VelocityChange);
        }
    }

    
}
