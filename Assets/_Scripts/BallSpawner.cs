using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class BallSpawner : MonoBehaviour
{
    public LinkedList<MarbleBall> ballLinks=new LinkedList<MarbleBall>(); 
    public MarbleBall prefab;
    public float spawnInterval = 1;
    public int SpawnNum = 18;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(SpawnBalls(SpawnNum));
	}
	
	// Update is called once per frame
	void Update () {
	    if (ballLinks.Count > 0)
	    {
	        LinkedListNode<MarbleBall> ball = ballLinks.First;
            ball.Value.Move();
	        while (ball.Next!=null)
	        {
	            ball = ball.Next;
	            ball.Value.Move();
	        }
	       
	    }
	}

    IEnumerator SpawnBalls(int ballNum)
    {
        for (int i = 0; i < ballNum; i++)
        {
            MarbleBall ball = Instantiate(prefab) as MarbleBall;
            if (ballLinks.Count > 0)
            {
                MarbleBall lastBall = ballLinks.Last.Value;
                lastBall.SetNextBall(ball);
                ball.SetPreBall(lastBall);
            }
            ballLinks.AddLast(ball);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
