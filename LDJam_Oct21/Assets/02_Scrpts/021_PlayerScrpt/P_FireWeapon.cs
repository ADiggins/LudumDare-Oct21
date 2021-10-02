using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.GameCenter;

namespace Player
{
    public class P_FireWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject BulletPrefab, ShotSpawner;
        [SerializeField] private float rateOfFire = 0.1f, shotGap;
        [SerializeField] private AudioSource bulletNoise;
        [SerializeField] private GameObject Head, Gun;

        void Update()
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                Fire();
            }
        }

        private void FixedUpdate()
        {
            RaycastHit hit;
            if (Physics.Raycast(Head.transform.position, Vector3.forward, out hit))
            {
                Gun.transform.LookAt(hit.point);
                Debug.DrawLine(Head.transform.position, new Vector3(0 ,0 ,20 ));
            }
        }

        public void Fire()
        {
            if (Time.time > shotGap)
            {
                GameObject bulletClone = Instantiate(BulletPrefab, ShotSpawner.gameObject.transform.position, ShotSpawner.transform.rotation);
                bulletNoise.Play();
                shotGap = Time.time + rateOfFire;
            }
        }
    }
}

