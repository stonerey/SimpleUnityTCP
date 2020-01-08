using System;
using UnityEngine;

[Serializable]
public class EllipseModel
{
    #region Structs
    [Serializable]
    public struct EllipseStruct
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public float angle;
    }

    [Serializable]
    public struct RectangleInStruct
    {
        public int x;
        public int y;
        public int width;
        public int height;
    }

    [Serializable]
    public struct ZoomStruct
    {
        public int x;
        public int y;
        public int escala;
        public int escala_zoom;
    }
    #endregion

    [SerializeField] public EllipseStruct ellipse;
    [SerializeField] public RectangleInStruct rectangleIn;
    [SerializeField] public string playerA;
    [SerializeField] public string playerB;
    [SerializeField] public int camId;
    [SerializeField] public int proofFrame;
    [SerializeField] public int filter;
    [SerializeField] public ZoomStruct zoom;
    [SerializeField] public string timestamp;
    [SerializeField] public string imagesPath;    
}
