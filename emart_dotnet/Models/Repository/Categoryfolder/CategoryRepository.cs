using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Models.Repository.Categoryfolder
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> AddCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(int categoryId)
        {
            Category category = await _context.Category.FindAsync(categoryId);
            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Category> UpdateCategory(int categoryId, Category updatedCategory)
        {
            if (categoryId != updatedCategory.catmasterID)
            {
                return null;
            }

            _context.Entry(updatedCategory).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(categoryId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return updatedCategory;
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            return await _context.Category.FindAsync(categoryId);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesByCategoryName(string categoryName)
        {
            return await _context.Category.Where(c => c.categoryName == categoryName).ToListAsync();
        }

        public async Task<IEnumerable<Category>> FindByParentCatID(int id)
        {
            return await _context.Category.Where(c => c.parentCatID == id).ToListAsync();
        }

        private bool CategoryExists(int categoryId)
        {
            return _context.Category.Any(e => e.catmasterID == categoryId);
        }
    }
}
