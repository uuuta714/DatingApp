using System;

namespace API.SignalR;

public class PresenceTracker
{
    // Key = username, Value = connectionIds (multiple devices can connect to the app)
    private static readonly Dictionary<string, List<string>> OnlineUsers = [];

    public Task<bool> UserConnected(string username, string connectionId)
    {
        var isOnline = false;
        lock (OnlineUsers)
        {
            if (OnlineUsers.ContainsKey(username))
            {
                OnlineUsers[username].Add(connectionId);
            }
            else
            {
                OnlineUsers.Add(username, [connectionId]);
                // Turn isOnline to true, only for the user's first connection 
                isOnline = true;
            }
        }
        return Task.FromResult(isOnline);
    } 

     public Task<bool> UserDisconnected(string username, string connectionId)
    {
        var isOffline = false;
        lock (OnlineUsers)
        {
            if (!OnlineUsers.ContainsKey(username)) return Task.FromResult(isOffline);
            
            OnlineUsers[username].Remove(connectionId);

            if (OnlineUsers[username].Count == 0)
            {
                OnlineUsers.Remove(username);
                // Turn isOffline to true, only for the user without any connections
                isOffline = true;
            }
        }
        return Task.FromResult(isOffline);
    }

    public Task<string[]> GetOnlineUsers()
    {
        string[] onlineUsers;
        
        lock (OnlineUsers)
        {
            onlineUsers = OnlineUsers.OrderBy(k => k.Key).Select(k => k.Key).ToArray();
        }

        return Task.FromResult(onlineUsers);
    }

    public static Task<List<string>> GetConnectionsForUser(string username)
    {
        List<string> connectionIds;
        if (OnlineUsers.TryGetValue(username, out var connections))
        {
            lock(connections)
            {
                connectionIds = connections.ToList();
            }
        }
        else
        {
            connectionIds = [];
        }
        return Task.FromResult(connectionIds);
    }
}
