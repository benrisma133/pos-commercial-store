using Repository.Models;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService
    {

        public enum enMode { AddNew, Update }
        public enMode Mode;

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public CategoryService(Category category ,enMode mode = enMode.AddNew)
        {
            CategoryId = category.CategoryId;
            Name = category.Name;
            CreatedAt = category.CreatedAt;

            Mode = mode;
        }

        static public CategoryService? FindID(int id)
        {
            var category = CategoryRepository.GetByID(id);

            return category is not null ? new CategoryService(category, enMode.Update) : null;

        }

        bool _AddNew()
        {
            int newId = CategoryRepository.AddNew(Name);
            if (newId != -1)
            {
                CategoryId = newId;
                return true;
            }
            return false;
        }

        bool _Update()
        {
            return CategoryRepository.Update(CategoryId, Name);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNew())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _Update();
                    }
            }

            return false;
        }

        public static List<Category> GetAll()
        {
            var categories = CategoryRepository.GetAll();
            return categories;
        }

    }

}
