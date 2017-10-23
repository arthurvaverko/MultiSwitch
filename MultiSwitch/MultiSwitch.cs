using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiSwitchHelper
{
    public class MultiSwitch
    {
        public object[] Values { get; }
        private bool _AtLeastOneMatchFound = false;


        public MultiSwitch(params object[] values)
        {
            Values = values;
        }

        public PossibleMatch With(params object[] options)
        {
            if (options.Length != Values.Length) { throw new ArgumentException("Too many options provided, Length of options must match pattern length"); }

            var possibleMatch = new PossibleMatch(this, options);
            if (possibleMatch.IsMatch) { _AtLeastOneMatchFound = true; }
            return possibleMatch;
        }

        public void Default(Action actionToInvokeIfMatch)
        {
            if (!_AtLeastOneMatchFound)
            {
                actionToInvokeIfMatch();
            }
        }

        public static MultiSwitch Match(params object[] values)
        {
            return new MultiSwitch(values);
        }

        public class PossibleMatch
        {
            private readonly MultiSwitch _MultiSwitch;
            private readonly object[] _MatchedValues;
            public bool IsMatch { get; private set; }

            public PossibleMatch(MultiSwitch matcher, object[] valuesToTestForMatch)
            {
                _MultiSwitch = matcher;
                _MatchedValues = valuesToTestForMatch;
                IsMatch = _MultiSwitch.Values.SequenceEqual(_MatchedValues);
            }

            public MultiSwitch Do(Action actionToInvokeIfMatch)
            {
                if (IsMatch)
                {
                    actionToInvokeIfMatch();
                }

                return _MultiSwitch;
            }
        }
    }


}
