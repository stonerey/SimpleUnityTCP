using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class FFClient : CustomClient
{
    //ToDo: Try to send with an HTTP StreamWriter Stuff
    //Send custom string msg to server
    protected override void SendMessageToServer(string sendMsg)
    {
        //early out if there is nothing connected       
        if (!m_Client.Connected)
        {
            ClientLog("Socket Error: Stablish Server connection first", Color.red);
            return;
        }

        //Build message to server
        byte[] msg = Encoding.ASCII.GetBytes(sendMsg); //Encode message as bytes
        //Start Sync Writing
        m_NetStream.Write(msg, 0, msg.Length);
        ClientLog("Msg sended to Server: " + "<b>" + sendMsg + "</b>", Color.blue);
        //this.Invoke(CloseClient, waitingMessagesFrequency);
    }
}