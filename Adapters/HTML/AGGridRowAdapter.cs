using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.Html.Generic;
using Tricentis.Automation.Engines.Technicals.Html;

namespace MSDynamicsControls.Adapters.HTML
{
    [SupportedTechnical(typeof(IHtmlDivTechnical))]
    public class AGGridRowAdapter : AbstractHtmlDomNodeAdapter<IHtmlDivTechnical>, ITableRowAdapter
    {
        public AGGridRowAdapter(IHtmlDivTechnical technical, Validator validator) : base(technical, validator)
        {
            string className = Technical.ClassName.ToLower();
            IHtmlDivTechnical parentTechnical = Technical.ParentNode.Get<IHtmlDivTechnical>();
            validator.AssertTrue(((className.Contains("ag-header-row")|| className.Contains("ag-row")) && Technical.Role.Equals("row") ));
        }
    }
}
