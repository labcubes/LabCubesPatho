using LabCubes.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using LabCubes.Models.Models;
using LabCubes.Data;
using LabCubes.Data.Entity;
using System.Linq;

namespace LabCubes.Services.Services
{
    public class PersonService : IPersonService
    {
        private readonly UnitOfWork<Person> unitOfWork;

        public PersonService()
        {
            unitOfWork = new UnitOfWork<Person>();
        }        
        public string Add(PersonModel model)
        {   
            Person p = new Person();
            p.Age = model.Age;
            p.Name = model.Name;
            unitOfWork.Insert(p);
            unitOfWork.Commit();
            return "success";
        }

        public IEnumerable<PersonModel> GetAll()
        {
            var data = unitOfWork.GetAll().ToList().Select(x => new PersonModel
            {
                Age = x.Age,
                Name = x.Name
            });

            return data;
             
        }
    }
}
