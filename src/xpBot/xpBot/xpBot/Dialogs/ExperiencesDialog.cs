using InwinkLibrary;
using InwinkLibrary.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace xpBot.Dialogs
{
    [LuisModel("f2ecc527-c521-4f5b-9e27-e30816d61888", "a48f97a5db7b4bc98da1c2bb11c473de")]
    public class ExperiencesDialog : LuisDialog<object>
    {
        public const string Entity_Speaker_FirstName = "xpbot.speaker::firstname";
        public const string Entity_Speaker_LastName = "xpbot.speaker::lastname";

        private IInwinkClient _proxy = null;
        public IInwinkClient Proxy
        {
            get
            {
                return _proxy ?? (_proxy = InwinkClientFactory.CreateInwinkClient());
            }
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry I did not understand: " + string.Join(", ", result.Intents.Select(i => i.Intent));
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.welcome")]
        public async Task Welcome(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*Hi i'm xpBOT, your humble bot for the Microsoft Experience Event.*");
            sb.AppendLine("");
            sb.AppendLine($"Be aware that i'm prettu upset today.");
            sb.AppendLine($"Anyway, What can I do for you ?");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            string message = $"Sure. I can try.";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.next_sessions")]
        public async Task NextSessions(IDialogContext context, LuisResult result)
        {
            List<Session> sessions = await Proxy.GetSessions();

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
            EntityRecommendation firstName;
            if (!result.TryFindEntity(Entity_Speaker_FirstName, out firstName))
            {
                firstName = new EntityRecommendation(type: Entity_Speaker_FirstName) { Entity = string.Empty };
            }

            EntityRecommendation lastName;
            if (!result.TryFindEntity(Entity_Speaker_LastName, out lastName))
            {
                lastName = new EntityRecommendation(type: Entity_Speaker_LastName) { Entity = string.Empty };
            }

            //List<Speaker> speakers = await Proxy.GetSpeakers();

            //var speaker = from item in speakers
            //              where (item.FirstName == firstName.Entity) && (item.LastName == lastName.Entity)
            //              select item;

            string message = $"speaker details about {firstName.Entity} {lastName.Entity}";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }
    }
}
