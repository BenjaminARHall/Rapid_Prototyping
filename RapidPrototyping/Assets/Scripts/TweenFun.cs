using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenFun : MonoBehaviour
{
    public GameObject player;
    public Camera cam;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            MoveObject();
    }

    void MoveObject()
    {
        Vector3 newPos = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));
        Color newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        player.transform.DOMove(newPos, 2f);
        player.transform.DOJump(newPos, 2f, 2, 2f).OnComplete(ShakeCam);
        player.transform.DORotate(Vector3.up * 90, 2f, RotateMode.LocalAxisAdd).SetEase(Ease.InOutExpo);
        player.GetComponent<Renderer>().material.DOColor(newColor, 2f);
       
    }

    void ShakeCam() 
    {
        cam.DOShakePosition(1, 3, 10, 90);
    }
}
