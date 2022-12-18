using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    float durationUntilNextBalloon;
    Sprite circleTexture;
    List<GameObject> balloons;

    void Start()
    {
        balloons = new List<GameObject>();
        NetworkedClientProcessing.SetGameLogic(this);
    }

    public void SpawnNewBalloon(Vector2 screenPosition, int id)
    {
        if(circleTexture == null)
            circleTexture = Resources.Load<Sprite>("Circle");

        GameObject balloon = new GameObject("Balloon");
        balloons.Add(balloon);

        balloon.AddComponent<SpriteRenderer>();
        balloon.GetComponent<SpriteRenderer>().sprite = circleTexture;
        balloon.AddComponent<CircleClick>().id = id;
        balloon.AddComponent<CircleCollider2D>();

        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 0));
        pos.z = 0;
        balloon.transform.position = pos;
        //go.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, -Camera.main.transform.position.z));
    }

    public void DestoryAllBalloon()
    {
        foreach  (GameObject balloon in balloons)
        {
            Destroy(balloon);
        }

        balloons = new List<GameObject>();
    }

}

