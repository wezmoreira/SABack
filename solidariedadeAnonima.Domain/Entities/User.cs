﻿using solidariedadeAnonima.Domain.Commands.UserCommand;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace solidariedadeAnonima.Domain.Entities
{
    public class User : Entity
    {
        public User()
        {
        }
        public User(string email, string username, string password, string city, string address, string cep, string number)
        {
            Email = email;
            Username = username;
            Password = password;
            City = city;
            Address = address;
            Cep = cep;
            Number = number;
            Role = "User";
            Active = true;
        }

        public User(CreateUserCommand command, string hashPassword)
        {
            Email = command.Email;
            Username = command.Username;
            Password = hashPassword;
            City = command.City;
            State = command.State;
            Address = command.Address;
            Cep= command.Cep;
            Number = command.Number;
            Role = "User";
            Active = true;
        }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Cep { get; set; }
        public string Number { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }

        public void ActiveUser()
        {
            Active = true;
        }

        public void DeactiveUser()
        {
            Active = false;
        }

        public void Update(IDictionary<string, object> updatedFields)
        {
            foreach (var field in updatedFields)
            {
                switch (field.Key.ToLower())
                {
                    case "email":
                        Email = field.Value.ToString();
                        break;
                    case "username":
                        Username = field.Value.ToString();
                        break;
                    //case "password":
                    //    Password = field.Value.ToString();
                    //    break;
                    case "city":
                        City = field.Value.ToString();
                        break;
                    case "state":
                        State = field.Value.ToString();
                        break;
                    case "address":
                        Address = field.Value.ToString();
                        break;
                    case "cep":
                        Cep = field.Value.ToString();
                        break;
                    case "number":
                        Number = field.Value.ToString();
                        break;
                }
            }
        }

        public void UserFilter()
        {
            Password = "";
        }
    }
}
