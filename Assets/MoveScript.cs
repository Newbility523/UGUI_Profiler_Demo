using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour
{
    private RectTransform rt;
    public enum MoveType
    {
        None,
        Scale,
        Move,
        Size,
    }

    private void Start()
    {
        rt = this.transform as RectTransform;
    }

    public MoveType moveType ;
    private MoveType _curMoveType;
    
    private void SwitchMove(MoveType mt)
    {
        StopAllCoroutines();
        Init();
        switch (mt)
        {
            case MoveType.None:
                break;
            case MoveType.Move:
                StartCoroutine(Move());
                break;
            case MoveType.Scale:
                StartCoroutine(Scale());
                break;
            case MoveType.Size:
                StartCoroutine(Size());
                break;
        }
    }

    private void Init()
    {
        rt.localScale = Vector3.one;
        rt.localPosition = Vector3.zero;
        rt.sizeDelta = Vector2.one * 100.0f;
    }

    IEnumerator Move()
    {
        while (true)
        {
            var x = Mathf.Sin(Time.time) * 150.0f;
            rt.anchoredPosition = new Vector2(x, 0.0f);
            yield return null;
        }
    }

    IEnumerator Scale()
    {
        while (true)
        {
            var x = Mathf.Sin(Time.time);
            rt.localScale = Vector3.one * x;
            yield return null;
        }
    }
    
    IEnumerator Size()
    {
        while (true)
        {
            var x = Mathf.Sin(Time.time) * 100;
            rt.sizeDelta = Vector3.one * x;
            yield return null;
        }
    }

    private void Update()
    {
        if (_curMoveType == moveType)
        {
            return;
        }

        _curMoveType = moveType;
        SwitchMove(_curMoveType);
    }
}
