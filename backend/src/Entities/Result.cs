using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Entities
{
    public class Result<T>
    {
        public T? ResultObject { get; set; }
        public bool IsSuccessful { get; private set; } = false;
        public List<string> Errors { get; private set; } = new List<string>();

        public void AddError(string errorDescription)
        {
            Errors.Add(errorDescription);
        }

        public void Succeded()
        {
            IsSuccessful = true;
        }
    }
}