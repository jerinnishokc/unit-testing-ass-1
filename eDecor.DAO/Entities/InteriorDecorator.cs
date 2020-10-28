using System;
using System.Text.RegularExpressions;

namespace eDecor.DAO.Entities
{
    public class InteriorDecorator
    {
        public int Id { get; private set; }
        public string DecoratorName { get; set; }
        public int YearsOfExperience { get; private set; }
        public string Expertise { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; private set; }

        public InteriorDecorator(string decoratorName, int yearsOfExperience, string expertise, string location, string email, string contactNo)
        {
            //try
            //{
                DecoratorName = decoratorName;
                SetYearsOfExperience(yearsOfExperience);
                Expertise = expertise;
                Location = location;
                Email = email;
                SetContactNo(contactNo);
            //}
            //catch (Exception e) {
            //    throw e;
            //}
        }

        public void SetId(int id)
        {
            if (id >= 1001)
                Id = id;
            else
                throw new InvalidInputException("Invalid Decorator Id !!!");
        }

        public void SetYearsOfExperience(int years)
        {
            if (years >= 1)
                YearsOfExperience = years;
            else
                throw new InvalidInputException("Years of Experience Cannot Be Zero or Negative");
        }

        public void SetContactNo(string contactNo)
        {
            if (new Regex("[0-9]{10}").IsMatch(contactNo))
                ContactNo = contactNo;
            else
                throw new InvalidInputException("Invalid Contact No, Must Contain Only 10 digits");
        }
    }
}
