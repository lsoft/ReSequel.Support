using System;
using System.Text;
using System.Threading.Tasks;

namespace Common.Generator
{
    public class InternalOption
    {
        public int SequenceIndex
        {
            get;
            set;
        }

        public string OptionName
        {
            get;
            private set;
        }

        public string[] Parts
        {
            get;
            private set;
        }

        public InternalOption(
            int sequenceIndex,
            string optionName,
            string[] parts
            )
        {
            if (parts == null)
            {
                throw new ArgumentNullException("parts");
            }
            SequenceIndex = sequenceIndex;
            OptionName = optionName;
            Parts = parts;
        }
    }

}
