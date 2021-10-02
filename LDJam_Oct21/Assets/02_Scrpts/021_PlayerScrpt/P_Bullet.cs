using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class P_Bullet : MonoBehaviour
    {
        private Rigidbody rb;
        private int bulletVelocity = 100;
        private float spawnTime, deathTime;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Start()
        {
            deathTime = Time.time + 3;
            rb.velocity = transform.forward * bulletVelocity;
        }

        private void Update()
        {
            // kills on miss
            if (Time.time > deathTime)
                Destroy(gameObject);
        }
    }
}

