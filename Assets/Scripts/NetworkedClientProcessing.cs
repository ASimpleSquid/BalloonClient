using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkedClientProcessing
{

    #region Send and Receive Data Functions
    static public void ReceivedMessageFromServer(string msg)
    {
        Debug.Log("msg received = " + msg + ".");

        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[0]);

        switch ((ServerToClientSignifiers)signifier)
        {
            case ServerToClientSignifiers.Refresh:
                gameLogic.DestoryAllBalloon();
                string[] balloons = csv[1].Split(new char[] { ';' }, System.StringSplitOptions.RemoveEmptyEntries);
                foreach  (string balloon in balloons)
                {
                    string[] bparts = balloon.Split('_');
                    Vector2 pos = new Vector2(Single.Parse(bparts[0]), Single.Parse(bparts[1]));
                    int id = Int32.Parse(bparts[2]);
                    Vector2 screenPosition = new Vector2(pos.x * (float)Screen.width, pos.y * (float)Screen.height);
                    gameLogic.SpawnNewBalloon(screenPosition,id);
                }
                break;

            default:
                break;
        }

    }

    static public void SendMessageToServer(string msg)
    {
        networkedClient.SendMessageToServer(msg);
    }

    #endregion

    #region Connection Related Functions and Events
    static public void ConnectionEvent()
    {
        Debug.Log("Network Connection Event!");
    }
    static public void DisconnectionEvent()
    {
        Debug.Log("Network Disconnection Event!");
    }
    static public bool IsConnectedToServer()
    {
        return networkedClient.IsConnected();
    }
    static public void ConnectToServer()
    {
        networkedClient.Connect();
    }
    static public void DisconnectFromServer()
    {
        networkedClient.Disconnect();
    }

    #endregion

    #region Setup
    static NetworkedClient networkedClient;
    static GameLogic gameLogic;

    static public void SetNetworkedClient(NetworkedClient NetworkedClient)
    {
        networkedClient = NetworkedClient;
    }
    static public NetworkedClient GetNetworkedClient()
    {
        return networkedClient;
    }
    static public void SetGameLogic(GameLogic GameLogic)
    {
        gameLogic = GameLogic;
    }

    #endregion

}
#region Protocol Signifiers
public enum ClientToServerSignifiers
{
    Pop
}

public enum ServerToClientSignifiers
{
    Refresh
}
#endregion