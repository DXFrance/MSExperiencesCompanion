using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace xpBot.Dialogs
{
    [LuisModel("f2ecc527-c521-4f5b-9e27-e30816d61888", "a48f97a5db7b4bc98da1c2bb11c473de")]
    public class ExperiencesDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.next_sessions")]
        public async Task NextSessions(IDialogContext context, LuisResult result)
        {
            string message = $"next sessions";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.session_details")]
        public async Task SessionDetails(IDialogContext context, LuisResult result)
        {
            string message = $"session details";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.speaker_details")]
        public async Task SpeakerDetails(IDialogContext context, LuisResult result)
        {
            string message = $"speaker details";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}
