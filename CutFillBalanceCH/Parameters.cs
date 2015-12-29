
namespace CutFillBalanceCH
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using NDesk.Options;

    public class Parameters
    {
        
        public Parameters(string[] args)
        {
            bool show_help = false;
            
            var p = new OptionSet() {
            { "c|cutFile=", "The input Cut File.",
              v => CutFile = v },
            { "f|fillFile=", "The input Fill File",
              v => FillFile = v },
            { "o|outputFile=", "Optional - The Output File",
              v => { if (v != null) OutputFile = v; } },
            { "h|help",  "show help message and exit", 
              v => show_help = v != null },
        };

            List<string> extra;
            try
            {
                extra = p.Parse(args);
            }
            catch (OptionException e)
            {
                Console.Write("{0}: ", AppDomain.CurrentDomain.FriendlyName);
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `{0} --help' for more information.", AppDomain.CurrentDomain.FriendlyName);
                return;
            }

            if (show_help)
            {
                ShowHelp(p);
                return;
            }

            if (this.OutputFile == null)
            {
                this.OutputFile = "output.txt";
            }

            if (((this.CutFile != null) && (this.FillFile != null)))
            {
                this.IsValid = true;
            } else
            {
                ShowHelp(p);
                return;
            }
            
        }

        private static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: {0}",AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Generates balanced links between Cut and Fill areas");
            Console.WriteLine("If no output file is specified a default is used.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        
        public string CutFile { get; private set; }

        public string FillFile { get; private set; }

        public bool IsValid { get; private set; }

        public string OutputFile { get; private set; }

    }
}   
