using Flunt.Notifications;
using Flunt.Validations;
using solidariedadeAnonima.Domain.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace solidariedadeAnonima.Domain.Commands.UserCommand
{
    public class UpdateUserCommand : Notifiable, ICommand
    {
        public IDictionary<string, object> UpdatedFields { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                );
        }
    }
}
