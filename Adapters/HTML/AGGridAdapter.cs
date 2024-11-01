using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.Html.Generic;
using Tricentis.Automation.Engines.Adapters;
using Tricentis.Automation.Engines.Technicals.Html;
using Tricentis.Automation.Creation;

namespace MSDynamicsControls.Adapters.HTML
{
    [SupportedTechnical(typeof(IHtmlDivTechnical))]
    public class AGGridAdapter : AbstractHtmlDomNodeAdapter<IHtmlDivTechnical>, ITableAdapter
    {
        IHtmlDOMNodeTechnical parentTechnical;
        public AGGridAdapter(IHtmlDivTechnical technical, Validator validator) : base(technical, validator)
        {
            LogToFile("AGGridAdapter Constructor fired...");
            validator.AssertTrue(Technical.Role.ToLower().Equals("treegrid"));
        }
        public LoadStrategy LoadStrategy => LoadStrategy.Default;

        public override string DefaultName => Technical.GetAttribute("aria-label");

        private static void LogToFile(string s)
        {
            File.AppendAllLines($@"{Environment.GetEnvironmentVariable("TRICENTIS_PROJECTS")}\Customisation.log", new string[] { s });
        }
    }
}
