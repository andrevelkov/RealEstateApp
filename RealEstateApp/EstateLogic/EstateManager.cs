using ModelsLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateLogic
{
    public class EstateManager : ListManager<Estate>
    {
        // Dictionary to hold estates grouped b thei legal form
        private readonly Dictionary<LegalFormEnum, List<Estate>> estatesByLegalForm = new Dictionary<LegalFormEnum, List<Estate>>();

        public EstateManager() 
        {
            CreateDict(); // Initialize the dict
        }

        // Initializes the dictionary with keys as LegalFormEnum and values as empty lists of estates.
        public void CreateDict()
        {
            foreach (LegalFormEnum form in Enum.GetValues(typeof(LegalFormEnum)))
            {
                // Creates an empty list for each legal form
                estatesByLegalForm[form] = new List<Estate>();
            }
        }

        // Populates the dictionary with estates grouped by their respective legal forms.
        public void PopulateDict()
        {
            // Clear List items to avoid duplication
            ClearDictLists();

            // Add estate to legal form key
            foreach (var item in GetList())
            {
                estatesByLegalForm[item.LegalForm].Add(item);
            }
        }

        // Clear all the lists within the dict
        private void ClearDictLists()
        {
            foreach (var key in estatesByLegalForm.Keys)
            {
                estatesByLegalForm[key].Clear();
            }
        }

        // Returns a list of estates for a given legal form
        public List<Estate> ReturnEstatesByLegalForm(LegalFormEnum legalForm)
        {
            return estatesByLegalForm[legalForm];
        }

    }
}
