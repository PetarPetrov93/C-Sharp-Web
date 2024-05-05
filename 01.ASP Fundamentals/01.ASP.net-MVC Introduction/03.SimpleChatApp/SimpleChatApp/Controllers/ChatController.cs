using Microsoft.AspNetCore.Mvc;
using SimpleChatApp.Models.Message;

namespace SimpleChatApp.Controllers
{
    public class ChatController : Controller
    {
        // this is just for this exercise. In a real app this should be stored in the DB!
        private static List<KeyValuePair<string, string>> messages = new List<KeyValuePair<string, string>>();
        public IActionResult Show()
        {
            if (messages.Count < 1)
            {
                return View(new ChatViewModel());
            }

            var chatModel = new ChatViewModel()
            {
                Messages = messages
                            .Select(m => new MessageViewModel() 
                                             { 
                                                 Sender = m.Value,
                                                 Message = m.Key
                                             })
                            .ToList()
            };

            return View(chatModel);
        }

        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            MessageViewModel newMessage = chat.CurrentMessage;

            messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.Message));

            return RedirectToAction("Show");
        }
    }
}
