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
using Tricentis.Automation.Engines.Technicals.Generic;

namespace MSDynamicsControls.Adapters.Controllers.HTML
{
    [SupportedAdapter(typeof(AGGridAdapter))]
    public class AGGridController : TableContextAdapterController<AGGridAdapter>
    {
        public AGGridController(AGGridAdapter contextAdapter, ISearchQuery query, Validator validator) : base(contextAdapter, query, validator)
        {
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(RowsBusinessAssociation businessAssociation)
        {
            
            yield return new AlgorithmicAssociation("DataRows");
        }

        protected override IEnumerable<IAssociation> ResolveAssociation(ColumnsBusinessAssociation businessAssociation)
        {
            yield break; // throw new NotImplementedException();
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
           
            if (algorithmicAssociation.AlgorithmName == "DataRows")
            {
                return SearchDataRowTechnicals();
            }
            return base.SearchTechnicals(algorithmicAssociation);
        }

     
        protected IEnumerable<ITechnical> SearchDataRowTechnicals()
        {
            var dataRowTechnicals = new List<AriaTableRowTechnical>();

            List<AriaTableRowTechnical> dataTechnicals = ContextAdapter.Technical.All.Get<AriaTableRowTechnical>().ToList(); // ContextAdapter.Technical.All.Get<IHtmlDivTechnical>().Where(c => ((c.ClassName.Contains("ag-header-row") || c.ClassName.Contains("ag-row")) &&  c.Role.Equals("row"))).ToList();



            if (dataTechnicals != null)
            {
                dataRowTechnicals.AddRange(dataTechnicals);
            }



            return dataRowTechnicals;
        }
    }
}
