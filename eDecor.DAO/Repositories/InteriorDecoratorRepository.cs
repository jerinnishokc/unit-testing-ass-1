using eDecor.DAO.Entities;
using System.Collections.Generic;
using System.Linq;

namespace eDecor.DAO.Repositories
{
    public class InteriorDecoratorRepository
    {
        readonly List<InteriorDecorator> decoratorList;

        public InteriorDecoratorRepository(List<InteriorDecorator> decorators)
        {
            decoratorList = new List<InteriorDecorator>();
            decoratorList.AddRange(decorators);
        }
        public int AddDecorator(InteriorDecorator decorator)
        {
            int id = 1001;
            if (decoratorList.Count > 0)
                id = decoratorList.Max(d => d.Id) + 1;

            decorator.SetId(id);

            decoratorList.Add(decorator);

            return id;
        }

        public InteriorDecorator GetDecorator(int decoratorId)
        {
            return decoratorList.Find(d => d.Id == decoratorId);
        }

        public List<InteriorDecorator> GetDecorators()
        {
            return decoratorList;
        }

        public List<InteriorDecorator> GetDecoratorsWithMinExperience(int minYears)
        {
            return decoratorList.Where(d => d.YearsOfExperience >= minYears).ToList();
        }

        public List<InteriorDecorator> GetDecoratorsByLocation(string location)
        {
            return decoratorList.Where(d => d.Location == location).ToList();
        }

        public bool RemoveDecorator(int decoratorId)
        {
            var decorator = GetDecorator(decoratorId);
            return decoratorList.Remove(decorator);
        }

        public bool UpdateDecorator(int decoratorId, InteriorDecorator decorator)
        {
            var _decorator = GetDecorator(decoratorId);
            if (_decorator != null)
            {
                _decorator.Email = decorator.Email;
                _decorator.SetContactNo(decorator.ContactNo);
                _decorator.SetYearsOfExperience(decorator.YearsOfExperience);

                return true;
            }

            return false;
        }
    }
}
