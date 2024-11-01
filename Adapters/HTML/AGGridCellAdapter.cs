using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Adapters.Attributes;
using Tricentis.Automation.Engines.Adapters.Generic;
using Tricentis.Automation.Engines.Adapters.Html.Generic;
using Tricentis.Automation.Engines.Technicals.Html;

namespace MSDynamicsControls.Adapters.HTML
{
    [SupportedTechnical(typeof(IHtmlDivTechnical))]
    public class AGGridCellAdapter : AbstractHtmlDomNodeAdapter<IHtmlDivTechnical>, ITableCellAdapter<IHtmlDivTechnical>
    {
        public AGGridCellAdapter(IHtmlDivTechnical technical, Validator validator) : base(technical, validator)
        {
            string className = Technical.ClassName.ToLower();
            validator.AssertTrue((className.Contains("ag-header-cell")&&Technical.Role.Equals("columnheader")) ||( className.Contains("ag-cell") && Technical.Role.Equals("gridcell")));
        }

        public int ColSpan => 1;

        public int RowSpan => 1;

        public string Text => Technical.VisibleInnerText;//Technical.All.Get<IHtmlDivTechnical>().First(s=>s.ClassName.Contains("ms-TooltipHost")).OuterText;
    }
}
