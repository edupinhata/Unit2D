﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConfig waveConfig;
    
    List<Transform> waypoints;
    float moveSpeed = 2f;
    private int waypointIndex = 0;

    void Start()
    {
        SetupWaveConfig();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    void SetupWaveConfig()
    {
        waypoints = waveConfig.GetWaypoints();
        moveSpeed = waveConfig.MoveSpeed;
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
        SetupWaveConfig();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            {
                Destroy(gameObject);
            }
        }
    }
}
