using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    public void Run(EcsSystems systems)
    {

        var world = systems.GetWorld();
        var selectedEntities = world.Filter<PlayerInputData>().End();
        var inputPool = world.GetPool<PlayerInputData>();

        foreach (var entity in selectedEntities)
        {
            ref var input = ref inputPool.Get(entity);

            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");

            Vector3 pos = new Vector3(h, 0f, v);
            input.MoveInput = pos;
        }
    }
}
