using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLobby : MonoBehaviour
{
    public static SpawnLobby instance = null;

    private Color Defaaultcollor;
    public Color hovercolor;
    private Renderer rend;

    [SerializeField] GameObject lobby;

    [SerializeField] private Vector3 PossitionOfcet;

    [SerializeField] private GameObject tooltip;

    private int lobbyMade;

    public int LobbyMade { get => lobbyMade; set => lobbyMade = value; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }



    void Start()
    {
        rend = GetComponent<Renderer>();
        Defaaultcollor = rend.material.color;
    }

    private void OnMouseDown()
    {

        lobby.SetActive(true);
        lobbyMade = 1;
        Destroy(gameObject);
        tooltip.SetActive(false);
    }

    private void OnMouseEnter()
    {
        tooltip.SetActive(true);
      
    }

    private void OnMouseExit()
    {
        tooltip.SetActive(false);
    }
}