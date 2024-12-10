using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateDataAccess;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary.Models;


namespace EstateLogic
{
    public class DbManager
    {
        private readonly EstateContext context = new();

        public DbManager() { }

        public void AddEstate(Estate estate)
        {
            //var estateEntity = ConvertToEntity(estate);
            //ConvertCat(estateEntity, estate);

            context.Add(estate);     // Add Estate
            context.SaveChanges();   // Save changes
        }

        public void DeleteFromDB(Estate estate)
        {
            //db.DeleteFromDB(estate.EstateID);
            context.Remove(estate);
            context.Remove(estate.Address);
            context.SaveChanges();   // Save changes
        }

        public List<Estate> GetEstates()
        {
            return context.Estates
                     .Include(e => e.Address) // Include related Address entity
                     .ToList();               // Execute the query and return results
        }

        public void UpdateEstate(Estate estate)
        {
            context.Update(estate);
            context.SaveChanges();
        }

        public List<Estate> EstateByLegalForm(LegalFormEnum value)
        {
            List<Estate> estates = context.LegalFormEstates(value);
            return estates;
        }


    }
}
