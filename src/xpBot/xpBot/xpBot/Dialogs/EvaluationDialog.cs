using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xpBot.Dialogs
{
    public class EvaluationDialog
    {
        public enum EvalOptions { StronglyDisagree, Disagree, Neutral, Agree, StronglyAgree };

        [Serializable]
        public class EvaluationOrder
        {
            [Prompt("The speaker was knowledgeable about the subject matter. {||}")]
            public EvalOptions? Speaker;
            [Prompt("The session was effective in demonstrating the technology and/or solution. {||}")]
            public EvalOptions? Session;

            public static IForm<EvaluationOrder> BuildForm()
            {
                return new FormBuilder<EvaluationOrder>()
                        .Field(nameof(Speaker))
                        .Field(nameof(Session))
                        .Message("Thanks")
                        .Build();
            }
        };
    }
}