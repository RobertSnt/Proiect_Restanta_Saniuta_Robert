using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proiect_Restanta_Saniuta_Robert.Data;


namespace Proiect_Restanta_Saniuta_Robert.Models
{
    public class MovieCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_Restanta_Saniuta_RobertContext context,
        Movie movie)
        {
            var allCategories = context.Category;
            var movieCategories = new HashSet<int>(
            movie.MovieCategories.Select(c => c.MovieID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = movieCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateMovieCategories(Proiect_Restanta_Saniuta_RobertContext context,
        string[] selectedCategories, Movie movieToUpdate)
        {
            if (selectedCategories == null)
            {
                movieToUpdate.MovieCategories = new List<MovieCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var movieCategories = new HashSet<int>
            (movieToUpdate.MovieCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!movieCategories.Contains(cat.ID))
                    {
                        movieToUpdate.MovieCategories.Add(
                        new MovieCategory
                        {
                            MovieID = movieToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (movieCategories.Contains(cat.ID))
                    {
                        MovieCategory courseToRemove
                        = movieToUpdate
                        .MovieCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
