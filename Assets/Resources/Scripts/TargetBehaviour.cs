using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameSceneScript gameScene;
    public GameObject gameOverText;
    public PickupSpawnerV2 spawner;
    void Start()
    {
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("Target HIT!?!");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //gameScene.destroyedPickup = gameScene.destroyedPickup + 1;
            //gameScene.DebugIncrementDestroyedPickupAmt();
            GameSceneScript.DebugIncrementDestroyedPickupAmt();
            Debug.Log("(TargetBehaviour) - gameScene.destroyedPickup:" + gameScene.destroyedPickup);
        }
        if (collision.gameObject.tag == "Ufo")
        {
            Debug.Log("UFO Collided, game over man");
            // gameOverText.SetActive(true);
            //spawner.signalOver = true;
            PickupSpawnerV2.signalOver = true;
            //Debug.Log("SPAWNER signalOver :" + spawner.signalOver);
            Debug.Log("IMPT - SPAWNER signalOver :" + PickupSpawnerV2.signalOver);
        }
    }
}
