using Fusion;
using UnityEngine;

public class PlayerSpawner : SimulationBehaviour, IPlayerJoined
{
    public GameObject PlayerPrefab;

    // Keep track of the last spawn position and rotation
    private Vector3 lastSpawnPosition = Vector3.zero;
    private Quaternion lastSpawnRotation = Quaternion.identity;

    public void PlayerJoined(PlayerRef player)
    {
        if (player == Runner.LocalPlayer)
        {
            // Calculate spawn position in front of the last spawn
            Vector3 spawnPosition = lastSpawnPosition + lastSpawnRotation * Vector3.forward;

            // Spawn the player at the calculated position
            Runner.Spawn(PlayerPrefab, spawnPosition, lastSpawnRotation);

            // Update last spawn position and rotation
            lastSpawnPosition = spawnPosition;
            lastSpawnRotation = lastSpawnRotation; // Rotation remains the same for now, adjust if necessary
        }
    }
}
