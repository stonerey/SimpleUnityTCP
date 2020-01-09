using System;
using UnityEngine;

[Serializable]
public class OrderModel
{
    public static String Play { get { return "play"; } }
    public static String End { get { return "end"; } }

    public enum OrderType
    {
        Play,
        End,
        None
    }

    [SerializeField] private string order;
    public string Order
    {
        get { return order; }
        set { order = value; SetOrderType(); }
    }
    public OrderType orderType;
    
    public OrderModel(OrderModel orderModel)
    {
        this.Order = orderModel.order;        
    }

    public void SetOrderType()
    {
        if (order.Contains(Play))
            orderType = OrderType.Play;
        else if (order.Contains(End))
            orderType = OrderType.End;
        else
            orderType = OrderType.None;
    }
}
