namespace Server.Services
{
    using espverbs.Domain;
    using static espverbs.Domain.Props;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Reflection.Metadata.Ecma335;

    using Domain.Words.Verbs;

    public static class CreateModelService
    {
        public static Verb CreateVerb(string word)
        {
            Verb _verb = new Verb();
            Regex regex = new Regex(@"^(?<root>.+?)(?<ending>ar|er|ir)$");
            Match match = regex.Match(word);
            _verb.Word = word;
            if (match.Success)
            {
                _verb.Root = match.Groups["root"].Value;
                _verb.Ending = match.Groups["ending"].Value;
                switch (_verb.Ending)
                {
                    case "ar":
                        _verb.ConjugationType = VerbConjugationTypes.First;
                        break;
                    case "er":
                        _verb.ConjugationType = VerbConjugationTypes.Second;
                        break;
                    case "ir":
                        _verb.ConjugationType = VerbConjugationTypes.Third;
                        break;
                }
            }
            else
            {
                _verb.ConjugationType = VerbConjugationTypes.Irregular;
                _verb.Root = word;
                _verb.Ending = String.Empty;
            }
            return _verb;
        }
    }
}
