using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneScript : MonoBehaviour
{
    public GameObject ufoSpawner;
    public PickupSpawnerV2 pickupSpawner;
    public GameObject projectile;
    public GameObject boxProjectile;
    public GameObject pickup;
    public GameObject ballTriggerProperty;
    public GameObject weightPickUp;
    public GameObject magnetPickup;
    public bool isGameOver;
    public bool newIsGameOver;
    public bool sampleBool;
    public GameObject gameoverText;
    public ShooterBehaviour shooterBehaviour;
    public int destroyedPickup;
    //public GameObject pickup;
    private static GameSceneScript instance;
    private int collisionCount;
    private int triggerCount;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameoverText.SetActive(false);
        isGameOver = false;
        newIsGameOver = false;
        sampleBool = true;
        destroyedPickup = 0;
        collisionCount = 0;
        triggerCount = 0;

        Debug.Log("START GameSceneScript - isGameOver:" + newIsGameOver);
    }

    // Update is called once per frame
    void Update()
    {
        if (newIsGameOver)
        {
            //Debug.Log("Success log Game Over");
            gameoverText.SetActive(true);
        }
        if (PickupSpawnerV2.signalOver)
        {
            newIsGameOver = true;
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("GameSceneScript - isGameOver:" + isGameOver);
            Debug.Log("GameSceneScript - sampleBool:" + sampleBool);
            //Debug.Log("pickupSpawner - signalOver:" + pickupSpawner.signalOver);
            Debug.Log("pickupSpawner - signalOver:" + PickupSpawnerV2.signalOver);
        }
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            DebugSpawnProjectile(new Vector3(0, 0, 0));
        }

        }

    public UFOSpawner GetUFOSpawner()
    {
        return ufoSpawner.GetComponent<UFOSpawner>();
    }
    public PickupSpawner GetPickupSpawner()
    {
        return pickupSpawner.GetComponent<PickupSpawner>();
    }

    public GameObject DebugSpawnProjectile(Vector3 spawnPos)
    {
        return (GameObject)Instantiate(projectile,spawnPos,new Quaternion(0, 0, 0, 0));
    }
    public GameObject DebugSpawnBoxProjectile(Vector3 spawnPos)
    {
        return (GameObject)Instantiate(boxProjectile, spawnPos, new Quaternion(0, 0, 0, 0));
    }

    public GameObject DebugSpawnPickup(Vector3 spawnPos)
    {
        return (GameObject)Instantiate(pickup, spawnPos, new Quaternion(0, 0, 0, 0));
    }
    public static int GetDestroyedPickupAmt()
    {
        return instance.destroyedPickup;
    }
    public GameObject DebugSpawnBallTrigger(Vector3 spawnPos)
    {
        return (GameObject)Instantiate(ballTriggerProperty, spawnPos, new Quaternion(0, 0, 0, 0));
    }
    public GameObject DebugSpawnWeightTarget(Vector3 spawnPos)
    {
        return (GameObject)Instantiate(weightPickUp, spawnPos, new Quaternion(0, 0, 0, 0));
    }
    public GameObject DebugSpawnMagnetTarget(Vector3 spawnPos)
    {
        return (GameObject)Instantiate(magnetPickup, spawnPos, new Quaternion(0, 0, 0, 0));
    }
    public static void DebugIncrementDestroyedPickupAmt()
    {
        instance.destroyedPickup ++;
        Debug.Log("(GameSceneScript) - destroyedPickup is now debug incremented to :" + instance.destroyedPickup);
    }
    public static void DebugIncrementCollisionCount()
    {
        instance.collisionCount++;
        Debug.Log("(GameSceneScript) - collisionCount is now debug incremented to :" + instance.collisionCount);
    }
    public static void DebugIncrementTriggerCount()
    {
        instance.triggerCount++;
        Debug.Log("(GameSceneScript) - triggerCount is now debug incremented to :" + instance.triggerCount);
    }
    public static int GetCollisionCount()
    {
        return instance.collisionCount;
    }
    public static int GetTriggerCount()
    {
        return instance.triggerCount;
    }
}
