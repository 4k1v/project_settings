using System;
using VkNet;
using VkNet.Categories;
using VkNet.Model;
using VkNet.Enums;
using System.Threading;

namespace vkbot
{
    class Program
    {
        static void Main(string[] args)
        {
            VkApi api = new VkApi();
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 7617413,
                Settings =VkNet.Enums.Filters.Settings.All,
                AccessToken ="ee30968b9e174e7d225db9b7f9ce3bffcb469104de06a3ded774dbd1c72510abfe974532f438346c752ca",
            });
            int i = 0;            
             while(true)             
             {
                 var dialogsss = _GetDialogs(api);
                 if(i >= dialogsss.Count)
                {
                    i = 0;
                }
                
                if(MessageGet(api,dialogsss[i].Conversation.Peer.Id)=="привет")
                {
                    messagesend(api,"здарова",dialogsss[i].Conversation.Peer.Id);
                }
               
                i++;
             }
             

            
            
            
    
        }
        static void messagesend(VkApi _api,string message,long _peer)
        {
            _api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                RandomId = new Random().Next(1,100),
                PeerId = _peer,
                Message = message,               
            });

        }
        static string  MessageGet(VkApi _api,long _peeer)
        {
            var _messages = _api.Messages.GetHistory(new VkNet.Model.RequestParams.MessagesGetHistoryParams
            {
                PeerId = _peeer,
                Count = 199,

            }); 
            string[] array = new string[300];
            int i = 0;
            foreach(var mes in _messages.Messages)
            {
                array[i]= mes.Text;
                i++;
            }
            return array[0];
        }
        static System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.ConversationAndLastMessage> _GetDialogs(VkApi _api)
        {
            var dialogs = _api.Messages.GetConversations(new VkNet.Model.RequestParams.GetConversationsParams());
            return dialogs.Items;
        }
        

    }
}
