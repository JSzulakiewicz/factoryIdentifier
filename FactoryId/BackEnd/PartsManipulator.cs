using System;
using System.Linq;
using Db;

namespace BackEnd
{
    public class PartsManipulator
    {
        public Part GetPart(string PartIdentifier)
        {
            try
            {
                var categoryName = PartIdentifier.Split(new char[] { '-' })[0];
                var factoryName = PartIdentifier.Split(new char[] { '-' })[1];
                var partNumber = int.Parse(PartIdentifier.Split(new char[] { '-' })[2]);


                var context = new Db.Model1Container();

                var dbPart = context.Parts
                    .Where(p => p.Category.Name == categoryName)
                    .Where(p => p.Factory.Name == factoryName)
                    .Where(p => p.Number == partNumber)
                    .FirstOrDefault();

                if (dbPart == null) throw new PartNotFoundException(PartNotFoundException.ErrorNumber.PartNotFound);

                return dbPart;

            }
            catch (Exception ex)
            {
                throw new PartNotFoundException(PartNotFoundException.ErrorNumber.WrongFormat);
            }

        }

        public void DeletePart(string PartIdentifier)
        {
            var part = GetPart(PartIdentifier);
            using (var context = new Db.Model1Container())
            {
                context.Parts.Remove(part);
                context.SaveChanges();
            }
        }

        public Part GenerateNewPart(string FactoryName, string CategoryName)
        {
            using (var context = new Model1Container())
            {
                var newPart = new Part() { CreationDate = DateTime.Now };

                if (!context.Factories.Any(f => f.Name == FactoryName))
                    context.Factories.Add(new Factory() { Name = FactoryName, CreationDate=DateTime.Now });

                if (!context.Categories.Any(c => c.Name == CategoryName))
                    context.Categories.Add(new Category() { Name = CategoryName, CreationDate = DateTime.Now });

                var prevMaxId =
                    context.Parts
                        .Where(p => p.Factory.Name == FactoryName)
                        .Where(p => p.Category.Name == CategoryName)
                        .OrderByDescending(p => p.Number)
                        ?.Select(p => p.Number)
                        ?.FirstOrDefault() ?? 0;

                newPart.Number = prevMaxId + 1;
                newPart.Factory = context.Factories.FirstOrDefault(f => f.Name == FactoryName);
                newPart.Category = context.Categories.FirstOrDefault(c => c.Name == CategoryName);
                context.Parts.Add(newPart);
                context.SaveChanges();

                return newPart;
            }
        }
    }
}
