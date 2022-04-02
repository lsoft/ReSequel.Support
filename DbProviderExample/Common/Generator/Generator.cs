using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator
{
    public class Generator
    {
        private readonly string _queryTemplate;
        private readonly List<InternalOption> _options;
        private readonly Dictionary<string, uint?> _choosedOptions;

        public Generator(
            string queryTemplate,
            List<InternalOption> options
            )
        {
            if (queryTemplate == null)
            {
                throw new ArgumentNullException("queryTemplate");
            }
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            _queryTemplate = queryTemplate;
            _options = options;

            _choosedOptions = new Dictionary<string, uint?>();
        }

        public Generator BindToOption(
            string optionName,
            bool partBoolIndex
            )
        {
            if (optionName == null)
            {
                throw new ArgumentNullException("optionName");
            }

            return
                BindToOption(
                    optionName,
                    partBoolIndex ? 0u : 1u
                    );
        }

        public Generator BindToOption(
            string optionName,
            int partIndex
            )
        {
            if (optionName == null)
            {
                throw new ArgumentNullException("optionName");
            }

            return
                BindToOption(
                    optionName,
                    (uint)partIndex
                    );
        }

        public Generator BindToOption(
            string optionName,
            Func<string[], uint> partIndexProvider
            )
        {
            var foundOption = _options.FirstOrDefault(j => j.OptionName == optionName);
            if (foundOption == null)
            {
                throw new InvalidOperationException(string.Format("Not existed option {0}", optionName));
            }

            var partIndex = partIndexProvider(foundOption.Parts);

            if (partIndex >= foundOption.Parts.Length)
            {
                throw new ArgumentException("Too high value of part index");
            }

            if (_choosedOptions.ContainsKey(optionName))
            {
                throw new InvalidOperationException(string.Format("Already set {0}", optionName));
            }

            _choosedOptions[optionName] = partIndex;

            return
                this;
        }

        public Generator BindToOption(
            string optionName,
            uint partIndex
            )
        {
            var foundOption = _options.FirstOrDefault(j => j.OptionName == optionName);
            if (foundOption == null)
            {
                throw new InvalidOperationException(string.Format("Not existed option {0}", optionName));
            }

            if (partIndex >= foundOption.Parts.Length)
            {
                throw new ArgumentException("Too high value of part index");
            }

            if (_choosedOptions.ContainsKey(optionName))
            {
                throw new InvalidOperationException(string.Format("Already set {0}", optionName));
            }

            _choosedOptions[optionName] = partIndex;

            return
                this;
        }


        public string GenerateSql()
        {
            if (_choosedOptions.Any(j => !j.Value.HasValue))
            {
                throw new InvalidOperationException("Options are not set: " + string.Join(",", _choosedOptions.Where(j => !j.Value.HasValue).Select(j => j.Key).ToArray()));
            }

            var args = new List<string>();

            foreach (var option in _options.OrderBy(j => j.SequenceIndex))
            {
                uint? partIndex;
                if (!_choosedOptions.TryGetValue(option.OptionName, out partIndex))
                {
                    throw new InvalidOperationException("unknown optionName = " + option.OptionName);
                }

                args.Add(
                    option.Parts[partIndex.Value]
                    );
            }

            var completedBody = string.Format(
                _queryTemplate,
                args.Cast<object>().ToArray()
                );

            return completedBody;
        }
    }

}
