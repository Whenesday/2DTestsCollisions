using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayTestScript
{
    // A Test behaves as an ordinary method

    // private GameSceneSpawner gameScene;
    private GameSceneScript gameScene;
    private GameObject debugSpawnPickup;
    private GameObject debugSpawnBoxProjectile;
    private GameObject debugSpawnCircleProjectile;
    private GameObject ballTrigger;
    private GameObject debugSpawnWeightTarget;
    private GameObject debugSpawnMagnetTarget;
    private int checkDestroyedPickupAmt;
    private int checkCollisionCount;
    private int checkTriggerCount;

     [SetUp]
    public void Setup()
    {
        GameObject gameObj = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameSceneDebug"));
        gameScene = gameObj.GetComponent<GameSceneScript>();
        Debug.Log("(PlayTest) - Sample before" + gameScene.destroyedPickup);
        //gameScene.destroyedPickup += 1;
        //gameScene.DebugIncrementDestroyedPickupAmt();
        //GameSceneScript.DebugIncrementDestroyedPickupAmt();
        //Debug.Log("(PlayTest) - Sample AFTER " + gameScene.destroyedPickup);
    }
    [TearDown]
    public void TearDown()
    {
        Object.Destroy(gameScene.gameObject);
    }
    [UnityTest]
    public IEnumerator TestDestroyPickup()
    {
        gameScene.DebugSpawnProjectile(new Vector3(0, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        debugSpawnPickup =  (GameObject)gameScene.DebugSpawnPickup(new Vector3(0, 0, 0));
        yield return new WaitForSeconds(1f);
        //checkDestroyedPickupAmt = GameObject.Find("GameScene").GetComponent<GameSceneScript>;
        Debug.Log("Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);
        Debug.Log("(PlayTest) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
    }
    [UnityTest]
    public IEnumerator TestDestroyPickupEdgeCollider()
    {
        gameScene.DebugSpawnProjectile(new Vector3(0, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        debugSpawnMagnetTarget = (GameObject)gameScene.DebugSpawnMagnetTarget(new Vector3(0, 0, 0));
        yield return new WaitForSeconds(1f);
        //checkDestroyedPickupAmt = GameObject.Find("GameScene").GetComponent<GameSceneScript>;
        Debug.Log("Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);
        Debug.Log("(PlayTest) - TestDestroyPickupEdgeCollider: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
    }
    [UnityTest]
    public IEnumerator TestDestroyPickupWithBoxCollider()
    {
        gameScene.DebugSpawnBoxProjectile(new Vector3(0, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        debugSpawnPickup = (GameObject)gameScene.DebugSpawnPickup(new Vector3(0, 0, 0));
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest) - BoxColider - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest-BoxCollider) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
        yield return new WaitForSeconds(1f);
    }
    [UnityTest]
    public IEnumerator TestExpandBoxCollider()
    {
        debugSpawnBoxProjectile = (GameObject)gameScene.DebugSpawnBoxProjectile(new Vector3(5, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        debugSpawnPickup = (GameObject)gameScene.DebugSpawnPickup(new Vector3(0, 0, 0));
        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.False(gameScene.destroyedPickup > checkDestroyedPickupAmt);
        //BoxCollider2D col = debugSpawnBoxProjectile.gameObject.GetComponent<BoxCollider2D> as BoxCollider2D;
        BoxCollider2D col = debugSpawnBoxProjectile.gameObject.GetComponent<BoxCollider2D>();
        col.size = new Vector2(50, 50);
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - ExpandBoxCollider - After) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - After) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
    }
    [UnityTest]
    public IEnumerator TestActivateBoxCollider()
    {
        debugSpawnBoxProjectile = (GameObject)gameScene.DebugSpawnBoxProjectile(new Vector3(0, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        BoxCollider2D col = debugSpawnBoxProjectile.gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false;

        debugSpawnPickup = (GameObject)gameScene.DebugSpawnPickup(new Vector3(0, 0, 0));
        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.False(gameScene.destroyedPickup > checkDestroyedPickupAmt);

        col.enabled = true;
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - ExpandBoxCollider - After) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - After) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);

    }
    [UnityTest]
    public IEnumerator TestActivateCircleCollider()
    {
        debugSpawnCircleProjectile = (GameObject)gameScene.DebugSpawnProjectile(new Vector3(0, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        CircleCollider2D col = debugSpawnCircleProjectile.gameObject.GetComponent<CircleCollider2D>();
        col.enabled = false;

        debugSpawnPickup = (GameObject)gameScene.DebugSpawnPickup(new Vector3(0, 0, 0));
        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.False(gameScene.destroyedPickup > checkDestroyedPickupAmt);

        col.enabled = true;
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - ExpandBoxCollider - After) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - After) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
        
    }
    [UnityTest]
    public IEnumerator TestTriggerCollider()
    {
        ballTrigger = (GameObject)gameScene.DebugSpawnBallTrigger(new Vector3(0, 0, 0));
        checkCollisionCount = GameSceneScript.GetCollisionCount();
        checkTriggerCount = GameSceneScript.GetTriggerCount();
        Debug.Log("(PlayTest - TestTriggerCollider - Before) - checkCollisionCount: " + checkCollisionCount);
        Debug.Log("(PlayTest - TestTriggerCollider - Before) - checkTriggerCount: " + checkTriggerCount);
        Assert.True(checkCollisionCount == 0);
        Assert.True(checkTriggerCount == 0);

        debugSpawnBoxProjectile = (GameObject)gameScene.DebugSpawnBoxProjectile(new Vector3(0, 0, 0));
        // initially ball trigger is set to Trigger
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - TestTriggerCollider - AfterTrigger) - checkCollisionCount: " + GameSceneScript.GetCollisionCount());
        Debug.Log("(PlayTest - TestTriggerCollider - AfterTrigger) - checkTriggerCount: " + GameSceneScript.GetTriggerCount());
        Assert.True(GameSceneScript.GetCollisionCount() == checkCollisionCount); // check that it's same as before, no change
        Assert.True(GameSceneScript.GetTriggerCount() > checkTriggerCount);

        /*
        checkCollisionCount = GameSceneScript.GetCollisionCount();
        checkTriggerCount = GameSceneScript.GetTriggerCount();

        CircleCollider2D col = ballTrigger.gameObject.GetComponent<CircleCollider2D>();
        col.isTrigger = false;
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - TestTriggerCollider - AfterCollision) - checkCollisionCount: " + GameSceneScript.GetCollisionCount());
        Debug.Log("(PlayTest - TestTriggerCollider - AfterCollision) - checkTriggerCount: " + GameSceneScript.GetTriggerCount());
        Assert.True(GameSceneScript.GetCollisionCount() > checkCollisionCount);
        Assert.True(GameSceneScript.GetTriggerCount() == checkTriggerCount);

        yield return new WaitForSeconds(1f);
        */
    }
    [UnityTest]
    public IEnumerator TestColliderOffset()
    {
        debugSpawnCircleProjectile = (GameObject)gameScene.DebugSpawnProjectile(new Vector3(0, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        CircleCollider2D col = debugSpawnCircleProjectile.gameObject.GetComponent<CircleCollider2D>();
        col.offset = new Vector2(10, 0);

        debugSpawnPickup = (GameObject)gameScene.DebugSpawnPickup(new Vector3(0, 0, 0));
        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - Before) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.False(gameScene.destroyedPickup > checkDestroyedPickupAmt);

        col.offset = new Vector2(0, 0);
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - ExpandBoxCollider - After) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - ExpandBoxCollider - After) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
    }
    [UnityTest]
    public IEnumerator TestColliderTile()
    {
        debugSpawnBoxProjectile = (GameObject)gameScene.DebugSpawnBoxProjectile(new Vector3(5, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        debugSpawnWeightTarget = (GameObject)gameScene.DebugSpawnWeightTarget(new Vector3(0, 0, 0));
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - TestColliderOffset - Before) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);
        Debug.Log("(PlayTest - TestColliderOffset - Before) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.False(gameScene.destroyedPickup > checkDestroyedPickupAmt);

        // weightTracker prefab is pre-saved with auto-tile on boxCollider2D
        SpriteRenderer spriteRenderer = debugSpawnWeightTarget.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        spriteRenderer.size = new Vector2(10, 10);
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - TestColliderTile - After) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - TestColliderTile - After) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
    }
    [UnityTest]
    public IEnumerator TestEdgeCollider()
    {
        debugSpawnBoxProjectile = (GameObject)gameScene.DebugSpawnBoxProjectile(new Vector3(5, 0, 0));
        checkDestroyedPickupAmt = gameScene.destroyedPickup;
        debugSpawnPickup = (GameObject)gameScene.DebugSpawnPickup(new Vector3(0, 0, 0));
        Debug.Log("(PlayTest - TestEdgeCollider - Before) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - TestEdgeCollider - Before) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.False(gameScene.destroyedPickup > checkDestroyedPickupAmt);
        BoxCollider2D col = debugSpawnBoxProjectile.gameObject.GetComponent<BoxCollider2D>();
        col.edgeRadius = 5;
        yield return new WaitForSeconds(1f);
        Debug.Log("(PlayTest - TestEdgeCollider - After) - Verifying previous amt " + checkDestroyedPickupAmt + " with " + gameScene.destroyedPickup);

        Debug.Log("(PlayTest - TestEdgeCollider - After) - GetDestroyedPickup: " + GameSceneScript.GetDestroyedPickupAmt());
        Assert.True(gameScene.destroyedPickup > checkDestroyedPickupAmt);
    }
}
