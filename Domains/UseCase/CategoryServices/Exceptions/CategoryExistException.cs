using System;

namespace Domains.UseCase.CategoryServices.Exceptions
{
    [Serializable]

    public class CategoryExistException : Exception
    {
        public CategoryExistException(string message) : base (message) { }        
    }
}