using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using RPG.SceneManagement;


public class Portal : MonoBehaviour
{
    enum DestinationIdentifier
    {
        A, B, C, D, E
    }


    [SerializeField] int sceneToLoad = -1;
    [SerializeField] Transform spawnPoint;
    [SerializeField] DestinationIdentifier destination;
    [SerializeField] float fadeOutTime = 1f;
    [SerializeField] float fadeInTime = 2f;
    [SerializeField] float fadeWaitTime = 0.5f;



    private void OnTriggerEnter(Collider other) 
    {
        print("Portal Triggered");
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine(Transition());
        }
    }


    private IEnumerator Transition()
    {
        if (sceneToLoad < 0)
        {
            Debug.LogError("Scene to load not set.");
            yield break;
        }

        Fader fader = FindObjectOfType<Fader>();
        DontDestroyOnLoad(gameObject); // Before load

        yield return fader.FadeOut(fadeOutTime); // yield retur _> make sure coorutine finish    takie await, gra sie nie pauzuje
        print("FADE IN");
        yield return SceneManager.LoadSceneAsync(sceneToLoad); //Find out when loading is finished

        Portal otherPortal = GetOtherPortal();
        UpdatePlayer(otherPortal);
        yield return new WaitForSeconds(fadeWaitTime); //czekanie na wszelki wypadek az kamera sie ustabilizuje
        yield return fader.FadeIn(fadeInTime);

        Destroy(gameObject);// After scene loaded - destroy old portal from previous scene
    }

    private void UpdatePlayer(Portal otherPortal)
    {
       GameObject Player = GameObject.FindGameObjectWithTag("Player");

       Player.GetComponent<NavMeshAgent>().Warp(otherPortal.spawnPoint.position); //Move to new position by nave mesh
       Player.transform.rotation = otherPortal.spawnPoint.rotation;


    }

    private Portal GetOtherPortal()
    {
        foreach (Portal portal in GameObject.FindObjectsOfType(typeof(Portal)))
        {
            if (portal == this) continue;
            if(portal.destination != destination) continue;

            return portal;
        }

        return null;
    }
}
