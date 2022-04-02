using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Generator
{
    public class Declarator
    {
        private readonly List<InternalOption> _options;

        private string _queryTemplate;

        public Declarator(
            )
        {
            _options = new List<InternalOption>();
        }

        public Declarator WithQuery(
            string queryTemplate
            )
        {
            _queryTemplate = queryTemplate;

            return
                this;
        }

        public Declarator DeclareOption(
            string optionName,
            params string[] parts
            )
        {
            if (parts == null || parts.Length == 0)
            {
                throw new ArgumentException("parts");
            }

            var foundOption = _options.FirstOrDefault(j => j.OptionName == optionName);
            if (foundOption != null)
            {
                if (foundOption.Parts.Length != parts.Length)
                {
                    throw new InvalidOperationException(string.Format("Sizes is different for {0}", optionName));
                }
            }

            _options.Add(
                new InternalOption(
                    _options.Count,
                    optionName,
                    parts
                    )
                );

            return
                this;
        }

        public Generator MakeGenerator()
        {
            return
                new Generator(
                    _queryTemplate,
                    _options
                    );
        }

    }

}
