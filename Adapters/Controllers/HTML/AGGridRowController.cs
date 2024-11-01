using MSDynamicsControls.Adapters.HTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricentis.Automation.AutomationInstructions.TestActions.Associations;
using Tricentis.Automation.AutomationInstructions.TestActions;
using Tricentis.Automation.Engines.Adapters.Controllers;
using Tricentis.Automation.Engines.Representations.Attributes;
using Tricentis.Automation.Engines.Technicals.Html;
using Tricentis.Automation.Creation;
using Tricentis.Automation.Engines.Technicals;

namespace MSDynamicsControls.Adapters.Controllers.HTML
{
    [SupportedAdapter(typeof(AGGridRowAdapter))]
    public class AGGridRowController : TableRowContextAdapterController<AGGridRowAdapter>
    {
        public AGGridRowController(AGGridRowAdapter contextAdapter, ISearchQuery query, Validator validator) : base(contextAdapter, query, validator)
        {
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(CellsBusinessAssociation businessAssociation)
        {
            yield return new TechnicalAssociation("Children");
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ChildrenBusinessAssociation businessAssociation)
        {
            yield return new TechnicalAssociation("Children");
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ParentBusinessAssociation businessAssociation)
        {
            yield return new TechnicalAssociation("ParentNode");
        }

        protected override IEnumerable<ITechnical> SearchTechnicals(IAlgorithmicAssociation algorithmicAssociation)
        {
            if (algorithmicAssociation.AlgorithmName == "Cells")
            {
                return GetCells();

            }

            return base.SearchTechnicals(algorithmicAssociation);
        }

        private IEnumerable<ITechnical> GetCells()
        {
            List<IHtmlDivTechnical> cellTechnicals = new List<IHtmlDivTechnical>();
            cellTechnicals =  ContextAdapter.Technical.All.Get<IHtmlDivTechnical>()
                                        .Where(t => t.ClassName.Contains("ag-header-cell") || t.ClassName.Contains("ag-cell")).ToList();

            if (cellTechnicals != null)
            {
                return cellTechnicals;
            }
            return new ITechnical[] { };

        }
    }
}
