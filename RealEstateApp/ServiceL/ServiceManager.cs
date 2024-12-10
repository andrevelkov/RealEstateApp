using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EstateLogic;
using EstateDataDTO;
using System.Windows.Media;
using ModelsLibrary.Models;

namespace ServiceL
{
    /// <summary>
    /// Service Manager delegates service operations to the specific Service Class.
    /// EstateCreationService -> Creation of Estate Objects
    /// ButtonActionService -> Various button press operations
    /// EstateManager -> Estate List/Dict management operations
    /// </summary>

    public class ServiceManager
    {
        private readonly DbManager db = new();
        private readonly EstateManager estateManager;
        public EstateCreationService CreationService { get; }
        public ButtonActionService BtnActionService {  get; }

        public ServiceManager()
        {
            estateManager = new EstateManager();
            CreationService = new EstateCreationService(estateManager);
            BtnActionService = new ButtonActionService(estateManager);
        }


        #region << ESTATE MANAGER OPERATIONS >>

        /// <summary>
        /// Adds new Estates to List from newly opened file
        /// </summary>
        /// <param name="path"> string </param>
        public void UpdateEstateList(string path)
        {
            List<Estate> list = BtnActionService.OpenFile(path);

            if (list != null)
            {
                estateManager.DeleteAll();  // Clear list
                foreach (Estate e in list)  // Add new objects from file to list
                {
                    estateManager.Add(e);
                    db.AddEstate(e);
                }
            }
            else { Console.WriteLine("list is null"); }
        }

        public void RemoveEstate(Estate e)
        {
            estateManager.Remove(e);
            db.DeleteFromDB(e);
        }

        public List<Estate> GetListEstates()
        {
            // Fetch all estates from list
            //return estateManager.GetList();

            return db.GetEstates();
        }

        public List<Estate> GetListFromDB() => db.GetEstates();

        public List<Estate> GetListSortedEstates(LegalFormEnum type)
        {
            // Populate the Dict
            estateManager.PopulateDict();

            // Set List View with items from the selected Legal form
            // Get the list of estates from Dict   ( <Enum, List<>> )
            // List<Estate> list = estateManager.ReturnEstatesByLegalForm(type);

            // Fetches Sorted Estates by legal form from the Database
            List<Estate> list = db.EstateByLegalForm(type);

            return list;
        }

        #endregion << END >>


        #region  << BUTTON ACTION OPERATIONS >>
        public EstateDTO GetEstateDTO(Estate selectedEstate) => BtnActionService.GetEstateInfo(selectedEstate);

        public void SetEstateDTO(Estate selected, EstateDTO info) 
        {
            BtnActionService.SetNewEstateInfo(selected, info);
            db.UpdateEstate(selected);
        } 

        public ImageSource GetImage(string filepath) => BtnActionService.GetImgFromFilePath(filepath)!;

        public bool FileInUse() => BtnActionService.IsFileInUse();

        /// <summary>
        /// Saves Object info to file.
        /// No Argument: Saves to default file
        /// With Argument: Saves to filepath
        /// </summary>
        /// <param name="filePath"></param>
        public void SaveFile(string filePath = null!)
        {
            // If no filepath, file already in use -> Save ; else Save As
            if (!string.IsNullOrEmpty(filePath))
            {
                BtnActionService.SaveAsJson(filePath);
            } 
            else
            {
                BtnActionService.SaveJson();
            }
        }

        public void SaveXML(string filePath) => BtnActionService.SaveXML(filePath);


        #endregion << END >>


        #region << CREATION SERVICE OPERATIONS >>

        public Estate GetEstate() => CreationService.estate!;

        public void CreateResidential(EstateEnum option, int detail)
        {
            CreationService.CreateResidentialEstate(option, detail);
        }

        public void CreateCommercial(EstateEnum option, int detail, string detail2)
        {
            CreationService.CreateCommercialEstate(option, detail, detail2);
        }

        public void CreateInstitutional(EstateEnum option, int detail)
        {
            CreationService.CreateInstitutionalEstate(option, detail);
        }

        public void AddEstateInfo(EstateDTO dto, EstateTypeEnum category, int catDetail)
        {
            CreationService.AddGeneralInfo(dto);
            CreationService.AddCategoryInfo(category, catDetail);
        }

        public void AddToDb()
        {
            db.AddEstate(CreationService.estate!);
        }

        #endregion << END >>

    }
}
