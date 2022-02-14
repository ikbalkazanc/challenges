using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pazarama.Homework.Core.Entity;

namespace Pazarama.Homework.Data
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DatabaseContext>();
            context.Database.Migrate();
            var Categories = new List<Category>()
            {
                new Category
                {
              Name = "Macera", Books =
                        new List<Book>()
                        {
                            new Book
                            {
                       
                                Title = "Vahşetin Çağrısı",
                                Description =
                                    "Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                                ImageUrl = "https://i.dr.com.tr/cache/500x400-0/originals/0001842495001-1.jpg"
                            }
                        }
                },
                new Category { Name = "Komedi" },
                new Category {  Name = "Romantik" },
                new Category {  Name = "Korku" },
                new Category {  Name = "Bilim Kurgu" },
                new Category { Name = "Dehşet" },
            };

            var Books = new List<Book>()
            {
                new Book
                {
                    Title = "IT",
                    Description =
                        "Every six years, an ancient order of jiu-jitsu fighters joins forces to battle a vicious race of alien invaders. But when a celebrated war hero goes down in defeat, the fate of the planet and mankind hangs in the balance.",
                    ImageUrl =
                        "https://kbimages1-a.akamaihd.net/40e33dcf-1ec8-4231-b117-5f109e2cbd97/353/569/90/False/it.jpg",
                    Categories = new List<Category>()
                        { Categories[0], new Category() { Id = 8, Name = "Yeni Tür" }, Categories[1] }
                },
                new Book
                {
                    Title = "Doğu Ekspresinde Cinayet",
                    Description =
                        "A rowdy, unorthodox Santa Claus is fighting to save his declining business. Meanwhile, Billy, a neglected and precocious 12 year old, hires a hit m...",
                    ImageUrl = "https://img.kitapyurdu.com/v1/getImage/fn:4890428/wh:true/miw:200/mih:200",
                    Categories = new List<Category>() { Categories[0], Categories[2] }
                },
                new Book
                {
                    Title = "Bir delinin hatıra defteri",
                    Description =
                        "When their brother Frank is killed by an outlaw, brothers Bob Dalton, Emmett Dalton and Gray Dalton join their local sheriff's department. When the...",
                    ImageUrl =
                        "https://cdn2.dokuzsoft.com/u/bilgiyayinevi/img/b/b/i/birdelininhatiradefteri-1572865873.jpg",
                    Categories = new List<Category>() { Categories[1], Categories[3] }
                },
                new Book
                {
                    Title = "Aktaşlar sürücü kursu",
                    Description =
                        "Armed with only one word - Tenet - and fighting for the survival of the entire world, the Protagonist journeys through a twilight world of internat...",
                    ImageUrl = "4.jpg",
                    Categories = new List<Category>() { Categories[5] }
                },
                new Book
                {
                    Title = "Kör baykuş",
                    Description =
                        "An eclectic foursome of aspiring teenage witches get more than they bargained for as they lean into their newfound powers.",
                    ImageUrl = "https://i.dr.com.tr/cache/500x400-0/originals/0001871390001-1.jpg",
                    Categories = new List<Category>() { Categories[2], Categories[4] }
                }
            };

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Books.Count() == 0)
                {
                    context.Books.AddRange(Books);
                }

                context.SaveChanges();
            }
        }
    }
}