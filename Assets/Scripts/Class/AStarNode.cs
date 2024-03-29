using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Walk,
    Stop,
}
    
/// <summary>
/// 节点坐标
/// </summary>
[Serializable]
public struct NodeAxis
{
    /// <summary> X </summary>
    public int X;
    /// <summary> Y </summary>
    public int Y;

    public override string ToString()
    {
        return "节点坐标" + X + Y;
    }
}

/// <summary>
/// AStar格子类
/// </summary>
public class AStarNode
{
    /// <summary> 坐标 </summary>
    public NodeAxis NodeAxis;
    /// <summary> 格子类型 </summary>
    public NodeType NodeType;
    
    /// <summary> 距离起点的距离 </summary>
    public float BeginDis;
    /// <summary> 距离终点的距离 </summary>
    public float EndDis;
    /// <summary> 总距离 </summary>
    public float TotalDis;

    /// <summary> 父亲 </summary>
    public AStarNode Parent;

    public AStarNode(int _x,int _y, NodeType _nodeType)
    {
        NodeAxis = new NodeAxis()
        {
            X = _x,
            Y = _y,
        };

        NodeType = _nodeType;
    }
    
    /// <summary>
    /// 计算距离
    /// </summary>
    /// <param name="_beginNode"></param>
    /// <param name="_endNode"></param>
    public void CalculateDistance(NodeAxis _beginNode, NodeAxis _endNode)
    {
        float _beginDis = 0;

        if (Parent != null)
        {
            _beginDis += Parent.BeginDis;   
            BeginDis = (Mathf.Abs(Parent.NodeAxis.X - NodeAxis.X) + Mathf.Abs(Parent.NodeAxis.Y - NodeAxis.Y)) * 0.5f + _beginDis;
        }
        else
        {
            BeginDis = (Mathf.Abs(_beginNode.X - NodeAxis.X) + Mathf.Abs(_beginNode.Y - NodeAxis.Y)) * 0.5f ;
        }

        EndDis = Mathf.Abs(_endNode.X - NodeAxis.X) + Mathf.Abs(_endNode.Y - NodeAxis.Y);

        TotalDis = BeginDis + EndDis;
    }
}
