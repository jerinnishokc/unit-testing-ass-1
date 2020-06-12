using System;

namespace eDecor.DAO.Entities
{
    public class InvalidInputException : ApplicationException
    {
        public InvalidInputException(string message) : base(message)
        {

        }
    }
}
