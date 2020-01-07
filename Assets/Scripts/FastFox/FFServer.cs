using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFServer : CustomServer
{
    protected override void OnMessageReceived(string receivedMessage)
    {
        //ServerLog("Msg recived on Server: " + "<b>" + receivedMessage + "</b>", Color.green);
        CloseClientConnection();
        //CloseServer();
    }
}
