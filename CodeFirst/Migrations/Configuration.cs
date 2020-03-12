namespace CodeFirst.Migrations
{
    using CodeFirst.Entity;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirst.CodeFirstContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeFirst.CodeFirstContext context)
        {
            var Brands = new List<Brand>() { 
                new Brand() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data", Name = "Naturalizer" },
                new Brand() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data", Name = "Nike" },
            };

            var Styles = new List<ShoesStyle>() {
                new ShoesStyle() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data", Name = "Comfort" } ,
                new ShoesStyle() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data", Name = "Platform" } ,
                new ShoesStyle() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data", Name = "Athletic" } ,
                new ShoesStyle() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data", Name = "High Tops" } ,
                new ShoesStyle() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data", Name = "Creeper" } ,
            };

            var Shoes = new List<Shoes>()
            {
                new Shoes() {
                    Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data",
                    Name="Run All Day 2" ,
                    ImageUrl="https://m.media-amazon.com/images/I/71B14S7iw7L._SX700_.jpg",
                    Styles= new Collection<ShoesStyle>(new List<ShoesStyle>() {Styles[0],Styles[2]}),
                    Brand = Brands[1],
                },
                new Shoes() {
                    Id = Guid.NewGuid(), CreatedDate = DateTime.Now, CreateBy = "Seed data",
                    Name="Jane",
                    ImageUrl="https://m.media-amazon.com/images/I/61+K5STgOZL._SX700_.jpg",
                    Styles= new Collection<ShoesStyle>(new List<ShoesStyle>() {Styles[0],Styles[1]}),
                    Brand = Brands[0],
                },
            };

            context.Brands.AddRange(Brands);
            context.ShoesStyles.AddRange(Styles);
            context.Shoes.AddRange(Shoes);
        }
    }
}
