using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayers : MonoBehaviour
{
    [SerializeField] private Transform[] respawnLocations;
    [SerializeField] private float respawnPointDistanceFromGround;
    public List<GameObject> players = new List<GameObject>();

    public void Respawn()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].transform.position = respawnLocations[i].position;
        }
    }

    public void Update()
    {
        foreach (Transform point in respawnLocations)
        {
            RaycastHit hit;
            if (Physics.Raycast(point.transform.position, new Vector3(0, -1, 0), out hit, respawnPointDistanceFromGround))
            {
                point.transform.position += new Vector3(0, respawnPointDistanceFromGround - hit.distance, 0);
            }
        }
    }
}
