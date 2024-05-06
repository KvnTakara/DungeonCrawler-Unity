using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables

    CameraController Instance;

    [SerializeField] Transform Camera;

    public enum CameraParent
    {
        player
    }

    GameObject CameraToPlayer;

    #endregion

    #region Initialization

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(Instance);

        FindCameraParent();
    }

    void Start()
    {
        SetCameraParent(CameraParent.player);
    }

    #endregion

    #region Functions

    void FindCameraParent()
    {
        CameraToPlayer = GameObject.FindWithTag("MainPlayer");
        if (CameraToPlayer == null) Debug.LogError("MainPlayer não encontrado!");
    }

    public void SetCameraParent(CameraParent _parent)
    {
        if (_parent == CameraParent.player)
        {
            Camera.SetParent(CameraToPlayer.transform.Find("CameraParent"));
        }

        ResetCameraPosition();
    }

    void ResetCameraPosition()
    {
        Camera.localPosition = Vector3.zero;
    }

    #endregion
}
