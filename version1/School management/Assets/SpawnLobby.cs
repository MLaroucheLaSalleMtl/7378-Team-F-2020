using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLobby : MonoBehaviour
{
    private Color Defaaultcollor;
    public Color hovercolor;
    private Renderer rend;

    [SerializeField] GameObject lobby;
    
    [SerializeField] private Vector3 PossitionOfcet;
    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
    }

    private void OnMouseDown()
    {

        
        lobby.SetActive(true);
        Destroy(gameObject);
    }
}