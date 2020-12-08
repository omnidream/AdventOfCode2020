using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public class Bag
    {
        public static string MyBagColor = "shiny gold";
        private static readonly Regex colorMatchRegEx = new Regex(@"^[^\s]+\s+[^\s]+", RegexOptions.Compiled);
        private static readonly Regex bagsMatchRegex = new Regex(@"(\d+) ([^\s]+\s+[^\s]+)", RegexOptions.Compiled);
        public readonly string Name;
        public readonly IDictionary<string, int> Content;

        public Bag(string line)
        {

        }

        
    }
}