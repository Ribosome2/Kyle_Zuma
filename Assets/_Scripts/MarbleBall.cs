using UnityEngine;
using System.Collections;

public class MarbleBall : MonoBehaviour
{
    public MarbleBall preBall;
    public MarbleBall nextBall;
    public float moveSpeed=3;
    public int nextIndex=0;
    public bool isMovingForward = true;
    public float Radius = 0.5f;

    public void SetPreBall(MarbleBall ball)
    {
        preBall = ball;
    }

    public void SetNextBall(MarbleBall ball)
    {
        nextBall = ball;
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
//	    Move();
	}

    public void Move()
    {
        if (nextIndex == WaypointsPath.instance.points.Length)
        {
            return;   
        }
        float moveDist = moveSpeed*Time.deltaTime;
        Vector3 nextPos = WaypointsPath.instance.points[nextIndex];
        float dist = Vector3.Distance(transform.position,nextPos);
        Vector3 dir = (nextPos - transform.position).normalized;
        Vector3 targetPos=transform.position;
        if (dist >= moveDist)
        {
            targetPos = transform.position + dir * moveDist;
        }
        else
        {
            nextIndex++;
            if (nextIndex != WaypointsPath.instance.points.Length)
            {
                nextPos = WaypointsPath.instance.points[nextIndex];
                dir = (nextPos - transform.position).normalized;
                targetPos = WaypointsPath.instance.points[nextIndex - 1] + dir * (moveDist - dist);
            }
        }

        MarbleBall targetBall = isMovingForward ? preBall:nextBall;
        if (targetBall != null)
        {
            float minDist = targetBall.Radius + this.Radius;
            if (Vector3.Distance(targetPos, targetBall.Position) < minDist)
            {
                targetPos = transform.position + (transform.position-targetPos).normalized*minDist;
            }
        }
        transform.position = targetPos;
    }
}
