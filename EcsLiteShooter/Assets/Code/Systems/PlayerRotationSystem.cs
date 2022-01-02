using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

public class PlayerRotationSystem : IEcsRunSystem
{
    [EcsInject]
    private SceneData _sceneData = default;

    public void Run(EcsSystems systems)
    {
        var world = systems.GetWorld();
        var filter = world.Filter<Player>().End();
        var players = world.GetPool<Player>();

        foreach (int entity in filter)
        {
            ref Player player = ref players.Get(entity);


            Plane playerPlane = new Plane(
                Vector3.up, player.PlayerTransform.position);

            Ray ray = _sceneData.MainCamera.ScreenPointToRay(Input.mousePosition);

            if (!playerPlane.Raycast(ray, out var hitDistance)) continue;

            player.PlayerTransform.forward = ray.GetPoint(hitDistance) 
                - player.PlayerTransform.position;
        }
    }
}
