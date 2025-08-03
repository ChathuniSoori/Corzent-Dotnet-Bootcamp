using AutoMapper.Configuration.Conventions;
using Corzent_Dotnet_Bootcamp.Models;
using Corzent_Dotnet_Bootcamp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaskApi.Services.DTOs;

namespace TaskApi.Services.Profiles
{
    public class AuthorProfile : ToDoService
    {
        public AuthorProfile() {
            createMap<ToDos, ToDoDTO>();
            
        }

        private void createMap<T1, T2>()
        {
            throw new NotImplementedException();
        }
    }
}
