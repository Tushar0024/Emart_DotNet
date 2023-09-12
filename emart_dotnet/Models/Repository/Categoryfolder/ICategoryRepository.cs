using Emart_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Categoryfolder
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task<Category> UpdateCategory(int categoryId, Category updatedCategory);
        Task<Category> GetCategoryById(int categoryId);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IEnumerable<Category>> GetCategoriesByCategoryName(string categoryName);
        Task<IEnumerable<Category>> FindByParentCatID(int id);
    }
}
