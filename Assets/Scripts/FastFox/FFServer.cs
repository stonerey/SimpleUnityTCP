using System;
using static OrderModel;

public class FFServer : CustomServer
{
    //public string ipAdress = "192.168.2.219";
    //public int port = 54010;

    public enum JsonType{ EllipseJson, OrderJson, None }    
    public static string ellipseJsonString = "ellipse";
    public static string orderJsonString = "order";

    #region Actions
    private Action OnEllipseJson = null;       
    private Action OnOrderJson = null;           
    #endregion

    private object obj = null;
    //public OrderModel orderModel = null;
    private void Start()
    {
        OnEllipseJson = () => { print("EllipseStuff"); };
        OnOrderJson = () => 
        {
            OrderModel orderModel = new OrderModel((OrderModel)obj);
            
            switch(orderModel.orderType)
            {
                case OrderType.Play:
                    print("Play Stuff");
                    break;
                case OrderType.End:
                    print("End Stuff");
                    break;
            }
        };
    }

    //ToDo: Check if I can do the same with HTTP 1.1 packages without property just with OnMessageReceived
    protected override void OnMessageReceived(string receivedMessage)
    {
        CloseClientConnection();
        CheckJsonSended();
    }

    protected override void OnRecivedMessageChange()
    {
        //CheckJsonSended();
    }    

    protected void CheckJsonSended()
    {
        //Do not use ServerLogs or it will stop code-execution
        print("Msg recived on Server: " + "<b>" + ReceivedMessage + "</b>");
        // hack: this shouldn't be like this cause it's really fragile with JSON structure changes
        try
        {
            JsonType jsonType = JsonType.None;
            if (ReceivedMessage.Contains(ellipseJsonString))
            {
                jsonType = JsonType.EllipseJson;
                obj = JsonManager.DeserializeFromJson<EllipseModel>(ReceivedMessage);
            }
            else if (ReceivedMessage.Contains(orderJsonString))
            {
                jsonType = JsonType.OrderJson;
                obj = JsonManager.DeserializeFromJson<OrderModel>(ReceivedMessage);
            }
            else
            {
                jsonType = JsonType.None;
                obj = null;
            }

            if (jsonType == JsonType.EllipseJson)
                OnEllipseJson?.Invoke();
            if (jsonType == JsonType.OrderJson)
                OnOrderJson?.Invoke();
            if (jsonType == JsonType.None)
                print("there is no json type associated");
            
        }
        catch(JsonFormatException)
        {
            print("Message received is not a JSON, so do nothing");
        }
    }
}
