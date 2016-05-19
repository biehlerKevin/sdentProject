﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	GameObject pathGO;
	Transform targetPathNode;
	int pathNodeIndex = 0;

	public float speed = 5f;

	public float health = 1;

    public int moneyValue = 1;


	// Use this for initialization
	void Start () {
		pathGO = GameObject.Find("Path");
	
	}
	
	void getNextPathNode()
	{
        if (pathNodeIndex < pathGO.transform.childCount)
        {
            targetPathNode = pathGO.transform.GetChild(pathNodeIndex);
            pathNodeIndex++;
        }
        else
        {
            targetPathNode = null;
            ReachedGoal();
        }
	}

	// Update is called once per frame
	void Update () {
		if(targetPathNode == null)
		{
			getNextPathNode();
			if(targetPathNode == null)
			{
				//Out of path
				ReachedGoal();
                return;
			}
		}

		Vector3 dir = targetPathNode.position - this.transform.localPosition;
		float distThisFrame = speed * Time.deltaTime;
		if(dir.magnitude <= distThisFrame)
		{
			//We reached the node
			targetPathNode = null;
		}
		else
		{
			//Move towrds node
			transform.Translate(dir.normalized * distThisFrame, Space.World);
            this.transform.Rotate(Vector3.up * Time.deltaTime * 200); //Rotate the enemies during movement

            //To Position the Rotation so that the enemies are facing the next node
            //Quaternion targetRotation = Quaternion.LookRotation(dir);
            //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, targetRotation, Time.deltaTime * 5);

        }
	}

	void ReachedGoal()
	{
        GameObject.FindObjectOfType<ScoreManager>().LoseLife();
        Destroy(gameObject);
	}

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        GameObject.FindObjectOfType<ScoreManager>().money += moneyValue;
        Destroy(gameObject);
    }
}
