using chatLab.Context;
using chatLab.Models;
using Microsoft.AspNetCore.SignalR;

namespace chatLab.Hubs
{
    public class ChatHub:Hub
    {
        ChatContext db;
        public ChatHub(ChatContext db)
        {
            this.db = db;
        }
        public void typingmessage(string name)
        {
            Clients.All.SendAsync("typingmsg", name); 

        }

        public void sendmessage(chatmessage msg)
         {
            Clients.All.SendAsync("newmessage", msg);
            db.ChatMessages.Add(msg);
            db.SaveChanges();

        }
        [HubMethodName("personistypingnotification")]
        public void PersonIsTypingNotification(string? name)
        {
            if(name is not null)
            Clients.AllExcept(Context.ConnectionId).SendAsync("typingnotification",$"{name} is typing....");
            
        }

        [HubMethodName("personstoppedtypingnotification")]
        public void PersonStoppedTypingNotification()
        {
            Clients.AllExcept(Context.ConnectionId).SendAsync("typingnotification", "");

        }


        public void joingroup(string grpname, string name)
        {
            Groups.AddToGroupAsync(Context.ConnectionId, grpname);
            Clients.OthersInGroup(grpname).SendAsync("newmember", name, grpname);
        }

        public void sendToGroup(string name, string message, string group)
        {
            chatmessage mess = new chatmessage()
            {
                username = name,
                messagetxt = message,
                groupname = group
            };
            Clients.Group(group).SendAsync("groupmessage", name, message, group);
            db.ChatMessages.Add(mess);
            db.SaveChanges();
        }
    }
}
