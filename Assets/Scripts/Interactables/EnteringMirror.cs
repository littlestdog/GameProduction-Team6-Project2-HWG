using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringMirror : MonoBehaviour, IInteractable
{
    public GameObject Camera;
    Material mat;
    bool isInsideMirror = false;
    GameObject Player;

    private void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
        Player = GameObject.FindWithTag("Player");

        Camera = transform.GetChild(0).gameObject;
    }
    public string GetDescription()
    {
        return "Enter the mirror";
    }

    public void Interact()
    {
        Debug.LogWarning("I interacted!!");
        isInsideMirror = true;
        Player.SetActive(false);
        Camera.SetActive(true);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInsideMirror)
        {
            Player.SetActive(true);
            isInsideMirror = false;
            mat.color = new Color(0, 0, 0);
            Camera.SetActive(false);
        }
    }
}
