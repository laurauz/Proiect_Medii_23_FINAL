using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Medii_23.Data;
using Proiect_Medii_23.Models;

namespace Proiect_Medii_23.Models
{
    public class EchipamentSkiCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_Medii_23Context context,
        EchipamentSki echipamentSki)
        {
            var allCategories = context.Category;
            var echipamentSkiCategories = new HashSet<int>(
            echipamentSki.EchipamentSkiCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = echipamentSkiCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateUpdateBookCategoriesCategories(Proiect_Medii_23Context context,
        string[] selectedCategories, EchipamentSki echipamentSkiToUpdate)
        {
            if (selectedCategories == null)
            {
                echipamentSkiToUpdate.EchipamentSkiCategories = new List<EchipamentSkiCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (echipamentSkiToUpdate.EchipamentSkiCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        echipamentSkiToUpdate.EchipamentSkiCategories.Add(
                        new EchipamentSkiCategory
                        {
                            EchipamentSkiID = echipamentSkiToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        EchipamentSkiCategory courseToRemove
                        = echipamentSkiToUpdate
                        .EchipamentSkiCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
