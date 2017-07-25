using LabCubes.Data.Entity;
using LabCubes.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabCubes.Services.Interface
{
   public interface IPersonService
    {
        string Add(PersonModel model);
        IEnumerable<PersonModel> GetAll();
    }

}
