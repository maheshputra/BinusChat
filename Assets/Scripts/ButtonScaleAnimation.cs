using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BinusChat
{
    public class ButtonScaleAnimation : MonoBehaviour
    {
        [SerializeField] private float scaleSize;
        [SerializeField] private float scaleTime;

        public void ClickScale()
        {
            transform.DOComplete();
            transform.DOScale(scaleSize, scaleTime).SetLoops(2, LoopType.Yoyo);
        }
    }
}