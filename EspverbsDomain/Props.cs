using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace espverbs.Domain
{
    public class Props
     {
        public enum VerbConjugationTypes
        {
            First,
            Second,
            Third,
            Irregular
        }

        public enum PronounForms
        {
            Yo,
            Tu,
            El,
            Nosotros,
            Vosotros,
            Ellas
        }

        public enum LearningTaskTypes
        {
            Typing
        }
    }
}
