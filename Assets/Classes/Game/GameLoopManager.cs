using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;
using Unity.Jobs;

public class GameLoopManager : MonoBehaviour
{
    public static Vector3[] NodePositions;
    private static Queue<Enemy> EnemiesToRemove;
    private static Queue<int> EnemyIDsToSummon;

    public Transform NodeParent;
    public bool LoopShouldEnd;

    [System.Serializable]
    public struct Wave
    {
        public int[] enemyTypeIDs; // Array to store multiple enemy type IDs for the wave
        public int[] enemyCounts; // Array to store the number of enemies for each enemy type
        public float spawnInterval; // Time between spawns
    }

    public Wave[] Waves; // Array to define multiple waves
    private int currentWaveIndex = 0;

    void Start()
    {
        EnemyIDsToSummon = new Queue<int>();
        EnemiesToRemove = new Queue<Enemy>();
        EntitySummoner.Init();

        NodePositions = new Vector3[NodeParent.childCount];
        for (int i = 0; i < NodePositions.Length; i++)
        {
            NodePositions[i] = NodeParent.GetChild(i).position;
        }

        StartCoroutine(GameLoop());
        StartCoroutine(WaveManager());
    }

    IEnumerator WaveManager()
    {
        while (currentWaveIndex < Waves.Length && !LoopShouldEnd)
        {
            Wave currentWave = Waves[currentWaveIndex];
            Debug.Log($"Starting Wave {currentWaveIndex + 1}");

            // Loop through each enemy type in the wave
            for (int i = 0; i < currentWave.enemyTypeIDs.Length; i++)
            {
                int enemyTypeID = currentWave.enemyTypeIDs[i];
                int enemyCount = currentWave.enemyCounts[i];

                // Spawn the enemies of this type
                for (int j = 0; j < enemyCount; j++)
                {
                    EnqueueEnemyIDToSummon(enemyTypeID);
                    yield return new WaitForSeconds(currentWave.spawnInterval);
                }
            }

            // Wait until all enemies are removed before progressing
            while (EntitySummoner.EnemiesInGame.Count > 0)
            {
                yield return null;
            }

            Debug.Log($"Wave {currentWaveIndex + 1} Complete!");
            currentWaveIndex++;
        }

        Debug.Log("All waves complete!");
    }

    IEnumerator GameLoop()
    {
        while (!LoopShouldEnd)
        {
            // Spawn Enemies
            if (EnemyIDsToSummon.Count > 0)
            {
                int spawnCount = EnemyIDsToSummon.Count;
                for (int i = 0; i < spawnCount; i++)
                {
                    EntitySummoner.SummonEnemy(EnemyIDsToSummon.Dequeue());
                }
            }

            // Move Enemies
            NativeArray<Vector3> NodesToUse = new NativeArray<Vector3>(NodePositions, Allocator.TempJob);
            NativeArray<float> EnemySpeeds = new NativeArray<float>(EntitySummoner.EnemiesInGame.Count, Allocator.TempJob);
            NativeArray<int> NodeIndices = new NativeArray<int>(EntitySummoner.EnemiesInGame.Count, Allocator.TempJob);
            TransformAccessArray EnemyAccess = new TransformAccessArray(EntitySummoner.EnemiesInGameTransform.ToArray(), 2);

            for (int i = 0; i < EntitySummoner.EnemiesInGame.Count; i++)
            {
                EnemySpeeds[i] = EntitySummoner.EnemiesInGame[i].Speed;
                NodeIndices[i] = EntitySummoner.EnemiesInGame[i].NodeIndex;
            }

            MoveEnemiesJob MoveJob = new MoveEnemiesJob
            {
                NodePositions = NodesToUse,
                EnemySpeed = EnemySpeeds,
                NodeIndex = NodeIndices,
                deltaTime = Time.deltaTime
            };

            JobHandle MoveJobHandle = MoveJob.Schedule(EnemyAccess);
            MoveJobHandle.Complete();

            for (int i = 0; i < EntitySummoner.EnemiesInGame.Count; i++)
            {
                EntitySummoner.EnemiesInGame[i].NodeIndex = NodeIndices[i];
                if (EntitySummoner.EnemiesInGame[i].NodeIndex == NodePositions.Length)
                {
                    EnqueueEnemyToRemove(EntitySummoner.EnemiesInGame[i]);
                }
            }

            EnemySpeeds.Dispose();
            NodeIndices.Dispose();
            EnemyAccess.Dispose();
            NodesToUse.Dispose();

            // Remove Enemies
            if (EnemiesToRemove.Count > 0)
            {
                int removeCount = EnemiesToRemove.Count;
                for (int i = 0; i < removeCount; i++)
                {
                    EntitySummoner.RemoveEnemy(EnemiesToRemove.Dequeue());
                }
            }

            yield return null;
        }
    }

    public static void EnqueueEnemyIDToSummon(int ID)
    {
        EnemyIDsToSummon.Enqueue(ID);
    }

    public static void EnqueueEnemyToRemove(Enemy EnemyToRemove)
    {
        EnemiesToRemove.Enqueue(EnemyToRemove);
    }
}

public struct MoveEnemiesJob : IJobParallelForTransform
{
    [NativeDisableParallelForRestriction]
    public NativeArray<Vector3> NodePositions;

    [NativeDisableParallelForRestriction]
    public NativeArray<float> EnemySpeed;

    [NativeDisableParallelForRestriction]
    public NativeArray<int> NodeIndex;

    public float deltaTime;

    public void Execute(int index, TransformAccess transform)
    {
        // Only move if the enemy has a next node to move to
        if (NodeIndex[index] < NodePositions.Length)
        {
            Vector3 targetPosition = NodePositions[NodeIndex[index]];

            // Move towards the next node
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, EnemySpeed[index] * deltaTime);

            // Make the enemy face the next node
            if (transform.position != targetPosition)
            {
                // Calculate the direction to the next node
                Vector3 direction = (targetPosition - transform.position).normalized;
                
                // Rotate the enemy to face the next node
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Apply the rotation with smooth interpolation (optional)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * deltaTime);
            }
            else
            {
                // If the enemy reached the target node, increment the node index to go to the next one
                NodeIndex[index]++;
            }
        }
    }
}