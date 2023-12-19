using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject banana;
    public GameObject knife;

    public float minX;
    public float maxX;
    public float yValue;
    public float minZ;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), yValue, Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        PhotonNetwork.Instantiate(knife.name, randomPosition, Quaternion.identity);
        PhotonNetwork.Instantiate(banana.name, randomPosition, Quaternion.identity);
    }
}
