using InwinkLibrary;
using InwinkLibrary.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static xpBot.Dialogs.EvaluationDialog;

namespace xpBot.Dialogs
{
    [LuisModel("f2ecc527-c521-4f5b-9e27-e30816d61888", "a48f97a5db7b4bc98da1c2bb11c473de")]
    public class ExperiencesDialog : LuisDialog<object>
    {
        public const string Entity_Speaker_FirstName = "xpbot.speaker::firstname";
        public const string Entity_Speaker_LastName = "xpbot.speaker::lastname";
        public const string Entity_Session_Code = "xpbot.session::code";

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
            await context.PostAsync("Say that again ?");
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.welcome")]
        public async Task Welcome(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hi i'm xpBOT, your humble bot for the Microsoft Experience Event.");
            sb.AppendLine("");
            sb.AppendLine($"Be aware that i'm prettu upset today.");
            sb.AppendLine($"Anyway, What can I do for you ?");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.help")]
        public async Task Help(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Here's a list of commands you may need:");
            sb.AppendLine($"* *Help*. Obviously, this is how you get there.");
            sb.AppendLine($"* *Evaluate*. Launches the sessions evaluation process.");
            sb.AppendLine($"* *Edit evaluation*. Do you regret your previous evaluations?");
            sb.AppendLine($"* *Stop*. Stops me. You may regret that.");
            sb.AppendLine($"* *Start*. Starts me again.Did you reconsider something?");
            sb.AppendLine($"* *Pause*. Just to shut my mouth.");
            sb.AppendLine($"* *NoNotifications*. When you don't need to have news from me.");
            sb.AppendLine($"* *YesNotifications*. So, you're coming back?");
            sb.AppendLine("");
            sb.AppendLine("And that's all I think. I will send you a notification if I recall something else. Unless you didn't hit the *NoNotifications*, obviously.");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.next_sessions")]
        public async Task NextSessions(IDialogContext context, LuisResult result)
        {
            // ** The Following code works **
            // List<Session> sessions = await Proxy.GetSessions();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"So, it seems that your next session will be:");
            sb.AppendLine($"* *Designing with friends, girls and monsters* by **Michel Rousseau**.");
            sb.AppendLine("It will be in Room Endor in half an hour. Seems funny.");
            sb.AppendLine("");
            sb.AppendLine($"Based on our data, we think that you might love this session as well:");
            sb.AppendLine($"* *Injecting SQL database into you own anatomy, unusual ways* by **François Bouteruche**.");
            sb.AppendLine($"Room Death Star. Fuunny too.");

            // Recommandation API integration

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        [LuisIntent("xpbot.intent.session_details")]
        public async Task SessionDetails(IDialogContext context, LuisResult result)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"So that session is about *Design, girls, and Godzilla in a XAML context.*");
            sb.AppendLine($"");
            sb.AppendLine($"It is rated level **400**, and for designers or developpers. Room Endor, 2.00 pm.");
            sb.AppendLine($"");
            sb.AppendLine($"And the speaker is **Michel Rousseau**");
     
            await context.PostAsync(sb.ToString());
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

            // ** The Following code works **
            // List<Speaker> speakers = await Proxy.GetSpeakers();
            // var speaker = from item in speakers
            //              where (item.FirstName == firstName.Entity) && (item.LastName == lastName.Entity)
            //              select item;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"I see that **{firstName.Entity} {lastName.Entity}** is a tech Evangelist for Design, UX and UI for Microsoft France.");
            sb.AppendLine($"");
            sb.AppendLine($"He is a passionnated guy. And he's known for looking pretty. Especially form the sideviews.");
            sb.AppendLine($"He will be the speaker of three sessions during the event.");
            sb.AppendLine($"");
            sb.AppendLine($"Do you wanna see them ?");

            await context.PostAsync(sb.ToString());
            context.Wait(MessageReceived);
        }

        internal static IFormDialog<EvaluationOrder> MakeRootDialog()
        {
            return FormDialog.FromForm(EvaluationOrder.BuildForm, options: FormOptions.PromptInStart);
        }

        [LuisIntent("xpbot.intent.evaluate")]
        public async Task Evaluate(IDialogContext context, LuisResult result)
        {
            EntityRecommendation sessionCode;
            if (!result.TryFindEntity(Entity_Session_Code, out sessionCode))
            {
                sessionCode = new EntityRecommendation(type: Entity_Session_Code) { Entity = string.Empty };
            }

            await context.PostAsync($"OK, what did you find about session {sessionCode.Entity} ? Feel free with your comments.");
            context.Wait(EvaluationComplete);

            //var form = new FormDialog<EvaluationOrder>(
            //    new EvaluationOrder(),
            //    EvaluationOrder.BuildForm,
            //    FormOptions.PromptInStart,
            //    result.Entities);

            //context.Call(form, EvaluationComplete);
        }

        private async Task EvaluationComplete(IDialogContext context, IAwaitable<object> result)
        {
            var evaluationOrder = await result;
            // do something with the evaluation - text analysis
            context.Wait(this.MessageReceived);
        }

        //private async Task EvaluationComplete(IDialogContext context, IAwaitable<EvaluationOrder> result)
        //{
        //    var evaluationOrder = await result;
        //    // do something with the evaluation form results

        //    context.Wait(this.MessageReceived);
        //}
    }
}
